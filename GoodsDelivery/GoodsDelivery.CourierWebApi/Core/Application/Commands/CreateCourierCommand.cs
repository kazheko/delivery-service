namespace GoodsDelivery.CourierWebApi.Core.Application.Commands
{
    public record CreateCourierCommand
    (
        string FirstName,
        string LastName,
        string PhoneNumber,
        string[] Zones,
        string CompanyName,
        bool IsActive
    );
}
