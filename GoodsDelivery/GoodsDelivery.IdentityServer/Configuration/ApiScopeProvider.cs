using IdentityServer4.Models;

namespace GoodsDelivery.IdentityServer.Configuration
{
    internal static class ApiScopeProvider
    {
        public static IEnumerable<ApiScope> Get()
        {
            return new[]
            {
                new ApiScope("deliveryApi"),
                new ApiScope("deliveryTrackingApi")
            };
        }
    }
}
