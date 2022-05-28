using HotChocolateWithAspIdentity.Application.Interfaces;
using HotChocolateWithAspIdentity.Domain.Entities;
using HotChocolateWithAspIdentity.Infrastructure.Identity;
using HotChocolateWithAspIdentity.Infrastructure.Persistence.Interceptors;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotChocolateWithAspIdentity.Infrastructure.Persistence
{
	public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
	{
		private readonly AuditEntitiesSaveChangesInterceptor _auditEntitiesSaveChangesInterceptor;

		public ApplicationDbContext(
			DbContextOptions options,
			IOptions<OperationalStoreOptions> operationalStoreOptions,
			ICurrentUserService currentUserService) : base(options, operationalStoreOptions)
		{
			_auditEntitiesSaveChangesInterceptor = new AuditEntitiesSaveChangesInterceptor(currentUserService);
		}

		public DbSet<TodoList> TodoLists { get; set; }

		public DbSet<TodoItem> TodoItems { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.EnableDetailedErrors()
				.LogTo(Console.WriteLine);

			optionsBuilder.AddInterceptors(_auditEntitiesSaveChangesInterceptor);

			base.OnConfiguring(optionsBuilder);
		}
	}
}
