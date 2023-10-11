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
    public class OrderItemTests
    {
        [Test]
        public void OrderItem_SetProperties_GetPropertiesReturnSameValues()
        {
            // Arrange
            var orderItem = new OrderItem();
            var orderItemId = Guid.NewGuid();
            var orderId = Guid.NewGuid();
            var bookId = Guid.NewGuid();
            var quantity = 2;
            var pricePerUnit = 9.99m;
            var order = new Order();
            var book = new Book();
            var createdDate = DateTime.Now;
            var updatedDate = DateTime.Now;

            // Act
            orderItem.Id = orderItemId;
            orderItem.OrderId = orderId;
            orderItem.BookId = bookId;
            orderItem.Quantity = quantity;
            orderItem.PricePerUnit = pricePerUnit;
            orderItem.Order = order;
            orderItem.Book = book;
            orderItem.CreatedDate = createdDate;
            orderItem.UpdatedDate = updatedDate;

            // Assert
            Assert.That(orderItem.Id, Is.EqualTo(orderItemId));
            Assert.That(orderItem.OrderId, Is.EqualTo(orderId));
            Assert.That(orderItem.BookId, Is.EqualTo(bookId));
            Assert.That(orderItem.Quantity, Is.EqualTo(quantity));
            Assert.That(orderItem.PricePerUnit, Is.EqualTo(pricePerUnit));
            Assert.That(orderItem.Order, Is.EqualTo(order));
            Assert.That(orderItem.Book, Is.EqualTo(book));
            Assert.That(orderItem.CreatedDate, Is.EqualTo(createdDate));
            Assert.That(orderItem.UpdatedDate, Is.EqualTo(updatedDate));
        }
    }
}
