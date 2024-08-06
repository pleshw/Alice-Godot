using System.Numerics;

namespace Game;

public record class ReachPositionTaskComponent : TaskComponent, IReachPositionTaskComponent
{
  public override TaskType TaskType { get; } = TaskType.REACH_POSITION;

  public required Vector2 Size { get; set; }

  public required Vector2 TargetPosition { get; set; }
}