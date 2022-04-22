using GoodsDelivery.DeliveryWebApi.Core.Domain;
using System.Linq.Expressions;

namespace GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories
{
    public interface IDeliveryRepository
    {
        Task Create(Delivery aggregate);
        Task<IEnumerable<Delivery>> Read(Expression<Func<Delivery, bool>> filter);
    }
}
