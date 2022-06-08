using HotChocolateWithAspIdentity.Application.Interfaces;
using HotChocolateWithAspIdentity.GraphQL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateWithAspIdentity.GraphQL.DependencyInjection
{
	public static class GrapQLServices
	{
		public static IServiceCollection AddCustomGraphQL(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddHttpContextAccessor();
			services.AddScoped<ICurrentUserService, CurrentUserService>();
			services.AddDatabaseDeveloperPageExceptionFilter();
			return services;
		}
	}
}
