using HotChocolate;
using HotChocolateWithAspIdentity.Domain.Entities;

namespace HotChocolateWithAspIdentity.GraphQL.GraphQL
{
	[GraphQLDescription("Add Todo List Payload.")]
	public record AddTodoListsPayload(TodoList TodoList);
}
