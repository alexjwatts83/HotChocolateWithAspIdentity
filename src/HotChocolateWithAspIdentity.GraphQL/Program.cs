using HotChocolateWithAspIdentity.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace HotChocolateWithAspIdentity.GraphQL
{
	public class Program
    {
        public static void Main(string[] args)
        {
			var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				try
				{
					var initialiser = services
						.GetRequiredService<ApplicationDbContextInitialiser>();

					initialiser.Initialise();
					initialiser.Seed();
				}
				catch (Exception ex)
				{
					var logger = services
						.GetRequiredService<ILogger<Program>>();

					logger.LogError(ex, "An error occurred while migrating or initializing the database.");

					throw;
				}
			}

			host.Run();
		}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
