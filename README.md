# WebSocket Bridge

An ASP.NET Core Native AOT project for bridging client websocket clients.

Quickstart:

```
docker run -d --name ws-bridge --restart unless-stopped -p 5003:8080  translucency/websocket-bridge:latest
```

Two websocket clients can then connect to `wss://{server-host}/bridge/{guid}` to have their connections bridged.