using HotChocolate;
using HotChocolateWithAspIdentity.Domain.Entities;

namespace HotChocolateWithAspIdentity.GraphQL.GraphQL
{
	[GraphQLDescription("Add Todo List Item Payload.")]
	public record AddTodoItemPayload(TodoItem TodoItem);
}
