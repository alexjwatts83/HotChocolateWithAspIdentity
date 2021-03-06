using HotChocolateWithAspIdentity.Application.Interfaces;
using HotChocolateWithAspIdentity.Application.Services;
using HotChocolateWithAspIdentity.Infrastructure.Identity;
using HotChocolateWithAspIdentity.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotChocolateWithAspIdentity.Infrastructure
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructureServices(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IApplicationDbContext>(provider =>
				provider.GetService<ApplicationDbContext>());

			services.AddTransient<ApplicationDbContextInitialiser>();

			services.AddDefaultIdentity<ApplicationUser>()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddIdentityServer()
				.AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

			services.AddAuthentication()
				.AddIdentityServerJwt();

			services.AddScoped<IIdentityService, IdentityService>();

			return services;
		}
	}
}
