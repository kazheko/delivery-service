using Dawn;

namespace GoodsDelivery.DeliveryWebApi.Core.Domain
{
    public class Delivery
    {
        public Delivery(int id, string orderNumber, string customerId)
        {
            Guard.Argument(orderNumber)
                .NotNull().NotWhiteSpace();

            Guard.Argument(customerId)
                .NotNull().NotWhiteSpace();

            Id = id;
            OrderNumber = orderNumber;
            CustomerId = customerId;
            Status = DeliveryStatus.Awaiting;
        }

        public Delivery(int id, string orderNumber, string customerId, DeliveryStatus status)
        {
            Id = id;
            OrderNumber = orderNumber;
            CustomerId = customerId;
            Status = status;
        }

        public int Id { get; private set; }
        public string OrderNumber { get; private set; }
        public string CustomerId { get; private set; }
        public DeliveryStatus Status { get; private set; }

        public void Start()
        {
            Status = DeliveryStatus.InProgress;
        }

        public void Complete()
        {
            Status = DeliveryStatus.Сompleted;
        }
    }
}
