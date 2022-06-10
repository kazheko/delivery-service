namespace GoodsDelivery.DeliveryWebApi.Core.Application.Handlers
{
    public record StartDeliveryCommand(string QueueId, int DeliveryId)
    {
        public static ValueTask<StartDeliveryCommand?> BindAsync(HttpContext httpContext)
        {
            var queueId = httpContext.Request.RouteValues["queueid"] as string;
            var deliveryId = httpContext.Request.RouteValues["deliveryid"] as string;

            if (queueId == null || deliveryId == null)
            {
                return ValueTask.FromResult<StartDeliveryCommand?>(null);
            }

            var cmd = new StartDeliveryCommand(queueId.ToString(), int.Parse(deliveryId));

            return ValueTask.FromResult<StartDeliveryCommand?>(cmd);
        }
    }
}
