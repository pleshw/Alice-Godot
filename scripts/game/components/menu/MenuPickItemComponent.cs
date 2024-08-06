
namespace Game;

public class MenuPickItemComponent : MenuComponent, IMenuPickItemComponent
{

  public override MenuType MenuType { get; set; } = MenuType.PICK_ITEM;
  public required List<IItemSlotComponent> ItemList { get; set; }
}