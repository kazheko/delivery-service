using GoodsDelivery.CourierWebApi.Core.Domain;
using System.Linq.Expressions;

namespace GoodsDelivery.CourierWebApi.Core.Contracts
{
    public interface ICourierRepository
    {
        Task Create(Courier aggregate);
        Task<IEnumerable<Courier>> Read(Expression<Func<Courier, bool>> filter);
    }
}
