namespace GoodsDelivery.DeliveryWebApi.Core.Contracts.Commands
{
    public record CreateDeliveryCommand
    {
        public CreateDeliveryCommand(string id, string number, string courierId, 
            IEnumerable<DeliverOrder> orders)
        {
            Id = id;
            Number = number;
            CourierId = courierId;
            Orders = orders;
        }

        public string Id { get; init; }
        public string Number { get; init; }
        public string CourierId { get; init; }
        public IEnumerable<DeliverOrder> Orders { get; init; }
    }

    public record DeliverOrder
    {
        public DeliverOrder(string orderId, int seqNum, string clientId)
        {
            OrderId = orderId;
            SeqNum = seqNum;
            ClientId = clientId;
        }

        public string OrderId { get; init; }
        public int SeqNum { get; init; }
        public string ClientId { get; init; }
    }
}
