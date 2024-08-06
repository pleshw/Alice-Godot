namespace Game;

public record class TaskComponent : ITaskComponent
{
  public virtual TaskType TaskType { get; }

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }
}