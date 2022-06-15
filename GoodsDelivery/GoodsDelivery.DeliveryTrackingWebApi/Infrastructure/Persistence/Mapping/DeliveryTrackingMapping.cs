using GoodsDelivery.DeliveryTrackingWebApi.Core.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace GoodsDelivery.DeliveryWebApi.Infrastructure.Persistence.Mapping
{
    public class DeliveryTrackingMapping
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<DeliveryTracking>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(x => x.TrackNumber)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));

                cm.MapCreator(x => new DeliveryTracking(x.TrackNumber, x.QueueId, x.DeliveryId, x.GeoPosition));
            });

            BsonClassMap.RegisterClassMap<Point>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(x => new Point(x.Lat, x.Lang));
            });
        }
    }
}
