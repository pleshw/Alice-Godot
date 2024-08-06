using System.Numerics;

namespace Game;

public class HasPositionComponent : IHasPositionComponent
{
  public required Vector2 Position { get; set; }
}