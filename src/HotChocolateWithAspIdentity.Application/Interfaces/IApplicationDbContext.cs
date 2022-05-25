using HotChocolateWithAspIdentity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolateWithAspIdentity.Application.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<TodoList> TodoLists { get; set; }

		DbSet<TodoItem> TodoItems { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
