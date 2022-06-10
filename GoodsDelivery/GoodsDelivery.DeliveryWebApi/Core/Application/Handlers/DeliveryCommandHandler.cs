using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;
using GoodsDelivery.DeliveryWebApi.Core.Domain;

namespace GoodsDelivery.DeliveryWebApi.Core.Application.Handlers
{
    public class DeliveryCommandHandler
    {
        private readonly IDeliveryQueueRepository repository;

        public DeliveryCommandHandler(IDeliveryQueueRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IResult> Handle(CreateDeliveryQueueCommand cmd)
        {
            var aggregate = new DeliveryQueue(cmd.CourierId);

            await repository.Create(aggregate);

            return Results.Created($"/queue/{aggregate.Id}", aggregate);
        }

        public async Task<IResult> Handle(AddDeliveryCommand cmd)
        {
            var queue = (await repository.Read(x => x.Id == cmd.QueueId)).SingleOrDefault();

            if (queue == null) 
            {
                return Results.NotFound();
            }

            var delivery = queue.AddDelivery(cmd.OrderNumber, cmd.CustomerId);

            await repository.AddDelivery(cmd.QueueId, delivery);

            return Results.NoContent();
        }

        public async Task<IResult> Handle(StartDeliveryCommand cmd)
        {
            var queue = (await repository.Read(x => x.Id == cmd.QueueId)).SingleOrDefault();

            if (queue == null)
            {
                return Results.NotFound();
            }

            var delivery = queue.StartDelivery(cmd.DeliveryId);

            if (delivery == null)
            {
                return Results.NotFound();
            }

            await repository.UpdateDelivery(cmd.QueueId, delivery);

            return Results.NoContent();
        }

        public async Task<IResult> Handle(CompleteDeliveryCommand cmd)
        {
            var queue = (await repository.Read(x => x.Id == cmd.QueueId)).SingleOrDefault();

            if (queue == null)
            {
                return Results.NotFound();
            }

            var delivery = queue.CompleteDelivery(cmd.DeliveryId);

            if (delivery == null)
            {
                return Results.NotFound();
            }

            await repository.UpdateDelivery(cmd.QueueId, delivery);

            return Results.NoContent();
        }
    }
}
