using GoodsDelivery.DeliveryTrackingWebApi.Core.Domain;
using System.Linq.Expressions;

namespace GoodsDelivery.DeliveryTrackingWebApi.Core.Contracts
{
    public interface IDeliveryTrackingRepository
    {
        Task Create(DeliveryTracking aggregate);
        Task<IEnumerable<DeliveryTracking>> Read(Expression<Func<DeliveryTracking, bool>> filter);
        Task UpdateGeoPosition(DeliveryTracking aggregate);
        Task Delete(DeliveryTracking aggregate);
    }
}
