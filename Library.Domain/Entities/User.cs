﻿
using Library.Domain.Common;
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class User : BaseEntity
{
	public string? Login { get; set; }

	public string? FirstName { get; set; }

	public string? LastName { get; set; }
	public string? Email { get; set; }

	public string? PasswordHash { get; set; }

	public UserRole Role { get; set; }
}