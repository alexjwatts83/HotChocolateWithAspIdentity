﻿using HotChocolate;
using HotChocolate.Data;
using HotChocolateWithAspIdentity.Domain.Entities;
using HotChocolateWithAspIdentity.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;

namespace HotChocolateWithAspIdentity.GraphQL.GraphQL
{
	public record AddTodoItemInput(int ListId, string Title, string Note, bool Done, DateTime? Reminder, PriorityLevel Priority);
	public record AddTodoListInput(string Title, string Colour);
	public record AddTodoListsPayload(TodoList TodoList);
	[GraphQLDescription("Represents the mutations available.")]
	public class Mutation
	{
		[UseDbContext(typeof(ApplicationDbContext))]
		[GraphQLDescription("Add a single Todo List with no items.")]
		public async Task<AddTodoListsPayload> AddToListItemAsync(AddTodoListInput input, [ScopedService] ApplicationDbContext context)
		{
			var item = new TodoList
			{
				Title = input.Title,
				Colour = input.Colour
			};

			context.TodoLists.Add(item);
			await context.SaveChangesAsync();

			return new AddTodoListsPayload(item);
		}
	}
}
