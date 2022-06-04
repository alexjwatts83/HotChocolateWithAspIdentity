using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotChocolateWithAspIdentity.GraphQL.DependencyInjection
{
	public static class AuthConfigureServices
	{
		public static IServiceCollection AddCustomAuthentication(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			var signingKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes("MySuperSecretKey"));

			services
				.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters =
						new TokenValidationParameters
						{
							ValidIssuer = "https://auth.chillicream.com",
							ValidAudience = "https://graphql.chillicream.com",
							ValidateIssuerSigningKey = true,
							IssuerSigningKey = signingKey
						};
				});

			return services;
		}
	}
}
