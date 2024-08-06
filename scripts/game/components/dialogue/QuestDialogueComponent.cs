using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class QuestDialogueComponent : DialogueComponent, IQuestDialogueComponent
{
  public required IIdComponent Quest { get; set; }
}