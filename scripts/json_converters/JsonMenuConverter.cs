using System.Text.Json;
using System.Text.Json.Serialization;
using Game;


namespace JSONConverters;

public class JsonMenuConverter : JsonConverter<IMenuComponent>
{
  public override IMenuComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    // Read the JSON document
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    // Determine the concrete type from the JSON data
    if (root.TryGetProperty("menuType", out JsonElement typeElement))
    {
      int? type = typeElement.GetInt32();
      string rootText = root.GetRawText();

      return (MenuType)type switch
      {
        MenuType.SHOP => JsonSerializer.Deserialize<MenuShopComponent>(rootText, options) ?? throw new JsonException("Failed to convert for type MenuShopComponent"),
        MenuType.CRAFT => JsonSerializer.Deserialize<MenuCraftComponent>(rootText, options) ?? throw new JsonException("Failed to convert for type MenuCraftComponent"),
        MenuType.PICK_ITEM => JsonSerializer.Deserialize<MenuPickItemComponent>(rootText, options) ?? throw new JsonException("Failed to convert for type MenuPickItemComponent"),
        MenuType.NONE => JsonSerializer.Deserialize<MenuComponent>(rootText, options) ?? throw new JsonException("Failed to convert for type MenuComponent"),
        _ => throw new JsonException("Unknown type"),
      };
    }

    throw new JsonException("Type property not found");
  }

  public override void Write(Utf8JsonWriter writer, IMenuComponent value, JsonSerializerOptions options)
  {
    // Determine the concrete type and serialize accordingly
    switch (value)
    {
      case MenuCraftComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case MenuPickItemComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case MenuShopComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case MenuComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case null:
        throw new JsonException("Value is null");
      default:
        throw new JsonException("Unknown type");
    }
  }
}
