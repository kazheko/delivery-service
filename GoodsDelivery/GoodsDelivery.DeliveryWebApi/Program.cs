using GoodsDelivery.DeliveryWebApi.Configurations;
using GoodsDelivery.DeliveryWebApi.Core.Application.Handlers;
using GoodsDelivery.DeliveryWebApi.Core.Application.Queries;
using GoodsDelivery.DeliveryWebApi.Core.Contracts.Repositories;
using GoodsDelivery.DeliveryWebApi.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DeliveryCommandHandler>();
builder.Services.AddScoped<DeliveryQueueQueryService>();
builder.Services.AddScoped<IDeliveryQueueRepository, DeliveryRepository>();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddAuthenticationServices(builder.Configuration);
builder.Services.AddAuthorizationServices();
builder.Services.RegisterMongoDbMappings();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/queues", async (DeliveryQueueQueryService queryService) => await queryService.GetAllDeliveryQueues());

app.MapGet("/queues/{id}", async (string id, DeliveryQueueQueryService queryService) => await queryService.GetDeliveryQueueById(id));

app.MapPost("/queues", async (CreateDeliveryQueueCommand cmd, DeliveryCommandHandler handler) => await handler.Handle(cmd));

app.MapPost("/queues/{id}/deliveries", async (AddDeliveryCommand cmd, DeliveryCommandHandler handler) => await handler.Handle(cmd));

app.MapPost("/queues/{queueid}/deliveries/{deliveryid}/start", async (StartDeliveryCommand cmd, DeliveryCommandHandler handler) => await handler.Handle(cmd));

app.MapPost("/queues/{queueid}/deliveries/{deliveryid}/complete", async (CompleteDeliveryCommand cmd, DeliveryCommandHandler handler) => await handler.Handle(cmd));

app.Run();
