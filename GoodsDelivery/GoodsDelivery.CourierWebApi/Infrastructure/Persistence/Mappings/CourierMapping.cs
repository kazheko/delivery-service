using GoodsDelivery.CourierWebApi.Core.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace GoodsDelivery.CourierWebApi.Infrastructure.Persistence.Mappings
{
    public static class CourierMapping
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<Courier>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(x => x.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));

                cm.MapCreator(x => new Courier(x.Id,x.Name, x.PhoneNumber, x.Zones, x.CompanyName, x.IsActive));
            });
        }
    }
}
