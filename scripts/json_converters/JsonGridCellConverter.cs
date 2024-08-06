using System.Numerics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;


namespace JSONConverters;

public class JsonGridCellConverter : JsonConverter<GridCellComponent>
{
  public override GridCellComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    if (!doc.RootElement.TryGetProperty("type", out JsonElement typeElement))
    {
      throw new JsonException("Missing type discriminator");
    }

    Vector2 position = root.TryGetProperty("position", out JsonElement _jsonPosition)
            ? JsonSerializer.Deserialize<Vector2>(_jsonPosition.GetRawText(), options)
            : throw new JsonException("Stage does not have a GridMap property.");

    Vector2 size = root.TryGetProperty("size", out JsonElement _jsonSize)
            ? JsonSerializer.Deserialize<Vector2>(_jsonSize.GetRawText(), options)
            : throw new JsonException("Stage does not have a GridMap property.");

    int index = root.TryGetProperty("index", out JsonElement _jsonIndex)
        ? _jsonIndex.GetInt32()
        : throw new JsonException("GridMap does not have a index property set.");

    int status = root.TryGetProperty("status", out JsonElement _jsonStatus)
        ? _jsonStatus.GetInt32()
        : throw new JsonException("GridMap does not have a status property set.");

    return new GridCellComponent
    {
      Position = position,
      Size = size,
      Index = index,
      Status = (GridCellStatus)status
    };
  }

  public override void Write(Utf8JsonWriter writer, GridCellComponent value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();
    writer.WriteString("type", value.GetType().AssemblyQualifiedName);

    var propertiesNotIgnored = value.GetType()
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(prop => !Attribute.IsDefined(prop, typeof(JsonIgnoreAttribute)));

    foreach (var prop in propertiesNotIgnored)
    {
      string propertyName = prop.Name;

      // Apply naming policy if defined
      if (options.PropertyNamingPolicy != null)
      {
        propertyName = options.PropertyNamingPolicy.ConvertName(propertyName);
      }

      writer.WritePropertyName(propertyName);
      JsonSerializer.Serialize(writer, prop.GetValue(value), prop.PropertyType, options);
    }

    writer.WriteEndObject();
  }
}
