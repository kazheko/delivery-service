using GoodsDelivery.DeliveryWebApi.Core.Domain;

namespace GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories
{
    public interface IDeliveryRepository
    {
        Task Create(Delivery aggregate);
    }
}
