namespace GoodsDelivery.DeliveryWebApi.Core.Application.Queries
{
    public class DeliveryQueueDto
    {
        public string Id { get; set; }
        public string CourierId { get; set; } = null!;
        public IEnumerable<DeliveryDto> Deliveries { get; set; } = null!;
    }
}
