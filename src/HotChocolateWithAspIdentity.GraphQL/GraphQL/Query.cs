using HotChocolate;
using HotChocolate.Data;
using HotChocolateWithAspIdentity.Domain.Entities;
using HotChocolateWithAspIdentity.Infrastructure.Persistence;
using System.Linq;

namespace HotChocolateWithAspIdentity.GraphQL.GraphQL
{
	[GraphQLDescription("Represents the queries available.")]
	public class Query
	{
		[UseDbContext(typeof(ApplicationDbContext))]
		[GraphQLDescription("Gets the queryable TodoLists.")]
		public IQueryable<TodoList> GetTodoLists([ScopedService] ApplicationDbContext context)
		{
			return context.TodoLists;
		}
	}
}
