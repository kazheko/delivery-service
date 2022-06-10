using GoodsDelivery.DeliveryWebApi.Core.Application.Handlers;
using GoodsDelivery.DeliveryWebApi.Core.Application.Queries;
using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Configurations;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Persistence.Mapping;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DeliveryCommandHandler>();
builder.Services.AddScoped<DeliveryQueueQueryService>();
builder.Services.AddScoped<IDeliveryQueueRepository, DeliveryRepository>();
builder.Services.Configure<DeliveryDatabaseSettings>(builder.Configuration.GetSection("DeliveryDatabase"));

DeliveryMapping.Configure();

var app = builder.Build();

app.MapGet("/queues", async (DeliveryQueueQueryService queryService) => await queryService.GetAllDeliveryQueues());

app.MapGet("/queues/{id}", async (string id, DeliveryQueueQueryService queryService) => await queryService.GetDeliveryQueueById(id));

app.MapPost("/queues", async (CreateDeliveryQueueCommand cmd, DeliveryCommandHandler handler) => await handler.Handle(cmd));

app.MapPost("/queues/{id}/deliveries", async (AddDeliveryCommand cmd, DeliveryCommandHandler handler) => await handler.Handle(cmd));

app.MapPost("/queues/{queueid}/deliveries/{deliveryid}/start", async (StartDeliveryCommand cmd, DeliveryCommandHandler handler) => await handler.Handle(cmd));

app.MapPost("/queues/{queueid}/deliveries/{deliveryid}/complete", async (CompleteDeliveryCommand cmd, DeliveryCommandHandler handler) => await handler.Handle(cmd));

app.Run();
