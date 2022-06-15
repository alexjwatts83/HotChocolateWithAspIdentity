using HotChocolate;
using HotChocolateWithAspIdentity.Domain.Entities;

namespace HotChocolateWithAspIdentity.GraphQL.GraphQL
{
	[GraphQLDescription("Todo List PayloadAdd.")]
	public record AddTodoListsPayload(TodoList TodoList);
}
