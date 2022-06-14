using HotChocolate;
using HotChocolate.Data;
using HotChocolateWithAspIdentity.Domain.Entities;
using HotChocolateWithAspIdentity.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotChocolateWithAspIdentity.GraphQL.GraphQL
{
	public record AddTodoItemInput(int ListId, string Title, string Note, bool Done, DateTime? Reminder, PriorityLevel Priority);
}
