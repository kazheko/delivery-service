using GoodsDelivery.CourierWebApi.Core.Application.Commands;
using GoodsDelivery.CourierWebApi.Core.Application.Queries;
using GoodsDelivery.CourierWebApi.Core.Contracts;
using GoodsDelivery.CourierWebApi.Infrastructure.Extensions;
using GoodsDelivery.CourierWebApi.Infrastructure.Persistence;
using GoodsDelivery.CourierWebApi.Infrastructure.Persistence.Mappings;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Configurations;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

const string healthCheckTagReady = "ready", healthCheckTagLive = "live";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICourierRepository, CourierRepository>();
builder.Services.AddScoped<CourierCommandHandler>();
builder.Services.AddScoped<CourierQueryService>();

CourierMapping.Register();

var dbSection = builder.Configuration.GetSection("CourierDatabase");
builder.Services.Configure<DatabaseSettings>(dbSection);

builder.Services.AddReadinessHealthChecks(dbSection, healthCheckTagReady);
builder.Services.AddLiveHealthChecks(healthCheckTagLive);

var app = builder.Build();

app.MapPost("/couriers", async (CreateCourierCommand cmd, CourierCommandHandler handler) => await handler.Handle(cmd));

app.MapGet("/couriers", async (CourierQueryService service) => await service.GetAllCouriers());

app.MapGet("/couriers/{id}", async (string id, CourierQueryService service) => await service.GetCourierDetails(id));

app.MapDelete("/couriers/{id}", async (DeleteCourierCommand cmd, CourierCommandHandler handler) => await handler.Handle(cmd));

app.MapPut("/couriers/{id}", async (UpdateCourierCommand cmd, CourierCommandHandler handler) => await handler.Handle(cmd));

app.MapHealthChecks("/health/live", new HealthCheckOptions { Predicate = x => x.Tags.Contains(healthCheckTagLive) });

app.MapHealthChecks("/health/ready", new HealthCheckOptions { Predicate = x => x.Tags.Contains(healthCheckTagReady) });

app.Run();
