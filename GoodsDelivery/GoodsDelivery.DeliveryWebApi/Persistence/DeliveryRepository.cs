using GoodsDelivery.DeliveryWebApi.Configurations;
using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;
using GoodsDelivery.DeliveryWebApi.Core.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace GoodsDelivery.DeliveryWebApi.Persistence
{
    public class DeliveryRepository : IDeliveryQueueRepository
    {
        private readonly IMongoCollection<DeliveryQueue> _deliveryCollection;

        public DeliveryRepository(IOptions<DeliveryDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _deliveryCollection = mongoDatabase.GetCollection<DeliveryQueue>(settings.Value.DeliveryCollectionName);
        }

        public async Task AddDelivery(string queueId, Delivery delivery)
        {
            var where = Builders<DeliveryQueue>.Filter.Where(x => x.Id == queueId);
            var update = Builders<DeliveryQueue>.Update.Push(x => x.Deliveries, delivery);

            await _deliveryCollection.UpdateOneAsync(where, update);
        }

        public async Task Create(DeliveryQueue aggregate)
        {
            await _deliveryCollection.InsertOneAsync(aggregate);
        }

        public async Task<IEnumerable<DeliveryQueue>> Read(Expression<Func<DeliveryQueue, bool>> filter)
        {
            return await _deliveryCollection
                .Find(filter)
                .ToListAsync();
        }

        public async Task UpdateDelivery(string queueId, Delivery delivery)
        {
            var byQueueId = Builders<DeliveryQueue>.Filter.Where(x => x.Id == queueId);

            var byDeliveryId = Builders<DeliveryQueue>.Filter.ElemMatch(x => x.Deliveries, x => x.Id == delivery.Id);

            // https://www.mattburkedev.com/updating-inside-a-nested-array-with-the-mongodb-positional-operator-in-c-number/
            var update = Builders<DeliveryQueue>.Update.Set(x => x.Deliveries.ElementAt(-1), delivery);

            await _deliveryCollection.UpdateOneAsync(byQueueId & byDeliveryId, update);
        }
    }
}
