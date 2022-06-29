using HotChocolateWithAspIdentity.Application.Interfaces;
using HotChocolateWithAspIdentity.Application.Services;
using HotChocolateWithAspIdentity.GraphQL.GraphQL;
using HotChocolateWithAspIdentity.GraphQL.Services;
using HotChocolateWithAspIdentity.Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateWithAspIdentity.GraphQL.DependencyInjection
{
	public static class GrapQLServices
	{
		public static IServiceCollection AddCustomGraphQL(
			this IServiceCollection services)
		{
			services.AddHttpContextAccessor();
			services.AddScoped<ICurrentUserService, CurrentUserService>();
			services.AddScoped<IIdentityService, IdentityService>();
			services.AddDatabaseDeveloperPageExceptionFilter();

			services
				.AddGraphQLServer()
				.AddQueryType<Query>()
				.AddMutationType<Mutation>()
				.AddFiltering()
				.AddSorting();

			return services;
		}
	}
}
