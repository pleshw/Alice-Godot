namespace Game;

public record class HuntTaskComponent : TaskComponent, IHuntTaskComponent
{
  public override TaskType TaskType { get; } = TaskType.HUNT;

  public required BaseEntity TargetEntity { get; set; }

  public required int Amount { get; set; }
}