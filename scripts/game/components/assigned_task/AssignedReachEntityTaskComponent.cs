using System.Diagnostics.CodeAnalysis;
using Game;

namespace Game;

public record class AssignedReachEntityTaskComponent : ReachEntityTaskComponent, IAssignedReachEntityTaskComponent
{
  public bool IsReadyToComplete
  {
    get
    {
      BaseEntity? entity = GetGameEntity();

      if (entity == null)
      {
        return false;
      }

      bool isAssignedAlive = entity.GetComponent<AliveComponent>().IsAlive;
      IRelationshipComponent relationWithTarget = TargetEntity.GetComponent<RelationshipComponent>();

      bool completedTargetDialogue = relationWithTarget.CompletedDialogs.Any(c => c.Id == TargetDialogue.Id);

      return isAssignedAlive && completedTargetDialogue;
    }
  }

  public required IUniqueNameComponent AssignedTo { get; set; }

  public required DateTime StartedAt { get; set; }

  [SetsRequiredMembers]
  public AssignedReachEntityTaskComponent(ReachEntityTaskComponent t, IUniqueNameComponent assignedTo, DateTime startedAt)
  {
    Id = t.Id;
    Title = t.Title;
    Description = t.Description;
    AssignedTo = assignedTo;
    StartedAt = startedAt;

    TargetDialogue = t.TargetDialogue;

    TargetEntity = t.TargetEntity;
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }

  public static BaseEntity? GetGameEntity()
  {
    return null;
  }
}