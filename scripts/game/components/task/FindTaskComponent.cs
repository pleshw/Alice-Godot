namespace Game;

public record class FindTaskComponent : TaskComponent, IFindTaskComponent
{
  public override TaskType TaskType { get; } = TaskType.FIND;

  public required IItemComponent TargetItem { get; set; }
}