namespace GoodsDelivery.DeliveryWebApi.Core.Application.Queries
{
    public class DeliveryDto
    {
        public string Id { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string CourierId { get; set; } = null!;
        public IEnumerable<DeliveryOrderDto> Orders { get; set; } = null!;
    }
}
