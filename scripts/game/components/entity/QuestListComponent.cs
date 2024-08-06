
namespace Game;

public class QuestListComponent : IQuestListComponent
{
  public required List<IIdComponent> OnGoingQuests { get; set; }

  public required List<IIdComponent> CancelledQuests { get; set; }

  public required List<IIdComponent> CompletedQuests { get; set; }
}