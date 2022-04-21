using GoodsDelivery.DeliveryWebApi.Core.Application;
using GoodsDelivery.DeliveryWebApi.Core.Contracts.Commands;
using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DeliveryHandler>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.MapPost("/", async (CreateDeliveryCommand cmd, DeliveryHandler handler) =>
{
    var id = await handler.Handle(cmd);
    return Results.Created($"/{id}", null);
});

app.Run();
