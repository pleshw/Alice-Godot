
namespace Game;

public class MenuCraftComponent : MenuComponent, IMenuCraftComponent
{

  public override MenuType MenuType { get; set; } = MenuType.CRAFT;
  public required List<ICraftItemComponent> ItemList { get; set; }
}