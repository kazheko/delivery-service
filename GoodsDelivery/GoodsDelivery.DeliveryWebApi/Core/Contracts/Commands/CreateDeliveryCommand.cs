namespace GoodsDelivery.DeliveryWebApi.Core.Contracts.Commands
{
    public class CreateDeliveryCommand
    {
        public CreateDeliveryCommand(string id, string number, string courierId, IEnumerable<(string, int, string)> orders)
        {
            Id = id;
            Number = number;
            CourierId = courierId;
            Orders = orders;
        }

        public string Id { get; init; }
        public string Number { get; init; }
        public string CourierId { get; init; }
        public IEnumerable<(string,int,string)> Orders { get; init; }
    }
}
