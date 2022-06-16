using Microsoft.AspNetCore.Authorization;

namespace GoodsDelivery.DeliveryTrackingWebApi.Configurations
{
    internal static class SecurityDIExtensions
    {
        private const string IdPConfigSection = "IdentityProvider";
        private const string BearerAuthScheme = "Bearer";

        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new IdPSettings();
            configuration.GetSection(IdPConfigSection).Bind(config);

            services.AddAuthentication(BearerAuthScheme)
                .AddJwtBearer(BearerAuthScheme, options =>
                {
                    options.Audience = config.Audience;
                    options.Authority = config.Authority;
                });

            return services;
        }

        public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                // Register other policies here
            });

            return services;
        }
    }
}
