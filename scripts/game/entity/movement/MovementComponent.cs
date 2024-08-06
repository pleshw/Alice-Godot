using System.Numerics;

namespace Game;

public class MovementComponent : IMovementComponent
{
  public required Vector2 TargetPosition { get; set; }

  public required int Speed { get; set; }

  public required Vector2 FacingDirection { get; set; }

  public required Vector2 LastPosition { get; set; }

  public int SpeedModifier { get; set; }
}