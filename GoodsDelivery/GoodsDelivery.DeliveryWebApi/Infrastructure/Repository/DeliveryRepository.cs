using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;
using GoodsDelivery.DeliveryWebApi.Core.Domain;

namespace GoodsDelivery.DeliveryWebApi.Infrastructure.Repository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        public Task Create(Delivery aggregate)
        {
            return Task.CompletedTask;
        }
    }
}
