using System.Numerics;
using System.Reflection.Metadata;
using Game;

namespace Build;

public class OreListSingleton
{
  private static OreListSingleton? _oreListBuild;

  public static OreListSingleton Instance
  {
    get
    {
      return _oreListBuild ??= new();
    }
  }

  public List<GatherComponent> OreList = [
  //// STONE
   new GatherComponent
      {
        RequiredLevel = 0,
        UniqueName = "StoneOre",
        Resource =   new ItemComponent()
        {
          ItemType = ItemTypes.ORE,
          DisplayName = "Stone",
          UniqueName = "StoneOreItem",
          RequiredLevel = 0,
          Description = "A piece of stone. It's a basic resource for crafting.",
          DisplayImage = "images/stone_item.png",
        },
        TimeToRenew = Constants.DayLength/4,
        CompletedAt = null,
        Amount = 3,
        TotalProgress = 10,
        CurrentProgress = 0,
        Position = -Vector2.One,
        LevelByRequiredMastery = new()
        {
          {MasteryTypes.MINING, 1}
        }
      },

  //// COAL
   new GatherComponent
      {
        RequiredLevel = 0,
        UniqueName = "CoalOre",
        Resource =   new ItemComponent()
        {
          ItemType = ItemTypes.ORE,
          DisplayName = "Coal",
          UniqueName = "CoalOreItem",
          RequiredLevel = 0,
          Description = "I think it can be used as fuel.",
          DisplayImage = "images/coal_item.png",
        },
        TimeToRenew = Constants.DayLength/3,
        CompletedAt = null,
        Amount = 2,
        TotalProgress = 10,
        CurrentProgress = 0,
        Position = -Vector2.One,
        LevelByRequiredMastery = new()
        {
          {MasteryTypes.MINING, 1}
        }
      },

  //// COOPER
   new GatherComponent
      {
        RequiredLevel = 0,
        UniqueName = "CooperOre",
        Resource =   new ItemComponent()
        {
          ItemType = ItemTypes.ORE,
          DisplayName = "Cooper",
          UniqueName = "CooperOreItem",
          RequiredLevel = 0,
          Description = "It's a hard metal. If i melt maybe it can be used for crafting.",
          DisplayImage = "images/cooper_item.png",
        },
        TimeToRenew = Constants.DayLength/3,
        CompletedAt = null,
        Amount = 2,
        TotalProgress = 15,
        CurrentProgress = 0,
        Position = -Vector2.One,
        LevelByRequiredMastery = new()
        {
          {MasteryTypes.MINING, 5}
        }
      },

  //// IRON
   new GatherComponent
      {
        RequiredLevel = 0,
        UniqueName = "IronOre",
        Resource =   new ItemComponent()
        {
          ItemType = ItemTypes.ORE,
          DisplayName = "Iron",
          UniqueName = "IronOreItem",
          RequiredLevel = 0,
          Description = "It definitely can be refined.",
          DisplayImage = "images/iron_item.png",
        },
        TimeToRenew = Constants.DayLength/3,
        CompletedAt = null,
        Amount = 2,
        TotalProgress = 25,
        CurrentProgress = 0,
        Position = -Vector2.One,
        LevelByRequiredMastery = new()
        {
          {MasteryTypes.MINING, 15}
        }
      },

      
  //// GOLD
   new GatherComponent
      {
        RequiredLevel = 0,
        UniqueName = "GoldOre",
        Resource =   new ItemComponent()
        {
          ItemType = ItemTypes.ORE,
          DisplayName = "Gold",
          UniqueName = "GoldOreItem",
          RequiredLevel = 0,
          Description = "It definitely can be refined.",
          DisplayImage = "images/gold_item.png",
        },
        TimeToRenew = Constants.DayLength,
        CompletedAt = null,
        Amount = 2,
        TotalProgress = 35,
        CurrentProgress = 0,
        Position = -Vector2.One,
        LevelByRequiredMastery = new()
        {
          {MasteryTypes.MINING, 25}
        }
      },

  //// PLATINUM
   new GatherComponent
      {
        RequiredLevel = 0,
        UniqueName = "PlatinumOre",
        Resource =   new ItemComponent()
        {
          ItemType = ItemTypes.ORE,
          DisplayName = "Platinum",
          UniqueName = "PlatinumOreItem",
          RequiredLevel = 0,
          Description = "It looks rare and pretty strong.",
          DisplayImage = "images/platinum_item.png",
        },
        TimeToRenew = Constants.DayLength * 2,
        CompletedAt = null,
        Amount = 2,
        TotalProgress = 60,
        CurrentProgress = 0,
        Position = -Vector2.One,
        LevelByRequiredMastery = new()
        {
          {MasteryTypes.MINING, 50}
        }
      },
 ];

  public static IGatherComponent GetOreByUniqueName(string uniqueName)
  {
    return Instance.OreList.Where(q => q.UniqueName == uniqueName).FirstOrDefault() ?? throw new Exception($"Invalid deserialization. Entity {uniqueName} does not exist.");
  }

  public static List<IGatherComponent> GetOresByUniqueName(List<IUniqueNameComponent> uniqueNames)
  {
    return GetOresCloneByUniqueName(uniqueNames.Select(u => u.UniqueName).ToList());
  }

  public static List<IGatherComponent> GetOresCloneByUniqueName(List<string> uniqueNames)
  {
    return uniqueNames.Select(uniqueName => Instance.OreList.FirstOrDefault(q => q.UniqueName == uniqueName) ?? throw new Exception($"Invalid deserialization. Entity {uniqueName} does not exist."))
          .Select(o => o.Clone())
          .Cast<IGatherComponent>()
          .ToList();
  }
}