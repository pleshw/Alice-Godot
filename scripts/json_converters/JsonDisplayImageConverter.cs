using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;


namespace JSONConverters;

public class JsonDisplayImageConverter : JsonConverter<IDisplayImageComponent>
{
  public override IDisplayImageComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    if (!root.TryGetProperty("displayImage", out JsonElement jsonDisplayImage))
    {
      throw new JsonException("Invalid dialogue. Dialogue does not contain a valid Id.");
    }

    string displayImage = jsonDisplayImage.GetString() ?? throw new JsonException("Invalid DisplayImage type. Display Image type should be string."); ;

    return new DisplayImageComponent
    {
      DisplayImage = displayImage
    };
  }

  /// Write only the exposed properties in the interface. So the higher level class properties dont go to json
  public override void Write(Utf8JsonWriter writer, IDisplayImageComponent value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();
    writer.WriteString("type", value.GetType().AssemblyQualifiedName);

    // Get properties defined in the interface
    var properties = typeof(IDisplayImageComponent).GetProperties(BindingFlags.Public | BindingFlags.Instance);

    foreach (var prop in properties)
    {
      string propertyName = prop.Name;

      // Apply naming policy if defined
      if (options.PropertyNamingPolicy != null)
      {
        propertyName = options.PropertyNamingPolicy.ConvertName(propertyName);
      }

      writer.WritePropertyName(propertyName);

      // Serialize the property value
      var propertyValue = prop.GetValue(value);
      JsonSerializer.Serialize(writer, propertyValue, prop.PropertyType, options);
    }

    writer.WriteEndObject();
  }
}
