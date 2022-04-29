﻿namespace GoodsDelivery.CourierWebApi.Core.Application.Commands
{
    public record UpdateCourierCommand
    (
        string Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string[] Zones,
        string CompanyName,
        bool IsActive
    );
}
