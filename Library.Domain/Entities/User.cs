using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class User
{
	public Guid UserId { get; set; }
	public string? UserName { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? PasswordHash { get; set; }
	public string? Email { get; set; }
	public UserRole Role { get; set; }
 	public DateTime? CreatedDate { get; set; }
	public DateTime? UpdatedDate { get; set; }
}