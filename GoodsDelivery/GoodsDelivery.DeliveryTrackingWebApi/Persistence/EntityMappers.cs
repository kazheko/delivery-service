using GoodsDelivery.DeliveryTrackingWebApi.Core.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace GoodsDelivery.DeliveryTrackingWebApi.Persistence
{
    internal static class EntityMappers
    {
        public static void MapDeliveryTracking(BsonClassMap<DeliveryTracking> map)
        {
            map.AutoMap();
            map.MapIdMember(x => x.TrackNumber)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));

            map.MapCreator(x => new DeliveryTracking(x.TrackNumber, x.QueueId, x.DeliveryId, x.GeoPosition));
        }

        public static void MapPoint(BsonClassMap<Point> map)
        {
            map.AutoMap();
            map.MapCreator(x => new Point(x.Lat, x.Lang));
        }
    }
}
