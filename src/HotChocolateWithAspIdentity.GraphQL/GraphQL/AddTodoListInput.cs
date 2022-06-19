using HotChocolate;
using System.Collections.Generic;

namespace HotChocolateWithAspIdentity.GraphQL.GraphQL
{
	[GraphQLDescription("Input for adding a todo listAdde.")]
	public record AddTodoListInput(string Title, string Colour, IEnumerable<AddTodoItemInput> Items);
}
