namespace GoodsDelivery.CourierWebApi.Core.Application.Queries
{
    public class CourierViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string[] Zones { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; }
    }
}
