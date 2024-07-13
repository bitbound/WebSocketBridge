using Bitbound.WebsocketBridge.Dtos;
using Bitbound.WebsocketBridge.Serialization;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.AspNetCore.WebSockets;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Logging.AddSimpleConsole(options =>
{
    options.IncludeScopes = true;
    options.TimestampFormat = "yyyy-MM-dd HH:mm:ss.fff zzz ";
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddWebSockets(_ => { });
builder.Services.AddHealthChecks();
builder.Services.AddSingleton<ISessionStore, SessionStore>();
var app = builder.Build();

var api = app.MapGroup("/api");
api.MapHealthChecks("/health");

app.UseWhen(x => x.Request.Path.StartsWithSegments("/bridge"), x =>
{
    x.UseWebSockets();
    x.UseMiddleware<WebSocketBridgeMiddleware>();
});

app.Run();
