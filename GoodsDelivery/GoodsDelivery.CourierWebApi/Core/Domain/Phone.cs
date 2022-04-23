using Dawn;

namespace GoodsDelivery.CourierWebApi.Core.Domain
{
    public record Phone
    {
        public Phone(string number)
        {
            Guard.Argument(number)
                .NotNull()
                .NotWhiteSpace()
                .Matches(@"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$");

            Number = number;
        }

        public string Number { get; init; } = null!;
    }
}
