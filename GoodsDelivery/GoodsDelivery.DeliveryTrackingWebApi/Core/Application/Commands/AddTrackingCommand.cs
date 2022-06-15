namespace GoodsDelivery.DeliveryTrackingWebApi.Core.Application.Commands
{
    public record AddDeliveryTrackingCommand(string QueueId, int DeliveryId);
}
