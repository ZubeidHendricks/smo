using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NPOMS.Services.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NPOMS.Services.Infrastructure.Implementation
{
	/// <summary>
	/// Represents Nop engine
	/// </summary>
	public class AppEngine : IEngine
	{
		#region Fields

		private ITypeFinder _typeFinder;

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets service provider
		/// </summary>
		private IServiceProvider _serviceProvider { get; set; }

		#endregion

		#region Utilities

		/// <summary>
		/// Get IServiceProvider
		/// </summary>
		/// <returns>IServiceProvider</returns>
		protected IServiceProvider GetServiceProvider()
		{
			if (ServiceProvider == null)
				return null;
			var accessor = ServiceProvider?.GetService<IHttpContextAccessor>();
			var context = accessor?.HttpContext;
			return context?.RequestServices ?? ServiceProvider;
		}

		private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			//check for assembly already loaded
			var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
			if (assembly != null)
				return assembly;

			//get assembly from TypeFinder
			var tf = Resolve<ITypeFinder>();
			if (tf == null)
				return null;
			assembly = tf.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
			return assembly;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Add and configure services
		/// </summary>
		/// <param name="services">Collection of service descriptors</param>
		/// <param name="configuration">Configuration of the application</param>
		/// <param name="nopConfig">Nop configuration parameters</param>
		public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			_serviceProvider = services.BuildServiceProvider();
			//resolve assemblies here. otherwise, plugins can throw an exception when rendering views
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
		}

		public void ConfigureRequestPipeline(IApplicationBuilder application)
		{

			_serviceProvider = application.ApplicationServices;
		}

		/// <summary>
		/// Resolve dependency
		/// </summary>
		/// <typeparam name="T">Type of resolved service</typeparam>
		/// <returns>Resolved service</returns>
		public T Resolve<T>() where T : class
		{
			return (T)Resolve(typeof(T));
		}

		/// <summary>
		/// Resolve dependency
		/// </summary>
		/// <param name="type">Type of resolved service</param>
		/// <returns>Resolved service</returns>
		public object Resolve(Type type)
		{
			var sp = GetServiceProvider();
			if (sp == null)
				return null;
			return sp.GetService(type);
		}

		/// <summary>
		/// Resolve dependencies
		/// </summary>
		/// <typeparam name="T">Type of resolved services</typeparam>
		/// <returns>Collection of resolved services</returns>
		public virtual IEnumerable<T> ResolveAll<T>()
		{
			return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
		}

		/// <summary>
		/// Resolve unregistered service
		/// </summary>
		/// <param name="type">Type of service</param>
		/// <returns>Resolved service</returns>
		public virtual object ResolveUnregistered(Type type)
		{
			Exception innerException = null;
			foreach (var constructor in type.GetConstructors())
			{
				try
				{
					//try to resolve constructor parameters
					var parameters = constructor.GetParameters().Select(parameter =>
					{
						var service = Resolve(parameter.ParameterType);
						if (service == null)
							throw new Exception("Unknown dependency");
						return service;
					});

					//all is ok, so create instance
					return Activator.CreateInstance(type, parameters.ToArray());
				}
				catch (Exception ex)
				{
					innerException = ex;
				}
			}

			throw new Exception("No constructor was found that had all the dependencies satisfied.", innerException);
		}

		#endregion

		#region Properties

		/// <summary>
		/// Service provider
		/// </summary>
		public virtual IServiceProvider ServiceProvider => _serviceProvider;

		#endregion
	}
}
