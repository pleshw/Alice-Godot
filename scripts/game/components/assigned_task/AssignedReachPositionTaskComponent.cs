using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Game;

public record class AssignedReachPositionTaskComponent : ReachPositionTaskComponent, IAssignedReachPositionTaskComponent
{
  public bool IsReadyToComplete
  {
    get
    {
      bool isAssignedInsideTheArea = true;
      return isAssignedInsideTheArea;
    }
  }

  public required IUniqueNameComponent AssignedTo { get; set; }

  public required DateTime StartedAt { get; set; }

  [SetsRequiredMembers]
  public AssignedReachPositionTaskComponent(ReachPositionTaskComponent t, IUniqueNameComponent assignedTo, DateTime startedAt)
  {
    Id = t.Id;
    Title = t.Title;
    Description = t.Description;
    AssignedTo = assignedTo;
    StartedAt = startedAt;
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}