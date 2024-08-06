using System.Numerics;

namespace Game;

public class EntityBehaviourComponent : IEntityBehaviourComponent
{
  public required BehaviourType BehaviourType { get; set; }

  public IUniqueNameComponent? CurrentStage { get; set; }

  public required Vector2 Position { get; set; }

  public required Vector2 TargetPosition { get; set; }


  public virtual void RunEntityBehaviour(BaseEntity entity)
  {

  }
}