# WebSocket Bridge

An ASP.NET Core Native AOT project for bridging websocket clients.

[![Build Status](https://dev.azure.com/translucency/ControlR/_apis/build/status%2FWebSocketBridge?branchName=main)](https://dev.azure.com/translucency/ControlR/_build/latest?definitionId=37&branchName=main)

Quickstart (Docker):

```
docker run -d --name ws-bridge --restart unless-stopped -p 5003:8080  translucency/websocket-bridge:latest
```

Two websocket clients can then connect to `wss://{server-host}/bridge/{guid}/{access-token}` to have their connections bridged.

Each client can provide an optional timeout (in seconds) to indicate how long to wait for the other client to connect.  If omitted, the default of 10 seconds will be used.

If 0 is specified, the server will wait indefinitely for the other client to connect.

Example with timeout:

```
wss://{server-host}/bridge/{guid}/{access-token}?timeout=60
```

