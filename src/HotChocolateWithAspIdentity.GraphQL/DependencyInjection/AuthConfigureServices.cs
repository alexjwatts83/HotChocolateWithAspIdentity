using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidateIssuerSigningKey = true,
					ValidAudience = "audience",
					ValidIssuer = "issuer",
					RequireSignedTokens = false,
					IssuerSigningKey = signingKey
				};

				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
			});

			return services;
		}
	}
}
