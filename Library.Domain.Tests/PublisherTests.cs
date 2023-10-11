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
    public class PublisherTests
    {
        [Test]
        public void Publisher_SetProperties_GetPropertiesReturnSameValues()
        {
            // Arrange
            var publisher = new Publisher();
            var publisherId = Guid.NewGuid();
            var publisherName = "Test Publisher";
            var createdDate = DateTime.Now;
            var updatedDate = DateTime.Now;

            // Act
            publisher.Id = publisherId;
            publisher.PublisherName = publisherName;
            publisher.CreatedDate = createdDate;
            publisher.UpdatedDate = updatedDate;

            // Assert
            Assert.That(publisher.Id, Is.EqualTo(publisherId));
            Assert.That(publisher.PublisherName, Is.EqualTo(publisherName));
            Assert.That(publisher.CreatedDate, Is.EqualTo(createdDate));
            Assert.That(publisher.UpdatedDate, Is.EqualTo(updatedDate));
        }
    }
}
