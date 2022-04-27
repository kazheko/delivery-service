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

        public async Task<IEnumerable<Courier>> Read(string id)
        {
            return await _courierCollection
                .Find(x=>x.Id == id)
                .ToListAsync();
        }

        public async Task Delete(string id)
        {
            await _courierCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
