using Library.Application.DTO_s.Publisher;
using Library.Application.DTO_s.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTO_s.Book
{
    public class UpdateBookDto
    {
        public string? Title { get; set; }
        public Guid AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public Guid GenreId { get; set; }
        public string? GenreName { get; set; }
        public List<PublisherDto>? Publishers { get; set; }
        public List<ReviewDto>? Reviews { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}
