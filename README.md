# WebSocket Bridge

An ASP.NET Core Native AOT project for bridging client websocket clients.

[![Build Status](https://dev.azure.com/translucency/ControlR/_apis/build/status%2FWebSocketBridge?branchName=main)](https://dev.azure.com/translucency/ControlR/_build/latest?definitionId=37&branchName=main)

Quickstart (Docker):

```
docker run -d --name ws-bridge --restart unless-stopped -p 5003:8080  translucency/websocket-bridge:latest
```

Two websocket clients can then connect to `wss://{server-host}/bridge/{guid}/{access-token}` to have their connections bridged.
