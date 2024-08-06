using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class QuestPortraitDialogueComponent : PortraitDialogueComponent, IQuestDialogueComponent
{
  public required IIdComponent Quest { get; set; }
}