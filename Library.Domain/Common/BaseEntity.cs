namespace Library.Domain.Common;

public abstract class BaseEntity
{
	Guid Id { get; set; }
	DateTime CreatedDate { get; set; }
	DateTime? UpdatedDate { get; set; }
	DateTime? DeletedDate { get; set; }
}