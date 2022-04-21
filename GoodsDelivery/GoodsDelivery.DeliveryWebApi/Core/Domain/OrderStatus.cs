namespace GoodsDelivery.DeliveryWebApi.Core.Domain
{
    public enum OrderStatus
    {
        Shipped = 0,
        InTransit = 1,
        InProgress = 2,
        Delivered = 3,
        Returned = 4,
    }
}
