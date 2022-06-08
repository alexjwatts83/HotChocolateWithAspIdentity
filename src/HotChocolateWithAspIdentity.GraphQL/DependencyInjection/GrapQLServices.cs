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
			return services;
		}
	}
}
