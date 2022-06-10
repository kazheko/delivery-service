namespace GoodsDelivery.DeliveryWebApi.Core.Application.Queries
{
    public class DeliveryDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerId { get; set; }
        public string Status { get; set; }
    }
}
