

namespace Library.Domain.Entities
{
    public class Book 
    {
        public Guid BookId { get; set; }
        public string? BookName { get; set; }
        public string? BookAuthor { get; set; }
        public int PublishYear { get; set; }
        public string? Category { get; set; }
    
    }
}
