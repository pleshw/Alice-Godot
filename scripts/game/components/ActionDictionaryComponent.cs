

namespace Game;

public class ActionDictionaryComponent : IActionDictionaryComponent
{
  public required Dictionary<string, IActionComponent> ActionByUniqueName { get; set; }
}