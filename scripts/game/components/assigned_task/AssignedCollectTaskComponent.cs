using System.Diagnostics.CodeAnalysis;

namespace Game;

public record class AssignedCollectTaskComponent : CollectTaskComponent, IAssignedCollectTaskComponent
{
  public bool IsReadyToComplete
  {
    get
    {
      return AmountCollected >= Amount;
    }
  }

  public required int AmountCollected { get; set; }

  public required IUniqueNameComponent AssignedTo { get; set; }

  public required DateTime StartedAt { get; set; }

  [SetsRequiredMembers]
  public AssignedCollectTaskComponent(CollectTaskComponent t, IUniqueNameComponent assignedTo, DateTime startedAt)
  {
    Id = t.Id;
    Title = t.Title;
    Description = t.Description;
    AssignedTo = assignedTo;
    StartedAt = startedAt;

    TargetItem = t.TargetItem;

    AmountCollected = 0;
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}