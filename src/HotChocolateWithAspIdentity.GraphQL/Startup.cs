using GraphQL.Server.Ui.Voyager;
using HotChocolateWithAspIdentity.GraphQL.DependencyInjection;
using HotChocolateWithAspIdentity.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotChocolateWithAspIdentity.GraphQL
{
	public class Startup
    {
		private readonly IConfiguration _configuration;
		private readonly IWebHostEnvironment _environment;

		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			_configuration = configuration;
			_environment = environment;
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
        {
			services.AddInfrastructureServices(_configuration);

			services.AddCustomAuthentication(_configuration);

			services.AddCustomGraphQL();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

			//app.UseAuthentication();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGraphQL();
			});

			app.UseGraphQLVoyager(new VoyagerOptions()
			{
				GraphQLEndPoint = "/graphql"
			}, "/graphql-voyager");
		}
    }
}
