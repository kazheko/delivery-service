namespace GoodsDelivery.DeliveryWebApi.Core.Application.Queries
{
    public class DeliveryOrderDto
    {
        public string OrderId { get; set; }
        public int SeqNum { get; set; }
        public string ClientId { get; set; }
        public string Status { get; set; }
    }
}
