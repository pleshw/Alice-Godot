
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;


[JsonConverter(typeof(JsonAssignedQuestConverter))]
public record class AssignedQuestComponent : IAssignedQuestComponent
{
  public required IUniqueNameComponent AssignedTo { get; set; }

  public required List<IAssignedTaskComponent> Tasks { get; set; }

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }
}

