using GoodsDelivery.IdentityServer.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
        .AddInMemoryApiScopes(ApiScopeProvider.Get())
        .AddInMemoryApiResources(ApiResourceProvider.Get())
        .AddInMemoryIdentityResources(IdentityResourceProvider.Get())
        .AddTestUsers(UserProvider.Get().ToList())
        .AddInMemoryClients(ClientProvider.Get())
        .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer();

app.Run();
