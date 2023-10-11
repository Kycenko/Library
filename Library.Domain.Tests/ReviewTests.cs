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
    public class ReviewTests
    {
        [Test]
        public void Review_SetProperties_GetPropertiesReturnSameValues()
        {
            // Arrange
            var review = new Review();
            var reviewId = Guid.NewGuid();
            var name = "Test Review";
            var userId = Guid.NewGuid();
            var user = new User();
            var bookId = Guid.NewGuid();
            var book = new Book();
            var createdDate = DateTime.Now;
            var updatedDate = DateTime.Now;

            // Act
            review.Id = reviewId;
            review.Name = name;
            review.UserId = userId;
            review.User = user;
            review.BookId = bookId;
            review.Book = book;
            review.CreatedDate = createdDate;
            review.UpdatedDate = updatedDate;

            // Assert
            Assert.That(review.Id, Is.EqualTo(reviewId));
            Assert.That(review.Name, Is.EqualTo(name));
            Assert.That(review.UserId, Is.EqualTo(userId));
            Assert.That(review.User, Is.EqualTo(user));
            Assert.That(review.BookId, Is.EqualTo(bookId));
            Assert.That(review.Book, Is.EqualTo(book));
            Assert.That(review.CreatedDate, Is.EqualTo(createdDate));
            Assert.That(review.UpdatedDate, Is.EqualTo(updatedDate));
        }
    }
}
