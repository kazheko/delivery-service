using GoodsDelivery.DeliveryTrackingWebApi.Core.Application.Commands;
using GoodsDelivery.DeliveryTrackingWebApi.Core.Application.Queries;
using GoodsDelivery.DeliveryTrackingWebApi.Core.Contracts;
using GoodsDelivery.DeliveryTrackingWebApi.Infrastructure.Configurations;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Persistence.Mapping;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CommandHandler>();
builder.Services.AddScoped<DeliveryTrackingQueryService>();
builder.Services.AddScoped<IDeliveryTrackingRepository, DeliveryTrackingRepository>();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

DeliveryTrackingMapping.Configure();

var app = builder.Build();

app.MapGet("/tracking/{trackNumber}", async (string trackNumber, DeliveryTrackingQueryService service) => await service.GetCourierPositionByTrackNumber(trackNumber));

app.MapPost("/tracking", async (AddDeliveryTrackingCommand cmd, CommandHandler handler) => await handler.Handle(cmd));

app.MapMethods("/tracking/queue/{queueid}/delivery/{deliveryid}", new[] { HttpMethod.Patch.ToString() }, async (UpdateGeoPositionCommand cmd, CommandHandler handler) => await handler.Handle(cmd));

app.MapDelete("/tracking/queue/{queueid}/delivery/{deliveryid}", async (DeleteTrackingCommand cmd, CommandHandler handler) => await handler.Handle(cmd));

app.Run();
