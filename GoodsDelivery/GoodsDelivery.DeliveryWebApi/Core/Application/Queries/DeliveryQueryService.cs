using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;

namespace GoodsDelivery.DeliveryWebApi.Core.Application.Queries
{
    public class DeliveryQueryService
    {
        private readonly IDeliveryRepository _repository;

        public DeliveryQueryService(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeliveryDto> GetDeliveryById(string id)
        {
            var deliveries = await _repository.Read(x => x.Id == id);

            return deliveries.Select(x => new DeliveryDto
            {
                Id = x.Id,
                CourierId = x.CourierId,
                Number = x.Number,
                Orders = x.Orders.Select(o => new DeliveryOrderDto
                {
                    OrderId = o.OrderId,
                    ClientId = o.ClientId,
                    SeqNum = o.SeqNum,
                    Status = o.Status.ToString()
                })
            }).Single();
        }

        public async Task<IEnumerable<DeliveryDto>> GetAllDeliveries()
        {
            var deliveries = await _repository.Read(_=>true);

            return deliveries.Select(x => new DeliveryDto
            {
                Id = x.Id,
                CourierId = x.CourierId,
                Number = x.Number,
                Orders = x.Orders.Select(o => new DeliveryOrderDto
                {
                    OrderId = o.OrderId,
                    ClientId = o.ClientId,
                    SeqNum = o.SeqNum,
                    Status = o.Status.ToString()
                })
            });
        }
    }
}
