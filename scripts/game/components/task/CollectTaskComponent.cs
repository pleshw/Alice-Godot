namespace Game;

public record class CollectTaskComponent : TaskComponent, ICollectTaskComponent
{
  public override TaskType TaskType { get; } = TaskType.COLLECT;

  public required IItemComponent TargetItem { get; set; }

  public required int Amount { get; set; }
}