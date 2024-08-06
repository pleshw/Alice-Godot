namespace Game;

public class BodyPartComponent : IBodyPartComponent
{
  public required string UniqueName { get; set; }

  public required BehaviourType DefaultAnimation { get; set; }

  public required List<BehaviourType> AvailableAnimations { get; set; }
}