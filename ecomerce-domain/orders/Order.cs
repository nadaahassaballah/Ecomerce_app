using ecomerce_domain.common;

namespace ecomerce_domain.orders
{
    public class Order : baseentity<Guid>
    {
        public Order()
        {
        }

        public Order(string buyerEmail, DateTimeOffset orderDate, ICollection<OrderItem> items, OrderAdress shipToAddress, DeliveryMethod deliveryMethod, int deliveryMethodId, OrderStatus status, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            OrderDate = orderDate;
            Items = items;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            DeliveryMethodId = deliveryMethodId;
            Status = status;
            this.subtotal = subtotal;
        }

        public string BuyerEmail { get; private set; } = default!;

        public DateTimeOffset OrderDate { get; private set; } = DateTimeOffset.UtcNow;

        public ICollection<OrderItem> Items { get; private set; } = new List<OrderItem>();

        public OrderAdress ShipToAddress { get; private set; } = default!;

        public DeliveryMethod DeliveryMethod { get; private set; } = default!;

        public int DeliveryMethodId { get; private set; }

        public OrderStatus Status { get; private set; } = OrderStatus.Pending;

        public decimal subtotal { get; private set; } = 0m;

        public string paymentintranetid { get; private set; } = string.Empty;

        public decimal total()
        {
            return subtotal + (DeliveryMethod?.Cost ?? 0m);

        }
        public void MarkPaymentReceoved()=>Status= OrderStatus.PaymentReceived;
        public void MarkPaymentFailed() => Status = OrderStatus.PaymentFailed;

    }
}