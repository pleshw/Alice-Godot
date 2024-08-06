
namespace Game;

public record class CraftItemComponent : ICraftItemComponent
{
  public required List<IUniqueNameComponent> InputItems { get; set; }

  public required bool IsHidden { get; set; }

  public required float Price { get; set; }

  public required IItemComponent Item { get; set; }

  public required IDisplayImageComponent FrameImage { get; set; }

  public required string UniqueName { get; set; }

  public required Dictionary<MasteryTypes, int> LevelByRequiredMastery { get; set; }

  public void Hide()
  {
    throw new NotImplementedException();
  }

  public bool HideCondition()
  {
    throw new NotImplementedException();
  }

  public void Show()
  {
    throw new NotImplementedException();
  }
}