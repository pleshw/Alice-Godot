



using System.Numerics;

namespace Game;

public class EntityScheduleComponent : IEntityScheduleComponent
{
  public required IEntityRoutineComponent DefaultRoutine { get; set; }
  public required Dictionary<int, IEntityRoutineComponent> EntityRoutineByGameDay { get; set; }
}