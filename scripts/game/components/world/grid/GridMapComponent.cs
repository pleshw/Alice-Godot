using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public delegate void ChangeCellAction(IGridCellComponent cell, int x, int y, int index, int count);

public class GridMapComponent : IGridMapComponent
{
  public required List<IGridCellComponent> GridCells { get; set; }

  public required int Width { get; set; }

  public required int Height { get; set; }


  public void ForEach(int startIndex, int endIndex, ChangeCellAction action)
  {
    if (startIndex < 0 || startIndex >= GridCells.Count)
    {
      throw new ArgumentOutOfRangeException(nameof(startIndex));
    }

    if (endIndex < 0 || endIndex > GridCells.Count)
    {
      throw new ArgumentOutOfRangeException(nameof(endIndex));
    }

    int count = 0;
    for (int i = startIndex; i < GridCells.Count && i < endIndex; i++)
    {
      Vector2 cellPosition = IndexToCoord(GridCells[i].Index).Position;
      action(GridCells[i], (int)cellPosition.X, (int)cellPosition.Y, GridCells[i].Index, count);
      ++count;
    }
  }

  public void ForEach(IHasPositionComponent startPosition, IHasPositionComponent endPosition, ChangeCellAction action)
  {
    ForEach(CoordToIndex(startPosition), CoordToIndex(endPosition), action);
  }

  public void ForEach(ChangeCellAction action)
  {
    ForEach(0, GridCells.Count, action);
  }

  public IGridCellComponent Cell(int x, int y, IGridCellComponent cellValue)
  {
    return GridCells[CoordToIndex(x, y)] = cellValue;
  }

  public IGridCellComponent Cell(int x, int y, GridCellStatus statusValue)
  {
    IGridCellComponent result = GridCells[CoordToIndex(x, y)];
    result.Status = statusValue;
    return result;
  }


  public IGridCellComponent Cell(int x, int y)
  {
    return GridCells[CoordToIndex(x, y)];
  }

  public IGridCellComponent Cell(float x, float y)
  {
    return GridCells[CoordToIndex(x, y)];
  }

  public IGridCellComponent Cell(IHasPositionComponent positionComponent)
  {
    return GridCells[CoordToIndex(positionComponent)];
  }

  public int CoordToIndex(float x, float y)
  {
    return (int)((y * Width) + x);
  }

  public int CoordToIndex(int x, int y)
  {
    return (y * Width) + x;
  }

  public int CoordToIndex(IHasPositionComponent positionComponent)
  {
    return CoordToIndex(positionComponent.Position.X, positionComponent.Position.Y);
  }

  public IHasPositionComponent IndexToCoord(int index)
  {
    return new HasPositionComponent
    {
      Position = new()
      {
        X = index % Width,
        Y = index / Width
      }
    };
  }

  public object Clone()
  {
    List<IGridCellComponent> clonedGridCells = [];

    foreach (var cell in GridCells)
    {
      clonedGridCells.Add((IGridCellComponent)cell.Clone());
    }

    return new GridMapComponent()
    {
      GridCells = clonedGridCells,
      Width = Width,
      Height = Height
    };
  }

  public void Copy(ICopyable copyable)
  {
    IGridMapComponent gridToCopy = (IGridMapComponent)copyable ?? throw new Exception($"Cannot copy from {copyable?.GetType()}.");

    Width = gridToCopy.Width;
    Height = gridToCopy.Height;

    GridCells.Clear();
    foreach (var cell in gridToCopy.GridCells)
    {
      GridCells.Add((IGridCellComponent)cell.Clone());
    }
  }
}