using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities
{
	public class Book
	{
		[Required(ErrorMessage = "BookId is required")]
		public Guid BookId { get; set; } = Guid.NewGuid();

		[Required(ErrorMessage = "Title is required")]
		public string Title { get; set; }

		[Required(ErrorMessage = "AuthorId is required")]
		public Guid AuthorId { get; set; }

		[Required(ErrorMessage = "Author is required")]
		public Author Author { get; set; }

		[Required(ErrorMessage = "Category is required")]
		public Book Category { get; set; }

		[Required(ErrorMessage = "CategoryId is required")]
		public Guid CategoryId { get; set; }

		[Required(ErrorMessage = "Price is required")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "PublicationDate is required")]
		public DateTime PublicationDate { get; set; }
	}
}