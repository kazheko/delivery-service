using GoodsDelivery.DeliveryTrackingWebApi.Configurations;
using GoodsDelivery.DeliveryTrackingWebApi.Core.Contracts;
using GoodsDelivery.DeliveryTrackingWebApi.Core.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace GoodsDelivery.DeliveryTrackingWebApi.Persistence
{
    public class DeliveryTrackingRepository : IDeliveryTrackingRepository
    {
        private readonly IMongoCollection<DeliveryTracking> _deliveryCollection;

        public DeliveryTrackingRepository(IOptions<DatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _deliveryCollection = mongoDatabase.GetCollection<DeliveryTracking>(settings.Value.CollectionName);
        }

        public async Task Create(DeliveryTracking aggregate)
        {
            await _deliveryCollection.InsertOneAsync(aggregate);
        }

        public async Task<IEnumerable<DeliveryTracking>> Read(Expression<Func<DeliveryTracking, bool>> filter)
        {
            return await _deliveryCollection.Find(filter).ToListAsync();
        }

        public async Task UpdateGeoPosition(DeliveryTracking aggregate)
        {
            var byQueueId = Builders<DeliveryTracking>.Filter.Where(x => x.QueueId == aggregate.QueueId);
            var byDeliveryId = Builders<DeliveryTracking>.Filter.Where(x => x.DeliveryId == aggregate.DeliveryId);

            var update = Builders<DeliveryTracking>.Update.Set(x => x.GeoPosition, aggregate.GeoPosition);

            await _deliveryCollection.UpdateOneAsync(byQueueId & byDeliveryId, update);
        }

        public async Task Delete(DeliveryTracking aggregate)
        {
            await _deliveryCollection.DeleteOneAsync(x => x.QueueId == aggregate.QueueId && x.DeliveryId == aggregate.DeliveryId);
        }
    }
}
