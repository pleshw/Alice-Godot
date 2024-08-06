using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class StageBuilderComponent : StageComponent
{
  public void ReplaceArea(IHasTargetAreaComponent targetArea, GridCellStatus cellStatus)
  {
    var offsetPosition = targetArea.TargetPosition;
    var areaSize = targetArea.Size;
    for (int i = 0; i < areaSize.X; ++i)
    {
      for (int j = 0; j < areaSize.Y; ++j)
      {
        GridMapComponent.Cell((int)(i + offsetPosition.X), (int)(j + offsetPosition.Y), cellStatus);
      }
    }
  }

  public void ReplaceArea(IHasPositionComponent positionComponent, GridMapComponent gridMapShape)
  {
    var offsetPosition = positionComponent.Position;
    for (int i = 0; i < gridMapShape.Width; ++i)
    {
      for (int j = 0; j < gridMapShape.Height; ++j)
      {
        GridMapComponent.Cell((int)(i + offsetPosition.X), (int)(j + offsetPosition.Y), gridMapShape.Cell(i, j));
      }
    }
  }

  public void ReplaceArea(int x, int y, GridCellStatus status)
  {
    ReplaceArea(new HasTargetAreaComponent()
    {
      TargetPosition = new()
      {
        X = x,
        Y = y
      },
      Size = new()
      {
        X = 1,
        Y = 1
      }
    }, status);
  }
}