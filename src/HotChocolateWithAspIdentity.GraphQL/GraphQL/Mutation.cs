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
	public record AddCommandInput(string Title, string Colour);
	public record AddTodoListsPayload(TodoList TodoList);
	[GraphQLDescription("Represents the mutations available.")]
	public class Mutation
	{
		//[UseDbContext(typeof(ApplicationDbContext))]
		//[GraphQLDescription("Adds a command.")]
		//public async Task<AddTodoListsPayload> AddToListItemAsync(AddTodoListsPayload input, [ScopedService] ApplicationDbContext context)
		//{
		//	var command = new Command
		//	{
		//		HowTo = input.HowTo,
		//		CommandLine = input.CommandLine,
		//		PlatformId = input.PlatformId
		//	};

		//	context.Commands.Add(command);
		//	await context.SaveChangesAsync();

		//	return new AddCommandPayload(command);
		//}
	}
}
