using System.Numerics;
using System.Text.Json.Serialization;

namespace Game;

public class BehaviourEntity : BaseEntity
{
  public IEntityScheduleComponent Schedule;

  [JsonConstructor]
  public BehaviourEntity(string uniqueName, IEntityScheduleComponent scheduleComponent, List<IComponent> components) : base(uniqueName, components)
  {
    Schedule = scheduleComponent;
  }

  public override IComponent Clone()
  {
    throw new NotImplementedException();
  }
}