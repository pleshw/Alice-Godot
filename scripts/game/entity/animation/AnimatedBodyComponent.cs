namespace Game;

public class AnimatedBodyComponent : IAnimatedBodyComponent
{
  public required Dictionary<string, BodyPartComponent> PartsByComponent { get; set; }
}