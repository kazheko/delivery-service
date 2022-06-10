using GoodsDelivery.DeliveryWebApi.Core.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace GoodsDelivery.DeliveryWebApi.Infrastructure.Persistence.Mapping
{
    public class DeliveryMapping
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<DeliveryQueue>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(x => x.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));

                cm.MapCreator(q => new DeliveryQueue(q.Id, q.CourierId, q.Deliveries));
            });

            BsonClassMap.RegisterClassMap<Delivery>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(d => new Delivery(d.Id, d.OrderNumber, d.CustomerId, d.Status));
            });
        }
    }
}
