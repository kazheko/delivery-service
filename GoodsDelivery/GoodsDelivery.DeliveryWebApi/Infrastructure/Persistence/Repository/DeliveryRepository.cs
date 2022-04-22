using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;
using GoodsDelivery.DeliveryWebApi.Core.Domain;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace GoodsDelivery.DeliveryWebApi.Infrastructure.Persistence.Repository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly IMongoCollection<Delivery> _deliveryCollection;

        public DeliveryRepository(IOptions<DeliveryDatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _deliveryCollection = mongoDatabase.GetCollection<Delivery>(settings.Value.DeliveryCollectionName);
        }

        public async Task Create(Delivery aggregate)
        {
            await _deliveryCollection.InsertOneAsync(aggregate);
        }

        public async Task<IEnumerable<Delivery>> Read(Expression<Func<Delivery, bool>> filter)
        {
            return await _deliveryCollection
                .Find(filter)
                .ToListAsync();
        }
    }
}
