using GoodsDelivery.DeliveryWebApi.Core.Contracts.Commands;
using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;
using GoodsDelivery.DeliveryWebApi.Core.Domain;

namespace GoodsDelivery.DeliveryWebApi.Core.Application
{
    public class DeliveryHandler
    {
        IDeliveryRepository repository;

        public DeliveryHandler(IDeliveryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(CreateDeliveryCommand cmd)
        {
            var orders = cmd.Orders
                .Select(x => new Order(x.OrderId, x.SeqNum, x.ClientId, OrderStatus.Shipped));

            var delivery = new Delivery(default(string), cmd.Number, cmd.CourierId, orders);

            await repository.Create(delivery);

            return delivery.Id;
        }
    }
}
