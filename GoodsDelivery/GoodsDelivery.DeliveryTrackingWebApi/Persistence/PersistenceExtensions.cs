using GoodsDelivery.DeliveryTrackingWebApi.Core.Domain;
using MongoDB.Bson.Serialization;

namespace GoodsDelivery.DeliveryTrackingWebApi.Persistence
{
    internal static class PersistenceExtensions
    {
        public static IServiceCollection RegisterMongoDbMappings(this IServiceCollection services)
        {
            BsonClassMap.RegisterClassMap<DeliveryTracking>(EntityMappers.MapDeliveryTracking);
            BsonClassMap.RegisterClassMap<Point>(EntityMappers.MapPoint);

            return services;
        }
    }
}
