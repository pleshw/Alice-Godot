using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class GatherComponent : IGatherComponent, ICloneable, ICopyable
{
  public required IItemComponent Resource { get; set; }

  public required Vector2 Position { get; set; }

  public required int TimeToRenew { get; set; }

  public required DateTime? CompletedAt { get; set; }

  public required int Amount { get; set; }

  public required int TotalProgress { get; set; }

  public required int CurrentProgress { get; set; }

  public required int RequiredLevel { get; set; }

  public required Dictionary<MasteryTypes, int> LevelByRequiredMastery { get; set; }

  public required string UniqueName { get; set; }

  public object Clone()
  {
    return new GatherComponent
    {
      RequiredLevel = RequiredLevel,
      Resource = Resource,
      TimeToRenew = TimeToRenew,
      CompletedAt = CompletedAt,
      Amount = Amount,
      TotalProgress = TotalProgress,
      CurrentProgress = CurrentProgress,
      Position = Position,
      LevelByRequiredMastery = LevelByRequiredMastery,
      UniqueName = UniqueName
    };
  }

  public void Copy(ICopyable copyable)
  {
    GatherComponent resourceToCopy = (GatherComponent)copyable ?? throw new Exception($"Cannot copy from {copyable?.GetType()}.");

    RequiredLevel = resourceToCopy.RequiredLevel;
    Resource = resourceToCopy.Resource;
    TimeToRenew = resourceToCopy.TimeToRenew;
    CompletedAt = resourceToCopy.CompletedAt;
    Amount = resourceToCopy.Amount;
    TotalProgress = resourceToCopy.TotalProgress;
    CurrentProgress = resourceToCopy.CurrentProgress;
    Position = resourceToCopy.Position;
    LevelByRequiredMastery = resourceToCopy.LevelByRequiredMastery;
    UniqueName = resourceToCopy.UniqueName;
  }
}