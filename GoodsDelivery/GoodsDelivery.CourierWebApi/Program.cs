using GoodsDelivery.CourierWebApi.Core.Application.Commands;
using GoodsDelivery.CourierWebApi.Core.Application.Queries;
using GoodsDelivery.CourierWebApi.Core.Contracts;
using GoodsDelivery.CourierWebApi.Infrastructure.Persistence;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CourierCommandHandler>();
builder.Services.AddScoped<CourierQueryService>();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("CourierDatabase"));

var app = builder.Build();

app.MapPost("/couriers", async (CreateCourierCommand cmd, CourierCommandHandler handler) =>
{
    var id = await handler.Handle(cmd);
    return Results.Created($"/couriers/{id}", null);
});

app.MapGet("/couriers", async (CourierQueryService service) => await service.GetAllCouriers());

app.MapGet("/couriers/{id}", async (string id, CourierQueryService service) => await service.GetCourierDetails(id));


app.Run();
