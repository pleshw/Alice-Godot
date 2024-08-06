namespace Game;

public record class QuestComponent : IQuestComponent
{
  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required List<ITaskComponent> Tasks { get; set; }
}

