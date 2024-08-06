



using System.Numerics;

namespace Game;

public class EntityRoutineComponent : IEntityRoutineComponent
{
  public required Dictionary<int, IEntityBehaviourComponent> EntityBehaviourByGameTime { get; set; }
}