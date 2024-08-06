using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSONConverters;

public class JsonVector2Converter : JsonConverter<Vector2>
{
  public override Vector2 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    root.TryGetProperty("x", out JsonElement x);
    root.TryGetProperty("y", out JsonElement y);

    return new()
    {
      X = x.GetInt32(),
      Y = y.GetInt32()
    };


    throw new JsonException("Type property not found");
  }

  public override void Write(Utf8JsonWriter writer, Vector2 value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();
    writer.WriteString("type", value.GetType().AssemblyQualifiedName);

    writer.WriteNumber("x", value.X);
    writer.WriteNumber("y", value.Y);

    writer.WriteEndObject();
  }
}