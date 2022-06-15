using HotChocolate;
using HotChocolateWithAspIdentity.Domain.Entities;
using System;

namespace HotChocolateWithAspIdentity.GraphQL.GraphQL
{
	[GraphQLDescription("Input for adding a todo item.")]
	public record AddTodoItemInput(int ListId, string Title, string Note, bool Done, DateTime? Reminder, PriorityLevel Priority);
}
