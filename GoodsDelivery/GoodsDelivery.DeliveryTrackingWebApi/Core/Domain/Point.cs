namespace GoodsDelivery.DeliveryTrackingWebApi.Core.Domain
{
    public class Point
    {
        public Point(decimal lat, decimal lang)
        {
            Lat = lat;
            Lang = lang;
        }

        public decimal Lat { get; private set; }
        public decimal Lang { get; private set; }
    }
}
