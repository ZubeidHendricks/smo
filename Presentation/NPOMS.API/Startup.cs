using AutoMapper;
using Hellang.Middleware.ProblemDetails;
using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using NPOMS.Repository;
using NPOMS.Services.DenodoAPI;
using NPOMS.Services.Extensions;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Mappings;
using NPOMS.Services.PowerBI.Models;
using System;
using System.Net;

namespace NPOMS.API
{
	public class Startup
	{
		#region Fields

		public IConfiguration Configuration { get; }

		#endregion

		#region Constructors

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		#endregion

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//most of API providers require TLS 1.2 nowadays
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			//https://www.infoworld.com/article/3584786/how-to-use-the-problemdetails-middleware-in-aspnet-core.html
			services.AddProblemDetails(opts =>
			{
				opts.IncludeExceptionDetails = (ctx, ex) =>
				{
					var env = ctx.RequestServices.GetRequiredService<IHostEnvironment>();
					return env.IsDevelopment() || env.IsEnvironment("QA");
				};
			});

			// Take note of the IDBAuthTokenService service. This is how we provide support Managed Identity in app services
			services.AddDbContext<RepositoryContext>();
			services.AddTransient<IDBAuthTokenService, AzureSqlAuthTokenService>();

			//services.AddAutoMapper(typeof(Startup));
			// Auto Mapper Configurations
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingConfiguration());
			});

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy",
					builder => builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			});

			services.ConfigureIISIntegration();
			services.ConfigureRepositoryWrapper();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
						.AddMicrosoftIdentityWebApi(Configuration, "AzureAdB2C");

			services.AddAuthorization();

			services.AddMvc(option => option.EnableEndpointRouting = false)
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
				.AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

			var blobConfig = Configuration.GetSection("BlobStorageSettings").Get<BlobStorageSettings>();

			#if !DEBUG
				blobConfig.StorageAccount = Environment.GetEnvironmentVariable("APPSETTING_Storage01");
				blobConfig.SubFolderPath = Environment.GetEnvironmentVariable("APPSETTING_FolderPath01");
			#endif

			services.AddSingleton(blobConfig);

			var denodoAPIConfig = Configuration
					.GetSection("DenodoAPIConfiguration")
					.Get<DenodoAPIConfig>();
			services.AddSingleton(denodoAPIConfig);

			services.AddConfiguration<AzureAdB2C>(Configuration, "AzureAdB2C");
			services.AddConfiguration<GeneralConfiguration>(Configuration, "GeneralConfiguration");
			services.AddConfiguration<MSGraphConfiguration>(Configuration, "MicrosoftGraph");

			// Loading appsettings.json in C# Model classes
			services.Configure<PowerBiAD>(Configuration.GetSection("PowerBiAD"))
					.Configure<PowerBI>(Configuration.GetSection("PowerBI"));

			#if !DEBUG
				services.Configure<PowerBiAD>(powerBIAD => 
				{
					powerBIAD.ClientId = Environment.GetEnvironmentVariable("APPSETTING_PowerBIAppID");
					powerBIAD.ClientSecret = Environment.GetEnvironmentVariable("APPSETTING_PowerBISecret");
					powerBIAD.TenantId = Environment.GetEnvironmentVariable("APPSETTING_TenantID");
				});
			#endif

			services.Configure<FormOptions>(o =>
			{
				o.ValueLengthLimit = int.MaxValue;
				o.MultipartBodyLengthLimit = int.MaxValue;
				o.MemoryBufferThreshold = int.MaxValue;
			});

			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1",
					new OpenApiInfo
					{
						Title = "NPOMS",
						Version = "v10",
						Description = "NPOMS",
						TermsOfService = new Uri("https://www.westerncape.gov.za/"),
						Contact = new OpenApiContact() { Name = "Yaasier Philander", Email = "Mogammad.Philander@westerncape.gov.za" }
					});
			});

			var engine = EngineContext.Create();
			engine.ConfigureServices(services, Configuration);

			services.AddHttpContextAccessor();

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);

			services.AddCors(c =>
			{
				c.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin());
			});

			//services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"]);

			// The following line enables Application Insights telemetry collection.
			services.AddApplicationInsightsTelemetry(Configuration["ApplicationInsights:InstrumentationKey"]);
			services.ConfigureTelemetryModule<DependencyTrackingTelemetryModule>((module, o) =>
			{
				module.EnableSqlCommandTextInstrumentation = true;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			var ctx = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
			AppContext.Configure(ctx);

			app.UseProblemDetails();

			app.Use(async (context, next) =>
			{
				await next.Invoke();

				if (context.Response.StatusCode == 404 && !context.Request.Path.Value.Contains("/api"))
				{
					context.Request.Path = new PathString("/index.html");
					await next.Invoke();
				}
			});

			app.UseHsts();

			app.UseCors(builder => builder
				.AllowAnyHeader()
				.AllowAnyMethod()
				.SetIsOriginAllowed((host) => true)
				.AllowCredentials()
			);			

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "NPOMS - V01");
			});

			app.UseHttpsRedirection();
			app.UseDefaultFiles();
			app.UseStaticFiles();

			app.UseCors(x => x
				   .AllowAnyOrigin()
				   .AllowAnyMethod()
				   .AllowAnyHeader());

			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.All
			});

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
