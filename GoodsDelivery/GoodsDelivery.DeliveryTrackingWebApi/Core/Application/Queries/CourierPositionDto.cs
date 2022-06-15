namespace GoodsDelivery.DeliveryTrackingWebApi.Core.Application.Queries
{
    public class CourierPositionDto
    {
        public int InQueueNumber { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lang { get; set; }
    }
}
