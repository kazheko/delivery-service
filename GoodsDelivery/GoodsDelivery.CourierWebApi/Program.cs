using GoodsDelivery.CourierWebApi.Core.Application.Commands;
using GoodsDelivery.CourierWebApi.Core.Application.Queries;
using GoodsDelivery.CourierWebApi.Core.Contracts;
using GoodsDelivery.CourierWebApi.Infrastructure.Persistence;
using GoodsDelivery.CourierWebApi.Infrastructure.Persistence.Mappings;
using GoodsDelivery.DeliveryWebApi.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICourierRepository, CourierRepository>();
builder.Services.AddScoped<CourierCommandHandler>();
builder.Services.AddScoped<CourierQueryService>();
CourierMapping.Register();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("CourierDatabase"));

var app = builder.Build();

app.MapPost("/couriers", async (CreateCourierCommand cmd, CourierCommandHandler handler) =>
{
    var id = await handler.Handle(cmd);
    return Results.Created($"/couriers/{id}", null);
});

app.MapGet("/couriers", async (CourierQueryService service) => await service.GetAllCouriers());

app.MapGet("/couriers/{id}", async (string id, CourierQueryService service) => await service.GetCourierDetails(id));

app.MapDelete("/couriers/{id}", async (string id, CourierCommandHandler handler) =>
{
    var cmd = new DeleteCourierCommand(id);
    await handler.Handle(cmd);
    return Results.NoContent();
});

app.MapPut("/couriers/{id}", async (string id, UpdateCourierCommand cmd, CourierCommandHandler handler) =>
{
    if (id != cmd.Id)
    {
        return Results.BadRequest();
    }

    await handler.Handle(cmd);

    return Results.NoContent();
});

app.Run();
