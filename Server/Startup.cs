using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Server
{
	public class Startup : object
	{
		public Startup() : base()
		{
		}

		public Startup
			(Microsoft.Extensions.Configuration.IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

		public void ConfigureServices
			(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			services.AddControllers();

			// Note:
			services.AddTransient
				<Microsoft.AspNetCore.Http.IHttpContextAccessor,
				Microsoft.AspNetCore.Http.HttpContextAccessor>();

			// Note:
			//services.AddTransient<Dtx.Logging.ILogger, Dtx.Logging.NLogAdapter>(); // Compile Error!

			//services.AddTransient<Dtx.Logging.ILogger<>, Dtx.Logging.NLogAdapter<>>(); // Compile Error!

			//services.AddSingleton
			//	(serviceType: typeof(Dtx.Logging.ILogger<>),
			//	implementationType: typeof(Dtx.Logging.NLogAdapter<>)); // Runtime Error!

			services.AddTransient
				(serviceType: typeof(Dtx.Logging.ILogger<>),
				implementationType: typeof(Dtx.Logging.NLogAdapter<>));

			//services.AddTransient
			//	(serviceType: typeof(Dtx.Logging.ILogger<>),
			//	implementationType: typeof(Dtx.Logging.Log4NetAdapter<>));
		}

		public void Configure
			(Microsoft.AspNetCore.Builder.IApplicationBuilder app,
			Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
