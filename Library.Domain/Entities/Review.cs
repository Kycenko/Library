using Library.Domain.Common;

namespace Library.Domain.Entities;

public class Review : BaseEntity
{
	public string? Name { get; set; }
	public Guid? UserId { get; set; }
	public User? User { get; set; }
	public Guid? BookId { get; set; }
	public Book? Book { get; set; }
}