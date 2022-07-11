﻿namespace GoodsDelivery.DeliveryWebApi.Infrastructure.Configurations
{
    public class DeliveryDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string DeliveryCollectionName { get; set; } = null!;
    }
}
