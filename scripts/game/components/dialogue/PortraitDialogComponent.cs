using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class PortraitDialogueComponent : DialogueComponent, IPortraitDialogueComponent
{
  public required IDisplayImageComponent ListenerPortrait { get; set; }
  public required IDisplayImageComponent SpeakerPortrait { get; set; }
}