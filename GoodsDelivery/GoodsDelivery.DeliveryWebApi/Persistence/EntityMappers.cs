using GoodsDelivery.DeliveryWebApi.Core.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace GoodsDelivery.DeliveryWebApi.Persistence
{
    internal static class EntityMappers
    {
        public static void MapDeliveryQueue(BsonClassMap<DeliveryQueue> mapper)
        {
            mapper.AutoMap();
            mapper.MapIdMember(x => x.Id)
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.ObjectId));

            mapper.MapCreator(q => new DeliveryQueue(q.Id, q.CourierId, q.Deliveries));
        }

        public static void MapDelivery(BsonClassMap<Delivery> mapper)
        {
            mapper.AutoMap();
            mapper.MapCreator(d => new Delivery(d.Id, d.OrderNumber, d.CustomerId, d.Status));
        }
    }
}
