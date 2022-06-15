using System.Text.Json;

namespace GoodsDelivery.DeliveryTrackingWebApi.Core.Application.Commands
{
    public record UpdateGeoPositionCommand(string QueueId, int DeliveryId, decimal Lat, decimal Lang)
    {
        public static async ValueTask<UpdateGeoPositionCommand?> BindAsync(HttpContext httpContext)
        {
            var queueId = httpContext.Request.RouteValues["queueid"] as string;
            var deliveryId = httpContext.Request.RouteValues["deliveryid"] as string;

            if (queueId == null || deliveryId == null)
            {
                return await ValueTask.FromResult<UpdateGeoPositionCommand?>(null);
            }

            var stream = new StreamReader(httpContext.Request.Body);
            var json = await stream.ReadToEndAsync();
            var cmd = JsonSerializer.Deserialize<UpdateGeoPositionCommand>(json, new JsonSerializerOptions(JsonSerializerDefaults.Web));

            if (cmd == null)
            {
                return null;
            }

            return cmd with { QueueId = queueId, DeliveryId = int.Parse(deliveryId) };
        }
    }
}
