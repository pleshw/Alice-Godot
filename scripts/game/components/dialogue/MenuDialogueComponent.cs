

namespace Game;

public class MenuDialogueComponent : DialogueComponent, IMenuDialogueComponent
{
  public required IMenuComponent MenuComponent { get; set; }
}