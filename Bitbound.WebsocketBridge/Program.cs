using Bitbound.WebsocketBridge.Dtos;
using Bitbound.WebsocketBridge.Serialization;
using Microsoft.AspNetCore.WebSockets;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddWebSockets(_ => { });
builder.Services.AddSingleton<ISessionStore, SessionStore>();
var app = builder.Build();

var api = app.MapGroup("/api");
api.MapGet("/status", () => Results.Ok(new StatusOkDto("Bridge is running!")));

app.UseWhen(x => x.Request.Path.StartsWithSegments("/bridge"), x =>
{
    x.UseWebSockets();
    x.UseMiddleware<WebsocketBridgeMiddleware>();
});

app.Run();
