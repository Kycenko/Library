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
    public class GenreTests
    {
        [Test]
        public void Genre_SetProperties_GetPropertiesReturnSameValues()
        {
            // Arrange
            var genre = new Genre();
            var genreId = Guid.NewGuid();
            var genreName = "Test";
            var createdDate = DateTime.Now;
            var updatedDate = DateTime.Now;


            // Act
            genre.Id = genreId;
            genre.GenreName = genreName;
            genre.CreatedDate = createdDate;
            genre.UpdatedDate = updatedDate;

            // Assert
            Assert.That(genreId, Is.EqualTo(genre.Id));
            Assert.That(genreName, Is.EqualTo(genre.GenreName));
            Assert.That(createdDate, Is.EqualTo(genre.CreatedDate));
            Assert.That(updatedDate, Is.EqualTo(genre.UpdatedDate));
        }
    }
}
