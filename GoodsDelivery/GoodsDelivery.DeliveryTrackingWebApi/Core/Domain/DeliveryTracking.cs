namespace GoodsDelivery.DeliveryTrackingWebApi.Core.Domain
{
    public class DeliveryTracking
    {
        public DeliveryTracking(string queueId, int deliveryId)
        {
            QueueId = queueId;
            DeliveryId = deliveryId;
        }

        public DeliveryTracking(string? trackNumber, string queueId, int deliveryId, Point? geoPosition)
            : this(queueId, deliveryId)
        {
            TrackNumber = trackNumber;
            GeoPosition = geoPosition;
        }

        public string? TrackNumber { get; private set; }
        public string QueueId { get; private set; }   
        public int DeliveryId { get; private set; }
        public Point? GeoPosition { get; private set; }

        public void UpdatePosition(Point geoPosition)
        {
            GeoPosition = geoPosition;
        }
    }
}
