using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class InventoryComponent : IInventoryComponent
{
  public required IUniqueNameComponent Owner { get; set; }

  public required List<IItemSlotComponent> Items { get; set; }

  public required int MaxStackSize { get; set; }

  public bool TryAdd(IItemSlotComponent item)
  {
    if ((Items.Count + 1) > MaxStackSize)
    {
      return false;
    }

    Items.Add(item);
    return true;
  }

  public bool TryAdd(IItemSlotComponent[] items)
  {
    if ((Items.Count + items.Length) > MaxStackSize)
    {
      return false;
    }

    foreach (IItemSlotComponent i in items)
    {
      Items.Add(i);
    }

    return true;
  }
}