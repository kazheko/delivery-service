using IdentityServer4.Models;

namespace GoodsDelivery.IdentityServer.Configuration
{
    internal static class ApiResourceProvider
    {
        public static IEnumerable<ApiResource> Get()
        {
            return new[]
            {
                new ApiResource("deliveryApi")
                {
                    Scopes = new List<string>{ "deliveryApi" }
                },
                new ApiResource("deliveryTrackingApi")
                {
                    Scopes = new List<string>{ "deliveryTrackingApi" }
                }
            };
        }
    }
}
