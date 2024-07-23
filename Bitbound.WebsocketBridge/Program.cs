using Bitbound.WebSocketBridge.Common.Extensions;
using Bitbound.WebSocketBridge.Serialization;

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

builder.Services.AddWebSocketBridge();

builder.Services.AddHealthChecks();

var app = builder.Build();
var api = app.MapGroup("/api");
api.MapHealthChecks("/health");

app.MapWebSocketBridge("/bridge");

app.Run();
