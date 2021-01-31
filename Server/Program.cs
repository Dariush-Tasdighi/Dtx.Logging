using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Server
{
	public class Program : object
	{
		public Program() : base()
		{
		}

		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();

			NLog.LogManager.Shutdown();
		}

		public static Microsoft.Extensions.Hosting.IHostBuilder CreateHostBuilder(string[] args) =>
			Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder
					.UseStartup<Startup>();
				});
	}
}
