namespace Library.Domain.Entities
{
	public class Book
	{
		public Guid BookId { get; set; }
		public string? Title { get; set; }
		public Guid? AuthorId { get; set; }
		public Author? Author { get; set; }
		public Book Category { get; set; }
		
		public Guid? CategoryId { get; set; }
		public decimal? Price { get; set; }
		public DateTime? PublicationDate { get; set; }
	}
}