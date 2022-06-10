using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;
using GoodsDelivery.DeliveryWebApi.Core.Domain;

namespace GoodsDelivery.DeliveryWebApi.Core.Application.Queries
{
    public class DeliveryQueueQueryService
    {
        private readonly IDeliveryQueueRepository _repository;

        public DeliveryQueueQueryService(IDeliveryQueueRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeliveryQueueDto> GetDeliveryQueueById(string id)
        {
            var deliveries = await _repository.Read(x => x.Id == id);

            return deliveries.Select(Map).Single();
        }

        public async Task<IEnumerable<DeliveryQueueDto>> GetAllDeliveryQueues()
        {
            var deliveries = await _repository.Read(_=>true);

            return deliveries.Select(Map);
        }

        private DeliveryQueueDto Map(DeliveryQueue queue)
        {
            return new DeliveryQueueDto
            {
                Id = queue.Id,
                CourierId = queue.CourierId,
                Deliveries = queue.Deliveries.Select(d => new DeliveryDto
                {
                    Id = d.Id,
                    CustomerId = d.CustomerId,
                    OrderNumber = d.OrderNumber,
                    Status = d.Status.ToString()
                })
            };
        }
    }
}
