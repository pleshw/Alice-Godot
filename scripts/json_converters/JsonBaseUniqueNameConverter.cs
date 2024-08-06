using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;


namespace JSONConverters;

public class JsonBaseUniqueNameConverter : JsonConverter<IUniqueNameComponent>
{
  public override IUniqueNameComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);

    if (!doc.RootElement.TryGetProperty("uniqueName", out JsonElement jsonUniqueName))
    {
      throw new JsonException("Missing uniqueName property.");
    }

    return new UniqueNameComponent()
    {
      UniqueName = jsonUniqueName.GetString() ?? throw new JsonException($"Invalid uniqueName.")
    };
  }

  public override void Write(Utf8JsonWriter writer, IUniqueNameComponent value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();
    writer.WriteString("type", value.GetType().AssemblyQualifiedName);

    writer.WriteString("uniqueName", value.UniqueName);


    writer.WriteEndObject();
  }
}
