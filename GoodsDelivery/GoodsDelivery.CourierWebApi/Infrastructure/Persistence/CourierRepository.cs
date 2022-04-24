using GoodsDelivery.CourierWebApi.Core.Contracts;
using GoodsDelivery.CourierWebApi.Core.Domain;

namespace GoodsDelivery.CourierWebApi.Infrastructure.Persistence
{
    public class CourierRepository : ICourierRepository
    {
        public Task Create(Courier aggregate)
        {
            return Task.CompletedTask;
        }
    }
}
