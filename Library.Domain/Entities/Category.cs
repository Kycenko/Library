using System.ComponentModel.DataAnnotations;
using Library.Domain.Common;

namespace Library.Domain.Entities
{
	public class Category : BaseEntity
	{
		[Key] public Guid CategoryId { get; set; } = Guid.NewGuid();

		[Required(ErrorMessage = "CategoryName is required")]
		public string? CategoryName { get; set; }
	}
}