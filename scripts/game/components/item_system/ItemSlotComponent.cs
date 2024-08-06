using System.Text.Json.Serialization;

namespace Game;

public class ItemSlotComponent : IItemSlotComponent
{
  public required IItemComponent Item { get; set; }

  public required IDisplayImageComponent FrameImage { get; set; }

  public required int Amount { get; set; }

  public required int MaxStackSize { get; set; }
}