using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class GridCellTileSetComponent : GridCellComponent, IGridCellTileSetComponent
{
  public Vector2 TileSetPosition { get; set; }

  public new object Clone()
  {
    return new GridCellTileSetComponent
    {
      Position = Position,
      Size = Size,
      Index = Index,
      Status = Status,
      TileSetPosition = TileSetPosition,
    };
  }

  public new void Copy(ICopyable copyable)
  {
    IGridCellTileSetComponent gridToCopy = (IGridCellTileSetComponent)copyable ?? throw new Exception($"Cannot copy from {copyable?.GetType()}.");

    Position = gridToCopy.Position;
    Size = gridToCopy.Size;
    Index = gridToCopy.Index;
    Status = gridToCopy.Status;
    TileSetPosition = gridToCopy.TileSetPosition;
  }
}