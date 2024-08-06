using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class GridCellComponent : IGridCellComponent
{
  public required Vector2 Position { get; set; }

  public required Vector2 Size { get; set; }

  public required int Index { get; set; }

  public required GridCellStatus Status { get; set; }

  public object Clone()
  {
    return new GridCellComponent
    {
      Position = Position,
      Size = Size,
      Index = Index,
      Status = Status
    };
  }

  public void Copy(ICopyable copyable)
  {
    IGridCellComponent gridToCopy = (IGridCellComponent)copyable ?? throw new Exception($"Cannot copy from {copyable?.GetType()}.");

    Position = gridToCopy.Position;
    Size = gridToCopy.Size;
    Index = gridToCopy.Index;
    Status = gridToCopy.Status;
  }
}