using IdentityServer4.Models;

namespace GoodsDelivery.IdentityServer.Configuration
{
    public static class IdentityResourceProvider
    {
        public static IEnumerable<IdentityResource> Get()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}
