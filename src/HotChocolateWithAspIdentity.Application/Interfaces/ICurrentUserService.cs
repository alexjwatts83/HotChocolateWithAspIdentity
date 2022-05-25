﻿using HotChocolateWithAspIdentity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HotChocolateWithAspIdentity.Application.Interfaces
{
	public interface ICurrentUserService
	{
		string UserId { get; }

		// Extend with required data
	}
}
