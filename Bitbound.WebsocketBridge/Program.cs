using Microsoft.AspNetCore.WebSockets;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddWebSockets(_ => { });

var app = builder.Build();

var api = app.MapGroup("/api");
api.MapGet("/status", () => Results.NoContent());

api.MapGet("/bridge/{id}", async (Guid id, HttpContext context) =>
{
    if (!context.WebSockets.IsWebSocketRequest)
    {
        return Results.BadRequest();
    }

    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
    

    return Results.Ok();
});

app.UseMiddleware<WebsocketBridgeMiddleware>();

app.Run();
