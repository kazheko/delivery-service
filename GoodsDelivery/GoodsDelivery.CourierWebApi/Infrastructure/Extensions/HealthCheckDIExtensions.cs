using GoodsDelivery.DeliveryWebApi.Infrastructure.Configurations;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GoodsDelivery.CourierWebApi.Infrastructure.Extensions
{
    public static class HealthCheckDIExtensions
    {
        public static IServiceCollection AddReadinessHealthChecks(this IServiceCollection service, 
            IConfigurationSection dbSection, params string[] tags)
        {
            if(dbSection == null)
            {
                throw new ArgumentNullException(nameof(dbSection));
            }

            var settings = dbSection.Get<DatabaseSettings>();

            service.AddHealthChecks()
                .AddMongoDb(settings.ConnectionString, mongoDatabaseName: settings.DatabaseName, tags: tags);

            return service;
        }

        public static IServiceCollection AddLiveHealthChecks(this IServiceCollection service, params string[] tags)
        {
            service.AddHealthChecks()
                .AddCheck("LiveHealthCheck", () => HealthCheckResult.Healthy(), tags);

            return service;
        }
    }
}
