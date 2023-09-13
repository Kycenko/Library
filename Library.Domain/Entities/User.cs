using System.ComponentModel.DataAnnotations;
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class User
{
	[Required(ErrorMessage = "UserId is required")]
	public Guid UserId { get; set; } = Guid.NewGuid();

	[Required(ErrorMessage = "UserName is required")]
	public string UserName { get; set; }

	[Required(ErrorMessage = "FirstName is required")]
	public string FirstName { get; set; }

	[Required(ErrorMessage = "LastName is required")]
	public string LastName { get; set; }

	[Required(ErrorMessage = "PasswordHash is required")]
	public string PasswordHash { get; set; }

	[Required(ErrorMessage = "Email is required")]
	public string Email { get; set; }

	[Required(ErrorMessage = "Role is required")]
	public UserRole Role { get; set; }

	[Required(ErrorMessage = "CreatedDate is required")]
	public DateTime CreatedDate { get; set; }

	[Required(ErrorMessage = "UpdatedDate is required")]
	public DateTime UpdatedDate { get; set; }
}