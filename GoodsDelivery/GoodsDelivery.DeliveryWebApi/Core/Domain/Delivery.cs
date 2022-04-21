namespace GoodsDelivery.DeliveryWebApi.Core.Domain
{
    public class Delivery
    {
        public Delivery(string id, string number, string courierId, IEnumerable<Order> orders)
        {
            Id = id;
            Number = number;
            CourierId = courierId;
            Orders = orders;
        }

        public string Id { get; private set; }
        public string Number { get; private set; }
        public string CourierId { get; private set; }
        public IEnumerable<Order> Orders { get; private set; }
    }
}
