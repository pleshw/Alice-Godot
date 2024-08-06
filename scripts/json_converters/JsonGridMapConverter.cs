using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;


namespace JSONConverters;

public class JsonGridMapConverter : JsonConverter<GridMapComponent>
{
  public override GridMapComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    // Assuming you need to extract more properties, for example "capacity" and "items"
    int width = root.TryGetProperty("width", out JsonElement _jsonWidth)
        ? _jsonWidth.GetInt32()
        : throw new JsonException("GridMap does not have a width property set.");

    // Assuming you need to extract more properties, for example "capacity" and "items"
    int height = root.TryGetProperty("height", out JsonElement _jsonHeight)
        ? _jsonHeight.GetInt32()
        : throw new JsonException("GridMap does not have a height property set.");

    JsonElement itemsElement = root.TryGetProperty("gridCells", out JsonElement jsonItems)
        ? jsonItems
        : throw new JsonException("GridMap does not have an GridCells property set.");

    List<IGridCellComponent> gridCells = itemsElement.EnumerateArray()
                                                      .Select(item => JsonSerializer.Deserialize<GridCellComponent>(item.GetRawText(), options)
                                                           ?? throw new JsonException("Invalid cell in gridCells."))
                                                      .Cast<IGridCellComponent>()
                                                      .ToList();

    return new GridMapComponent
    {
      GridCells = gridCells,
      Width = width,
      Height = height
    };
  }

  public override void Write(Utf8JsonWriter writer, GridMapComponent value, JsonSerializerOptions options)
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
