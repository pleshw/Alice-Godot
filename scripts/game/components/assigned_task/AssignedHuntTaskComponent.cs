using System.Diagnostics.CodeAnalysis;

namespace Game;

public record class AssignedHuntTaskComponent : HuntTaskComponent, IAssignedHuntTaskComponent
{
  public required int AmountKilled { get; set; }

  public bool IsReadyToComplete
  {
    get
    {
      return AmountKilled >= Amount;
    }
  }

  public required IUniqueNameComponent AssignedTo { get; set; }

  public required DateTime StartedAt { get; set; }

  [SetsRequiredMembers]
  public AssignedHuntTaskComponent(HuntTaskComponent t, IUniqueNameComponent assignedTo, DateTime startedAt)
  {
    Id = t.Id;
    Title = t.Title;
    Description = t.Description;
    AssignedTo = assignedTo;
    StartedAt = startedAt;

    Amount = t.Amount;
    TargetEntity = t.TargetEntity;

    AmountKilled = 0;
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}