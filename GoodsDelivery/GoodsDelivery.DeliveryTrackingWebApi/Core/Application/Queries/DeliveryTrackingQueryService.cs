using GoodsDelivery.DeliveryTrackingWebApi.Core.Contracts;

namespace GoodsDelivery.DeliveryTrackingWebApi.Core.Application.Queries
{
    public class DeliveryTrackingQueryService
    {
        private readonly IDeliveryTrackingRepository _repository;

        public DeliveryTrackingQueryService(IDeliveryTrackingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResult> GetCourierPositionByTrackNumber(string trackNumber)
        {
            var tracker = (await _repository.Read(x => x.TrackNumber == trackNumber)).SingleOrDefault();

            if (tracker == null)
            {
                return Results.NotFound();
            }

            var position = new CourierPositionDto();

            if (tracker.GeoPosition == null)
            {
                var queue = await _repository.Read(x => x.QueueId == tracker.QueueId && x.DeliveryId < tracker.DeliveryId);
                position.InQueueNumber = queue.Count();
            }
            else
            {
                position = new CourierPositionDto { Lang = tracker.GeoPosition?.Lang, Lat = tracker.GeoPosition?.Lat };
            }

            return Results.Ok(position);
        }
    }
}
