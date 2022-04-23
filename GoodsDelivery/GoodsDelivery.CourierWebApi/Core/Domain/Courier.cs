namespace GoodsDelivery.CourierWebApi.Core.Domain
{
    public class Courier
    {
        public Courier(string id, FullName name, Phone phoneNumber, string[] zones, string companyName, bool isActive)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Zones = zones;
            CompanyName = companyName;
            IsActive = isActive;
        }

        public string Id { get; private set; }
        public FullName Name { get; private set; }
        public Phone PhoneNumber { get; private set; }
        public string[] Zones { get; private set; }
        public string CompanyName { get; private set; }
        public bool IsActive { get; private set; }
    }
}
