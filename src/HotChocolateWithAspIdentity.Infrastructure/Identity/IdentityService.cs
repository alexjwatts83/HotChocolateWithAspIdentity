using HotChocolateWithAspIdentity.Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotChocolateWithAspIdentity.Infrastructure.Identity
{
	public class IdentityService : IIdentityService
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public IdentityService(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<string> GetUserNameAsync(string userId)
		{
			var user = await _userManager.Users.FirstAsync(u =>
				u.Id == userId);

			return user.UserName;
		}

		public async Task<(Result Result, string UserId)> CreateUserAsync(
			string userName, string password)
		{
			var user = new ApplicationUser
			{
				UserName = userName,
				Email = userName,
			};

			var result = await _userManager.CreateAsync(user, password);

			return (result.ToApplicationResult(), user.Id);
		}

		public async Task<Result> DeleteUserAsync(string userId)
		{
			var user = _userManager.Users.SingleOrDefault(u =>
				u.Id == userId);

			if (user != null)
			{
				return await DeleteUserAsync(user);
			}

			return Result.Success();
		}

		private async Task<Result> DeleteUserAsync(ApplicationUser user)
		{
			var result = await _userManager.DeleteAsync(user);

			return result.ToApplicationResult();
		}

		public async Task<string> Authenticate(string email, string password)
		{
			throw new System.NotImplementedException();
		}

		private string GenerateAccessToken(string email, string userId, string[] roles)
		{
			var key = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes("secretsecretsecret"));

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, userId),
				new Claim(ClaimTypes.Name, email)
			};

			claims = claims.Concat(roles.Select(role => new Claim(ClaimTypes.Role, role))).ToList();


			var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				"issuer",
				"audience",
				claims,
				expires: DateTime.Now.AddDays(90),
				signingCredentials: signingCredentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}

	public static class IdentityResultExtensions
	{
		public static Result ToApplicationResult(this IdentityResult result)
		{
			return result.Succeeded
				? Result.Success()
				: Result.Failure(result.Errors.Select(e => e.Description));
		}
	}
}
