
namespace Game;

public class MenuShopComponent : MenuComponent, IMenuShopComponent
{

  public override MenuType MenuType { get; set; } = MenuType.SHOP;
  public required List<IShopItemComponent> ItemList { get; set; }
}