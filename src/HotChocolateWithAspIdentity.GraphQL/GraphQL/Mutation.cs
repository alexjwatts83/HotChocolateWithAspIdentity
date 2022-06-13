using HotChocolate;
using HotChocolateWithAspIdentity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateWithAspIdentity.GraphQL.GraphQL
{
	public record AddTodoListsPayload(TodoList TodoList);
	[GraphQLDescription("Represents the mutations available.")]
	public class Mutation
	{

	}
}
