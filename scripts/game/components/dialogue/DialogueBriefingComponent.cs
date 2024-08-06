using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class DialogueBriefingComponent : IDialogueBriefingComponent
{
  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required bool IsHidden { get; set; }

  public virtual void Show()
  {
    IsHidden = false;
  }

  public virtual void Hide()
  {
    IsHidden = true;
  }

  public virtual bool HideCondition()
  {
    throw new NotImplementedException();
  }
}