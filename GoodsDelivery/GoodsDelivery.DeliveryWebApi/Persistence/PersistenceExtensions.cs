using GoodsDelivery.DeliveryWebApi.Core.Domain;
using MongoDB.Bson.Serialization;

namespace GoodsDelivery.DeliveryWebApi.Persistence
{
    internal static class PersistenceExtensions
    {
        public static IServiceCollection RegisterMongoDbMappings(this IServiceCollection services)
        {
            BsonClassMap.RegisterClassMap<DeliveryQueue>(EntityMappers.MapDeliveryQueue);
            BsonClassMap.RegisterClassMap<Delivery>(EntityMappers.MapDelivery);

            return services;
        }
    }
}
