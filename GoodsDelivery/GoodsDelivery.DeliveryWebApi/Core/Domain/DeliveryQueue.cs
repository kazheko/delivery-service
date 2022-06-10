using Dawn;

namespace GoodsDelivery.DeliveryWebApi.Core.Domain
{
    public class DeliveryQueue
    {
        public DeliveryQueue(string courierId)
        {
            Guard.Argument(courierId)
                .NotNull().NotWhiteSpace();

            CourierId = courierId;
            Deliveries = new List<Delivery>();
        }

        public DeliveryQueue(string id, string courierId, ICollection<Delivery> deliveries)
        {
            Id = id;
            CourierId = courierId;
            Deliveries = deliveries;
        }

        public string? Id { get; private set; }
        public string CourierId { get; private set; }
        public ICollection<Delivery> Deliveries { get; private set; }

        public Delivery AddDelivery(string orderNumber, string customerId)
        {
            var delivery = new Delivery(Deliveries.Count + 1, orderNumber, customerId);
            Deliveries.Add(delivery);
            return delivery;
        }

        public Delivery? StartDelivery(int deliveryId)
        {
            var delivery = Deliveries.SingleOrDefault(x => x.Id == deliveryId);

            if (delivery == null)
            {
                return null;
            }

            delivery.Start();
            return delivery;
        }

        public Delivery? CompleteDelivery(int deliveryId)
        {
            var delivery = Deliveries.SingleOrDefault(x => x.Id == deliveryId);

            if (delivery == null)
            {
                return null;
            }

            delivery.Complete();
            return delivery;        
        }
    }
}
