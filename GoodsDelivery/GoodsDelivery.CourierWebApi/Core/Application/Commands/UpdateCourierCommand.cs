using System.Text.Json;
using System.Text.Json.Serialization;

namespace GoodsDelivery.CourierWebApi.Core.Application.Commands
{
    public record UpdateCourierCommand
    (
        string Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string[] Zones,
        string CompanyName,
        bool IsActive
    )
    {
        public static async ValueTask<UpdateCourierCommand?> BindAsync(HttpContext httpContext)
        {
            var id = httpContext.Request.RouteValues["id"] as string;

            if (id == null)
            {
                return null;
            }

            var stream = new StreamReader(httpContext.Request.Body);
            var json = await stream.ReadToEndAsync();
            var cmd = JsonSerializer.Deserialize<UpdateCourierCommand>(json, new JsonSerializerOptions(JsonSerializerDefaults.Web));

            if(cmd == null)
            {
                return null;
            }

            return cmd with { Id = id.ToString() };
        }
    }
}
