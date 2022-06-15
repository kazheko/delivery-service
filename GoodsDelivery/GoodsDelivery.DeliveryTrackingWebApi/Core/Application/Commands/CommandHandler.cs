using GoodsDelivery.DeliveryTrackingWebApi.Core.Contracts;
using GoodsDelivery.DeliveryTrackingWebApi.Core.Domain;

namespace GoodsDelivery.DeliveryTrackingWebApi.Core.Application.Commands
{
    public class CommandHandler
    {
        private readonly IDeliveryTrackingRepository _repository;

        public CommandHandler(IDeliveryTrackingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResult> Handle(AddDeliveryTrackingCommand cmd)
        {
            var aggregate = new DeliveryTracking(cmd.QueueId, cmd.DeliveryId);

            await _repository.Create(aggregate);

            return Results.Created($"/{aggregate.TrackNumber}", aggregate);
        }

        public async Task<IResult> Handle(UpdateGeoPositionCommand cmd)
        {
            var aggregate = (await _repository.Read(x => x.QueueId == cmd.QueueId && x.DeliveryId == cmd.DeliveryId)).SingleOrDefault();

            if (aggregate == null)
            {
                return Results.NotFound();
            }

            var position = new Point(cmd.Lat, cmd.Lang);

            aggregate.UpdatePosition(position);

            await _repository.UpdateGeoPosition(aggregate);

            return Results.NoContent();
        }

        public async Task<IResult> Handle(DeleteTrackingCommand cmd)
        {
            var aggregate = (await _repository.Read(x => x.QueueId == cmd.QueueId && x.DeliveryId == cmd.DeliveryId)).SingleOrDefault();

            if (aggregate == null)
            {
                return Results.NotFound();
            }

            await _repository.Delete(aggregate);

            return Results.NoContent();
        }

    }
}
