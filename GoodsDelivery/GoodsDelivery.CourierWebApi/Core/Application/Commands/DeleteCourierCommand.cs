namespace GoodsDelivery.CourierWebApi.Core.Application.Commands
{
    public record DeleteCourierCommand(string Id)
    {
        public static ValueTask<DeleteCourierCommand?> BindAsync(HttpContext httpContext)
        {
            var value = httpContext.Request.RouteValues["id"];

            return value == null 
                ? ValueTask.FromResult<DeleteCourierCommand?>(null) 
                : ValueTask.FromResult<DeleteCourierCommand?>(new DeleteCourierCommand(value.ToString()));
        }
    }
}
