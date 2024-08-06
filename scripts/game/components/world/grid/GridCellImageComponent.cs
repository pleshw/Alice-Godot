using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class GridCellImageComponent : GridCellComponent, IGridCellImageComponent
{
  public required IDisplayImageComponent CellStageSprite { get; set; }

  public required IDisplayImageComponent CellMinimapSprite { get; set; }

  public new object Clone()
  {
    return new GridCellImageComponent
    {
      Position = Position,
      Size = Size,
      Index = Index,
      Status = Status,
      CellStageSprite = CellStageSprite,
      CellMinimapSprite = CellMinimapSprite,
    };
  }

  public new void Copy(ICopyable copyable)
  {
    IGridCellImageComponent gridToCopy = (IGridCellImageComponent)copyable ?? throw new Exception($"Cannot copy from {copyable?.GetType()}.");

    Position = gridToCopy.Position;
    Size = gridToCopy.Size;
    Index = gridToCopy.Index;
    Status = gridToCopy.Status;
    CellStageSprite = gridToCopy.CellStageSprite;
    CellMinimapSprite = gridToCopy.CellMinimapSprite;
  }
}