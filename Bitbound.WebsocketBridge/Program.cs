using Microsoft.AspNetCore.WebSockets;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddWebSockets(_ => { });

var app = builder.Build();

var api = app.MapGroup("/api");
api.MapGet("/status", () => Results.NoContent());
app.UseMiddleware<WebsocketBridgeMiddleware>();

app.Run();
