using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
