

namespace Game;

public class MenuPortraitDialogueComponent : PortraitDialogueComponent, IMenuDialogueComponent
{
  public required IMenuComponent MenuComponent { get; set; }
}