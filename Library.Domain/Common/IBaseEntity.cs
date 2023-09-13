namespace Library.Domain.Common;

public interface IBaseEntity
{
	Guid Id { get; set; }
	DateTime CreatedDate { get; set; }
	DateTime? UpdatedDate { get; set; }
	DateTime? DeletedDate { get; set; }
}