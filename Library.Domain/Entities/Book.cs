using System.ComponentModel.DataAnnotations;
using Library.Domain.Common;

namespace Library.Domain.Entities
{
	public class Book : BaseEntity
	{
		public string? Title { get; set; }

		public Guid AuthorId { get; set; }

		public Author? Author { get; set; }

		public Genre? Genre { get; set; }

		public Guid GenreId { get; set; }

		public List<Publisher>? Publishers { get; set; }
		
		public List<Review>? Reviews { get; set; }
		
		public decimal Price { get; set; }

		public DateTime PublicationDate { get; set; }
	}
}