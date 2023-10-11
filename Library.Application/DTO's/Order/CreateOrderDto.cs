using Library.Application.DTO_s.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTO_s.Order
{
    public class CreateOrderDto
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public string? PaymentMethod { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime? ShippingDate { get; set; }
        public List<OrderItemDto>? Items { get; set; }
    }
}
