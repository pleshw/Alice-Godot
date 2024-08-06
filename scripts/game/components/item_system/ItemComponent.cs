namespace Game;

public record class ItemComponent : IItemComponent
{
  public ItemTypes ItemType { get; set; }

  public required string DisplayName { get; set; }

  public required string UniqueName { get; set; }

  public required string Description { get; set; }

  public required string DisplayImage { get; set; }

  public required int RequiredLevel { get; set; }

  public void LoadImage()
  {
    throw new NotImplementedException();
  }
}