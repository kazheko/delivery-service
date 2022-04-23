using GoodsDelivery.CourierWebApi.Core.Domain;

namespace GoodsDelivery.CourierWebApi.Core.Contracts
{
    public interface ICourierRepository
    {
        Task Create(Courier aggregate);
    }
}
