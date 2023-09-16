using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Library.Domain.Common;
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class User : BaseEntity
{
	public string? Login { get; set; }

	public string? FirstName { get; set; }

	public string? LastName { get; set; }

	public string? PasswordHash { get; set; }

	public UserRole Role { get; set; }
}

public class Admin : User
{
	public string? AdminProperty { get; set; }
}

public class Customer : User
{
	public string? Email { get; set; }
}