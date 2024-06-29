using Bitbound.WebsocketBridge.Dtos;
using System.Text.Json.Serialization;

namespace Bitbound.WebsocketBridge.Serialization;

[JsonSerializable(typeof(StatusOkDto))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
