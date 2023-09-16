using Library.Domain.Common;

namespace Library.Domain.Entities;

public class Order : BaseEntity
{
	public Guid UserId { get; set; }
	public DateTime OrderDate { get; set; }
	public decimal TotalAmount { get; set; }
	public string? Status { get; set; }
	public string? PaymentMethod { get; set; }
	public string? ShippingAddress { get; set; }
	public DateTime? ShippingDate { get; set; }
	public User? User { get; set; }
	public List<OrderItem>? Items { get; set; }
}