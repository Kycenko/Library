
namespace Library.Domain.Entities;

public class User 
{

	public Guid Id { get; set; }
	public string? UserName { get; set; }
	public string? UserPassword { get; set; }
	public string? UserEmail { get; set; }
	public DateTime? CreatedDate { get; set; }
	public DateTime? UpdatedDate { get; set; }
}