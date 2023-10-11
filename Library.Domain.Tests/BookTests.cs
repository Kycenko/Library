using Library.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void Book_SetProperties_GetPropertiesReturnSameValues()
        {
            // Arrange
            var book = new Book();
            var bookId = Guid.NewGuid();
            var title = "Test Book";
            var authorId = Guid.NewGuid();
            var author = new Author();
            var genreId = Guid.NewGuid();
            var genre = new Genre();
            var publishers = new List<Publisher>();
            var reviews = new List<Review>();
            var price = 9.99m;
            var publicationDate = DateTime.Now;
            var createdDate = DateTime.Now;
            var updatedDate = DateTime.Now;

            // Act
            book.Id = bookId;
            book.Title = title;
            book.AuthorId = authorId;
            book.Author = author;
            book.GenreId = genreId;
            book.Genre = genre;
            book.Publishers = publishers;
            book.Reviews = reviews;
            book.Price = price;
            book.PublicationDate = publicationDate;
            book.CreatedDate = createdDate;
            book.UpdatedDate = updatedDate;

            // Assert
            Assert.That(book.Id, Is.EqualTo(bookId));
            Assert.That(book.Title, Is.EqualTo(title));
            Assert.That(book.AuthorId, Is.EqualTo(authorId));
            Assert.That(book.Author, Is.EqualTo(author));
            Assert.That(book.GenreId, Is.EqualTo(genreId));
            Assert.That(book.Genre, Is.EqualTo(genre));
            Assert.That(book.Publishers, Is.EqualTo(publishers));
            Assert.That(book.Reviews, Is.EqualTo(reviews));
            Assert.That(book.Price, Is.EqualTo(price));
            Assert.That(book.PublicationDate, Is.EqualTo(publicationDate));
            Assert.That(book.CreatedDate, Is.EqualTo(createdDate));
            Assert.That(book.UpdatedDate, Is.EqualTo(updatedDate));

        }
    }
}
