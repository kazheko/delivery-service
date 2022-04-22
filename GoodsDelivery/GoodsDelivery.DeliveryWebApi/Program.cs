using GoodsDelivery.DeliveryWebApi.Core.Application.Handlers;
using GoodsDelivery.DeliveryWebApi.Core.Application.Queries;
using GoodsDelivery.DeliveryWebApi.Core.Contracts.Commands;
using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Configurations;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Persistence.Mapping;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DeliveryCommandHandler>();
builder.Services.AddScoped<DeliveryQueryService>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.Configure<DeliveryDatabaseSettings>(builder.Configuration.GetSection("DeliveryDatabase"));

DeliveryMapping.Configure();

var app = builder.Build();

app.MapGet("/deliveries/{id}", (string id, DeliveryQueryService query) => query.GetDeliveryById(id));

app.MapGet("/deliveries", (DeliveryQueryService query) => query.GetAllDeliveries());

app.MapPost("/deliveries", async (CreateDeliveryCommand cmd, DeliveryCommandHandler handler) =>
{
    var id = await handler.Handle(cmd);
    return Results.Created($"/{id}", null);
});

app.Run();
