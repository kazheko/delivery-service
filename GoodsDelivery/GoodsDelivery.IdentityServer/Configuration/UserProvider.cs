using IdentityModel;
using IdentityServer4.Test;
using System.Security.Claims;

namespace GoodsDelivery.IdentityServer.Configuration
{
    public static class UserProvider
    {
        public static IEnumerable<TestUser> Get()
        {
            return new[]
            {
                new TestUser{
                    SubjectId = Guid.NewGuid().ToString(),
                    Username = "john",
                    Password = "johnpass",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "John Doe"),
                    }
                },
                new TestUser
                {
                    SubjectId = Guid.NewGuid().ToString(),
                    Username = "courier2",
                    Password = "pass2",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "Jonathon Smith"),
                    }
                }
            };
        }
    }
}
