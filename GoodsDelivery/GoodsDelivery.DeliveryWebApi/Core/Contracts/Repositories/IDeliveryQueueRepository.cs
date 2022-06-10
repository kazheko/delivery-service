using GoodsDelivery.DeliveryWebApi.Core.Domain;
using System.Linq.Expressions;

namespace GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories
{
    public interface IDeliveryQueueRepository
    {
        Task Create(DeliveryQueue aggregate);
        Task<IEnumerable<DeliveryQueue>> Read(Expression<Func<DeliveryQueue, bool>> filter);
        Task AddDelivery(string queueId, Delivery delivery);
        Task UpdateDelivery(string queueId, Delivery delivery);
    }
}
