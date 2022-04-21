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
            BsonClassMap.RegisterClassMap<Delivery>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(x => x.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));

                cm.MapCreator(p => new Delivery(p.Id, p.Number, p.CourierId, p.Orders));
            });

            BsonClassMap.RegisterClassMap<Order>(cm =>
            {
                cm.AutoMap();
                cm.MapCreator(p => new Order(p.OrderId, p.SeqNum, p.ClientId, p.Status));
            });
        }
    }
}
