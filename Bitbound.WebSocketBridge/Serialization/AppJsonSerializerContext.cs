using Bitbound.WebSocketBridge.Dtos;
using System.Text.Json.Serialization;

namespace Bitbound.WebSocketBridge.Serialization;

[JsonSerializable(typeof(StatusOkDto))]
public partial class AppJsonSerializerContext : JsonSerializerContext
{

}
