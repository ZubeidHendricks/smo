using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using NPOMS.Services.DenodoAPI;
using NPOMS.Services.Extensions;
using NPOMS.Services.PowerBI.Models;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureRepositoryWrapper(builder);

// Setting configuration for protected web api
builder.Services.AddMicrosoftIdentityWebApiAuthentication(builder.Configuration, "AzureAdB2C");

var blobConfig = builder.Configuration.GetSection("BlobStorageSettings").Get<BlobStorageSettings>();
var msGraphConfig = builder.Configuration.GetSection("MicrosoftGraph").Get<MSGraphConfiguration>();
//var msGraphConfig = builder.Configuration.GetSection("MicrosoftGraph").Get<dtoMicrosoftGrap>
var denodoAPIConfig = builder.Configuration.GetSection("DenodoAPIConfiguration").Get<DenodoAPIConfig>();

#if !DEBUG
	blobConfig.StorageAccount = Environment.GetEnvironmentVariable("APPSETTING_Storage01");
	blobConfig.SubFolderPath = Environment.GetEnvironmentVariable("APPSETTING_FolderPath01");

	msGraphConfig.ClientId = Environment.GetEnvironmentVariable("APPSETTING_B2B_ClientId");
	msGraphConfig.TenantId = Environment.GetEnvironmentVariable("APPSETTING_B2B_TenantId");
	msGraphConfig.Secret = Environment.GetEnvironmentVariable("APPSETTING_B2B_Client_Secret");


	denodoAPIConfig.BaseUri = Environment.GetEnvironmentVariable("APPSETTING_DENODO_BASEURI");
	denodoAPIConfig.Username = Environment.GetEnvironmentVariable("APPSETTING_DENODO_USERNAME");
	denodoAPIConfig.Pwd = Environment.GetEnvironmentVariable("APPSETTING_DENODO_PASSWORD");
	denodoAPIConfig.FacilityView = Environment.GetEnvironmentVariable("APPSETTING_DENODO_FACILITY_VIEW");
	denodoAPIConfig.BudgetView = Environment.GetEnvironmentVariable("APPSETTING_DENODO_BUDGET_VIEW");
#endif

builder.Services.AddSingleton(blobConfig);
builder.Services.AddSingleton(denodoAPIConfig);

builder.Services.AddConfiguration<MSGraphConfiguration>(builder.Configuration, "MicrosoftGraph");
builder.Services.AddConfiguration<GeneralConfiguration>(builder.Configuration, "GeneralConfiguration");

builder.Services.Configure<PowerBiAD>(builder.Configuration.GetSection("PowerBiAD"))
				.Configure<PowerBI>(builder.Configuration.GetSection("PowerBI"));

#if !DEBUG
	builder.Services.Configure<PowerBiAD>(powerBIAD =>
	{
		powerBIAD.ClientId = Environment.GetEnvironmentVariable("APPSETTING_PowerBIAppID");
		powerBIAD.ClientSecret = Environment.GetEnvironmentVariable("APPSETTING_PowerBISecret");
		powerBIAD.TenantId = Environment.GetEnvironmentVariable("APPSETTING_TenantID");
	});
#endif

//solves 413 errors
builder.Services.Configure<FormOptions>(o =>
{
	o.ValueLengthLimit = int.MaxValue;
	o.MultipartBodyLengthLimit = int.MaxValue;
	o.MemoryBufferThreshold = int.MaxValue;
});

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddCors(o => o.AddPolicy("default", builder =>
{
	builder.AllowAnyOrigin()
		   .AllowAnyMethod()
		   .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHsts();
app.UseCors("default");

app.UseAuthentication();

app.UseHttpsRedirection();

var options = new DefaultFilesOptions();
options.DefaultFileNames.Clear();
options.DefaultFileNames.Add("index.html");

app.UseDefaultFiles(options);
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();