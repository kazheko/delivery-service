namespace GoodsDelivery.CourierWebApi.Core.Domain
{
    public record FullName
    {
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string FormattedName => $"{FirstName} {LastName}";
    }
}
