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
    public class OrderTests
    {
        [Test]
        public void Order_SetProperties_GetPropertiesReturnSameValues()
        {
            // Arrange
            var order = new Order();
            var orderId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var orderDate = DateTime.Now;
            var totalAmount = 100.00m;
            var status = "Pending";
            var paymentMethod = "Credit Card";
            var shippingAddress = "123 Main St";
            var shippingDate = DateTime.Now.AddDays(1);
            var user = new User();
            var items = new List<OrderItem>();
            var createdDate = DateTime.Now;
            var updatedDate = DateTime.Now;

            // Act
            order.Id = orderId;
            order.UserId = userId;
            order.OrderDate = orderDate;
            order.TotalAmount = totalAmount;
            order.Status = status;
            order.PaymentMethod = paymentMethod;
            order.ShippingAddress = shippingAddress;
            order.ShippingDate = shippingDate;
            order.User = user;
            order.Items = items;
            order.CreatedDate = createdDate;
            order.UpdatedDate = updatedDate;

            // Assert
            Assert.That(order.Id, Is.EqualTo(orderId));
            Assert.That(order.UserId, Is.EqualTo(userId));
            Assert.That(order.OrderDate, Is.EqualTo(orderDate));
            Assert.That(order.TotalAmount, Is.EqualTo(totalAmount));
            Assert.That(order.Status, Is.EqualTo(status));
            Assert.That(order.PaymentMethod, Is.EqualTo(paymentMethod));
            Assert.That(order.ShippingAddress, Is.EqualTo(shippingAddress));
            Assert.That(order.ShippingDate, Is.EqualTo(shippingDate));
            Assert.That(order.User, Is.EqualTo(user));
            Assert.That(order.Items, Is.EqualTo(items));
            Assert.That(order.CreatedDate, Is.EqualTo(createdDate));
            Assert.That(order.UpdatedDate, Is.EqualTo(updatedDate));
        }
    }
}
