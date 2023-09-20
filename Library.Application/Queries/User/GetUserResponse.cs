﻿using Library.Domain.Enums;

namespace Library.Application.Queries.User;

public sealed record GetUserResponse
{
	public Guid Id { get; set; }
	public string? Login { get; set; }

	public string? FirstName { get; set; }

	public string? LastName { get; set; }
	public string? Email { get; set; }

	public string? PasswordHash { get; set; }

	public UserRole Role { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime? UpdatedDate { get; set; }
}