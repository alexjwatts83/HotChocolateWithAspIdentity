using HotChocolate;
using HotChocolate.Data;
using HotChocolateWithAspIdentity.Domain.Entities;
using HotChocolateWithAspIdentity.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateWithAspIdentity.GraphQL.GraphQL
{
	[GraphQLDescription("Represents the queries available.")]
	public class Query
	{
		[UseDbContext(typeof(ApplicationDbContext))]
		//[UseFiltering]
		//[UseSorting]
		[GraphQLDescription("Gets the queryable TodoLists.")]
		public IQueryable<TodoList> GetPlatform([ScopedService] ApplicationDbContext context)
		{
			return context.TodoLists;
		}
	}
}
