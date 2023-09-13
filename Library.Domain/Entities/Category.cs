using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
	public class Category
	{
		[Required(ErrorMessage = "CategoryId is required")]
		public Guid CategoryId { get; set; } = Guid.NewGuid();

		[Required(ErrorMessage = "CategoryName is required")]
		public string CategoryName { get; set; }
	}
}