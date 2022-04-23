using GoodsDelivery.CourierWebApi.Core.Application.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CourierCommandHandler>();

var app = builder.Build();

app.MapPost("/couriers", (CreateCourierCommand cmd, CourierCommandHandler handler) =>
{
    var id = handler.Handle(cmd);
    return Results.Created($"/couriers/{id}", null);
});
//app.MapGet("/", () => "Hello World!");

app.Run();
