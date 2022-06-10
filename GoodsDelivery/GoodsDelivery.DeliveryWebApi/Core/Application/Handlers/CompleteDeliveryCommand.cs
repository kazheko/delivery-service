namespace GoodsDelivery.DeliveryWebApi.Core.Application.Handlers
{
    public record CompleteDeliveryCommand(string QueueId, int DeliveryId)
    {
        public static ValueTask<CompleteDeliveryCommand?> BindAsync(HttpContext httpContext)
        {
            var queueId = httpContext.Request.RouteValues["queueid"] as string;
            var deliveryId = httpContext.Request.RouteValues["deliveryid"] as string;

            if (queueId == null || deliveryId == null)
            {
                return ValueTask.FromResult<CompleteDeliveryCommand?>(null);
            }

            var cmd = new CompleteDeliveryCommand(queueId.ToString(), int.Parse(deliveryId));

            return ValueTask.FromResult<CompleteDeliveryCommand?>(cmd);
        }
    }
}
