using System.Numerics;

namespace Game;

public record class EscortTaskComponent : TaskComponent, IEscortTaskComponent
{
  public override TaskType TaskType { get; } = TaskType.ESCORT;

  public required IUniqueNameComponent Companion { get; set; }

  public required Vector2 TargetPosition { get; set; }

  public required Vector2 Size { get; set; }
}