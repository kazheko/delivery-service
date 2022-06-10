using System.Text.Json;

namespace GoodsDelivery.DeliveryWebApi.Core.Application.Handlers
{
    public record AddDeliveryCommand(string QueueId, string OrderNumber, string CustomerId)
    {
        public static async ValueTask<AddDeliveryCommand?> BindAsync(HttpContext httpContext)
        {
            var id = httpContext.Request.RouteValues["id"] as string;

            if (id == null)
            {
                return null;
            }

            var stream = new StreamReader(httpContext.Request.Body);
            var json = await stream.ReadToEndAsync();
            var cmd = JsonSerializer.Deserialize<AddDeliveryCommand>(json, new JsonSerializerOptions(JsonSerializerDefaults.Web));

            if (cmd == null)
            {
                return null;
            }

            return cmd with { QueueId = id.ToString() };
        }
    }
}
