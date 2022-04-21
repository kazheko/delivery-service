namespace GoodsDelivery.DeliveryWebApi.Core.Domain
{
    public class Order
    {
        public Order(string orderId, int seqNum, string clientId, OrderStatus status)
        {
            OrderId = orderId;
            SeqNum = seqNum;
            ClientId = clientId;
            Status = status;
        }

        public string OrderId { get; private set; }
        public int SeqNum { get; private set; }
        public string ClientId { get; private set; }
        public OrderStatus Status { get; private set; }
    }
}
