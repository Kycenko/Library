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
    public class AuthorTests
    {
        [Test]
        public void Author_SetAuthorName_GetAuthorNameReturnsSameValue()
        {
            // Arrange
            var author = new Author();
            var authorId = author.Id;
            var authorName = "Test Author";
            var createdDate = DateTime.Now;
            var updatedDate = DateTime.Now;

            // Act
            author.Id = authorId;
            author.AuthorName = authorName;
            author.CreatedDate = createdDate;
            author.UpdatedDate = updatedDate;

            // Assert
            Assert.That(author.Id, Is.EqualTo(authorId));
            Assert.That(author.AuthorName, Is.EqualTo(authorName));
            Assert.That(author.CreatedDate, Is.EqualTo(createdDate));
            Assert.That(author.UpdatedDate, Is.EqualTo(updatedDate));
        }
    }
}
