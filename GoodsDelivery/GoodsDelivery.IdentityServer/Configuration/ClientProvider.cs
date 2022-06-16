using IdentityServer4;
using IdentityServer4.Models;

namespace GoodsDelivery.IdentityServer.Configuration
{
    public static class ClientProvider
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
               {
                    ClientId = "mobile-app",
                    ClientSecrets = new [] { new Secret("mobileappsecret".Sha512()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, "deliveryApi", "deliveryTrackingApi" }
                }
            };
        }
    }
}
