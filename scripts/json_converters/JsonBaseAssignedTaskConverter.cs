using System.Text.Json;
using System.Text.Json.Serialization;
using Game;


namespace JSONConverters;

public class JsonBaseAssignedTaskConverter : JsonConverter<IAssignedTaskComponent>
{
  public override IAssignedTaskComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    // Read the JSON document
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    // Determine the concrete type from the JSON data
    if (root.TryGetProperty("taskType", out JsonElement typeElement))
    {
      int? type = typeElement.GetInt32();
      string rootText = root.GetRawText();

      return (TaskType)type switch
      {
        TaskType.COLLECT => JsonSerializer.Deserialize<AssignedCollectTaskComponent>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskCollection"),
        TaskType.HUNT => JsonSerializer.Deserialize<AssignedHuntTaskComponent>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskHunt"),
        TaskType.FIND => JsonSerializer.Deserialize<AssignedFindTaskComponent>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskFind"),
        TaskType.ESCORT => JsonSerializer.Deserialize<AssignedEscortTaskComponent>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskEscort"),
        TaskType.REACH_POSITION => JsonSerializer.Deserialize<AssignedReachPositionTaskComponent>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachPosition"),
        TaskType.REACH_ENTITY => JsonSerializer.Deserialize<AssignedReachEntityTaskComponent>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachNPC"),
        _ => throw new JsonException("Unknown type"),
      };
    }

    throw new JsonException("Type property not found");
  }

  public override void Write(Utf8JsonWriter writer, IAssignedTaskComponent value, JsonSerializerOptions options)
  {
    // Determine the concrete type and serialize accordingly
    switch (value)
    {
      case AssignedCollectTaskComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case AssignedHuntTaskComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case AssignedFindTaskComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case AssignedEscortTaskComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case AssignedReachPositionTaskComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case AssignedReachEntityTaskComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case null:
        throw new JsonException("Value is null");
      default:
        throw new JsonException("Unknown type");
    }
  }
}
