
namespace Game;

public class DialogueComponent : DialogueBriefingComponent, IDialogueComponent
{
  public required List<IDialogueBriefingComponent> Options { get; set; }

  public required string Content { get; set; }

  public required bool AlreadyCompleted { get; set; }

  public required bool IsReadyToComplete { get; set; }

  public void Cancel()
  {
    throw new NotImplementedException();
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }

  public override bool HideCondition()
  {
    throw new NotImplementedException();
  }
}