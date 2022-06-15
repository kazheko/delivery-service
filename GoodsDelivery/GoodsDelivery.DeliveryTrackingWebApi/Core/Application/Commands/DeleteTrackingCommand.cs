namespace GoodsDelivery.DeliveryTrackingWebApi.Core.Application.Commands
{
    public record DeleteTrackingCommand(string QueueId, int DeliveryId)
    {
        public static ValueTask<DeleteTrackingCommand?> BindAsync(HttpContext httpContext)
        {
            var queueId = httpContext.Request.RouteValues["queueid"] as string;
            var deliveryId = httpContext.Request.RouteValues["deliveryid"] as string;

            if (queueId == null || deliveryId == null)
            {
                return ValueTask.FromResult<DeleteTrackingCommand?>(null);
            }

            var cmd = new DeleteTrackingCommand(queueId.ToString(), int.Parse(deliveryId));

            return ValueTask.FromResult<DeleteTrackingCommand?>(cmd);
        }
    }
}
