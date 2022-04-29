using GoodsDelivery.CourierWebApi.Core.Contracts;
using GoodsDelivery.CourierWebApi.Core.Domain;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace GoodsDelivery.CourierWebApi.Infrastructure.Persistence
{
    public class CourierRepository : ICourierRepository
    {
        private readonly IMongoCollection<Courier> _courierCollection;

        public CourierRepository(IOptions<DatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);

            _courierCollection = mongoDatabase.GetCollection<Courier>(settings.Value.CollectionName);
        }

        public async Task Create(Courier aggregate)
        {
            await _courierCollection.InsertOneAsync(aggregate);
        }

        public async Task<IEnumerable<Courier>> Read(Expression<Func<Courier, bool>> filter)
        {
            return await _courierCollection
                .Find(filter)
                .ToListAsync();
        }

        public async Task Delete(Expression<Func<Courier, bool>> filter)
        {
            await _courierCollection.DeleteManyAsync(filter);
        }

        public async Task Update(Expression<Func<Courier, bool>> filter, Courier courier)
        {
            await _courierCollection.ReplaceOneAsync(filter, courier);
        }
    }
}
