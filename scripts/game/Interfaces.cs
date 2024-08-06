using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;


[JsonConverter(typeof(JsonBaseComponentConverter))]
public interface IComponent
{
}

public interface IEntityAttributesComponent : IComponent
{
  Agility Agility { get; set; }
  Dexterity Dexterity { get; set; }
  Intelligence Intelligence { get; set; }
  Luck Luck { get; set; }
  Strength Strength { get; set; }
  Vitality Vitality { get; set; }
}

// Defines properties for displaying the name
public interface IDisplayNameComponent : IComponent
{
  string DisplayName { get; set; }
}

public interface ICanHide : IComponent
{
  bool IsHidden { get; set; }

  void Show();

  void Hide();

  bool HideCondition();
}

[JsonConverter(typeof(JsonDisplayImageConverter))]
public interface IDisplayImageComponent : IComponent
{
  string DisplayImage { get; set; }

  void LoadImage();
}

public interface ITitleComponent : IComponent
{
  string Title { get; set; }
}

public interface IDescriptionComponent : IComponent
{
  string Description { get; set; }
}

public interface ITextContentComponent : IComponent
{
  string Content { get; set; }
}

public interface IEquipComponent : IComponent, IItemComponent
{
  void Equip(IEquipSlotComponent slot);
}

public interface IConsumableComponent : IComponent, IHasAmountComponent
{
  void Consume();
}

public interface IAmountCollectedComponent : IComponent
{
  int AmountCollected { get; set; }
}

public interface IAmountKilledComponent : IComponent
{
  int AmountKilled { get; set; }
}

[JsonConverter(typeof(JsonBaseItemConverter))]
public interface IItemComponent : IComponent, IDisplayNameComponent, IUniqueNameComponent, IDescriptionComponent, IDisplayImageComponent, IHasRequiredLevelComponent
{
  ItemTypes ItemType { get; set; }
}

public interface IDroppedItemComponent : IComponent, IItemComponent, IHasAmountComponent
{

}

public interface IProgressComponent : IComponent
{
  int TotalProgress { get; set; }

  int CurrentProgress { get; set; }
}

public interface IRenewableComponent : IComponent
{
  int TimeToRenew { get; set; }

  DateTime? CompletedAt { get; set; }
}

[JsonConverter(typeof(JsonBaseGatherConverter))]
public interface IGatherComponent : IComponent, IUniqueNameComponent, IRenewableComponent, IHasAmountComponent, IProgressComponent, IHasPositionComponent, IHasRequiredLevelComponent, IHasRequiredMasteryComponent
{
  IItemComponent Resource { get; set; }
}

public interface IHasPrice : IComponent
{
  float Price { get; set; }
}

public interface IHasRequiredMasteryComponent : IComponent
{
  Dictionary<MasteryTypes, int> LevelByRequiredMastery { get; set; }
}

public interface IHasRequiredLevelComponent : IComponent
{
  int RequiredLevel { get; set; }
}

public interface IShopItemComponent : IComponent, ICanHide, IHasPrice, IItemFrameComponent, IHasAmountComponent, IUniqueNameComponent
{

}

public interface ICraftItemComponent : IComponent, ICanHide, IHasPrice, IItemFrameComponent, IUniqueNameComponent, IHasRequiredMasteryComponent
{
  List<IUniqueNameComponent> InputItems { get; set; }
}

public interface IHasAssignedEntity : IComponent
{
  IUniqueNameComponent AssignedTo { get; set; }
}

public interface IQuestComponent : IComponent, IIdComponent, ITitleComponent, IDescriptionComponent
{
  List<ITaskComponent> Tasks { get; set; }
}

public interface IAssignedQuestComponent : IComponent, IIdComponent, ITitleComponent, IDescriptionComponent, IHasAssignedEntity
{
  List<IAssignedTaskComponent> Tasks { get; set; }
}

public interface IHasStartComponent : IComponent
{
  DateTime StartedAt { get; set; }
}

[JsonConverter(typeof(JsonBaseAssignedTaskConverter))]
public interface IAssignedTaskComponent : IComponent, IHasAssignedEntity, IHasStartComponent, ITaskComponent, IIdComponent, ITitleComponent, IDescriptionComponent, ICompletableComponent
{

}

[JsonConverter(typeof(JsonTaskConverter))]
public interface ITaskComponent : IComponent, IIdComponent, ITitleComponent, IDescriptionComponent
{
  TaskType TaskType { get; }
}

public interface ICollectTaskComponent : IComponent, ITaskComponent, IHasAmountComponent
{
  IItemComponent TargetItem { get; set; }
}

public interface IAssignedCollectTaskComponent : IComponent, ICollectTaskComponent, IAssignedTaskComponent, IAmountCollectedComponent
{
}

public interface IStageComponent : IComponent, IUniqueNameComponent
{
  IGridMapComponent GridMap { get; set; }
}

[JsonConverter(typeof(JsonBaseGridMapConverter))]
public interface IGridMapComponent : IComponent, ICloneable, ICopyable
{
  List<IGridCellComponent> GridCells { get; set; }

  int Width { get; set; }

  int Height { get; set; }
}

public interface ICopyable : IComponent
{
  void Copy(ICopyable copyable);
}


[JsonConverter(typeof(JsonBaseGridCellConverter))]
public interface IGridCellComponent : IComponent, IHasPositionComponent, ISizeComponent, IIndexComponent, ICloneable, ICopyable
{
  GridCellStatus Status { get; set; }
}

public interface IGridDisplayCellComponent : IComponent, IGridCellComponent
{
  IGridCellImageComponent GridCellImage { get; set; }
}

public interface IGridCellTileSetComponent : IComponent, IGridCellComponent
{
  Vector2 TileSetPosition { get; set; }
}

public interface IGridCellImageComponent : IComponent, IGridCellComponent
{
  IDisplayImageComponent CellStageSprite { get; set; }
  IDisplayImageComponent CellMinimapSprite { get; set; }
}

public interface IEscortTaskComponent : IComponent, ITaskComponent, IHasTargetAreaComponent
{
  IUniqueNameComponent Companion { get; set; }
}

public interface IAssignedEscortTaskComponent : IComponent, IEscortTaskComponent, IAssignedTaskComponent
{
}

public interface IFindTaskComponent : IComponent, ITaskComponent
{
  IItemComponent TargetItem { get; set; }
}

public interface IAssignedFindTaskComponent : IComponent, IFindTaskComponent, IAssignedTaskComponent, IAmountCollectedComponent
{
}


public interface IHuntTaskComponent : IComponent, ITaskComponent, IHasAmountComponent
{
  BaseEntity TargetEntity { get; set; }
}

public interface IAssignedHuntTaskComponent : IComponent, IHuntTaskComponent, IAssignedTaskComponent, IAmountKilledComponent
{
}

public interface IReachEntityTaskComponent : IComponent, ITaskComponent
{
  BaseEntity TargetEntity { get; set; }

  IDialogueComponent TargetDialogue { get; set; }
}

public interface IAssignedReachEntityTaskComponent : IComponent, IReachEntityTaskComponent, IAssignedTaskComponent
{

}

public interface IReachPositionTaskComponent : IComponent, ITaskComponent, IHasTargetAreaComponent
{

}

public interface IAssignedReachPositionTaskComponent : IComponent, IReachPositionTaskComponent, IAssignedTaskComponent
{

}

public interface ICanOpen : IComponent
{
  void Open();
}

public interface ICanClose : IComponent
{
  void Close();
}

[JsonConverter(typeof(JsonMenuConverter))]
public interface IMenuComponent : IComponent, IDisplayNameComponent, IUniqueNameComponent, ICanOpen, ICanClose
{
  MenuType MenuType { get; set; }
}

public interface IMenuShopComponent : IComponent, IMenuComponent
{
  List<IShopItemComponent> ItemList { get; set; }
}

public interface IMenuCraftComponent : IComponent, IMenuComponent
{
  List<ICraftItemComponent> ItemList { get; set; }
}

public interface IMenuPickItemComponent : IComponent, IMenuComponent
{
  List<IItemSlotComponent> ItemList { get; set; }
}

public interface IDialogueBriefingComponent : IComponent, ICanHide, IIdComponent, ITitleComponent
{
}

public interface IDialogueComponent : IComponent, IDialogueBriefingComponent, ITextContentComponent, IMultipleCompletableComponent, ICancelComponent
{
  List<IDialogueBriefingComponent> Options { get; set; }
}

public interface IPortraitDialogueComponent : IComponent, IDialogueComponent
{
  IDisplayImageComponent ListenerPortrait { get; set; }

  IDisplayImageComponent SpeakerPortrait { get; set; }
}

public interface IMenuDialogueComponent : IComponent, IDialogueComponent
{
  IMenuComponent MenuComponent { get; set; }
}

public interface IQuestDialogueComponent : IComponent, IDialogueComponent
{
  IIdComponent Quest { get; set; }
}

public interface IQuestListComponent : IComponent
{
  List<IIdComponent> OnGoingQuests { get; set; }

  List<IIdComponent> CancelledQuests { get; set; }

  List<IIdComponent> CompletedQuests { get; set; }
}

public interface IRelationshipComponent : IComponent, ILevelComponent
{
  List<IDialogueComponent> CompletedDialogs { get; set; }
}

public interface ICompletableComponent : IComponent
{
  bool IsReadyToComplete { get; }

  void Complete();
}

public interface IMultipleCompletableComponent : IComponent, ICompletableComponent
{
  bool AlreadyCompleted { get; }
}

public interface ICancelComponent : IComponent
{
  void Cancel();
}

public interface IHasAmountComponent : IComponent
{
  int Amount { get; set; }
}

public interface IHasMaxAmountComponent : IComponent
{
  int MaxAmount { get; set; }
}

public interface IHasMinAmountComponent : IComponent
{
  int MinAmount { get; set; }
}

public interface IHasRangeAmountComponent : IComponent, IHasMinAmountComponent, IHasMaxAmountComponent
{
}

public interface IHasMaxStackSizeComponent : IComponent
{
  int MaxStackSize { get; set; }
}


public interface IItemFrameComponent : IComponent
{
  IItemComponent Item { get; set; }
  IDisplayImageComponent FrameImage { get; set; }
}

public interface IItemSlotComponent : IComponent, IItemFrameComponent, IHasAmountComponent, IHasMaxStackSizeComponent
{
}

public interface IEquipSlotComponent : IComponent, IUniqueNameComponent, IDescriptionComponent, IDisplayNameComponent, IItemSlotComponent
{
}

public interface IInventoryComponent : IComponent, IHasMaxStackSizeComponent
{
  IUniqueNameComponent Owner { get; set; }

  List<IItemSlotComponent> Items { get; set; }
}

// Defines properties for entities that have a level
public interface ILevelComponent : IComponent
{
  int Level { get; set; }
}

public interface IIndexComponent : IComponent
{
  int Index { get; set; }
}


// Defines properties for entities with a position
public interface IHasPositionComponent : IComponent
{
  Vector2 Position { get; set; }
}

public interface ISizeComponent : IComponent
{
  Vector2 Size { get; set; }
}

public interface IHasTargetPositionComponent : IComponent
{
  Vector2 TargetPosition { get; set; }
}

public interface IHasSpeedComponent : IComponent
{
  int Speed { get; set; }
}

public interface IHasFacingDirectionComponent : IComponent
{
  Vector2 FacingDirection { get; set; }
}

public interface ITrackPositionComponent : IComponent
{
  Vector2 LastPosition { get; set; }
}

public interface IHasTargetAreaComponent : IComponent, ISizeComponent, IHasTargetPositionComponent
{
}

public interface IHasTargetEntityComponent : IComponent
{
  IUniqueNameComponent TargetUniqueName { get; set; }
}

public interface IIdentifiableTargetComponent : IComponent
{
  IUniqueNameComponent Target { get; set; }
}

// Defines properties for entities that can be alive or dead
public interface IAliveComponent : IComponent
{
  bool IsAlive { get; set; }
}

// Defines properties for entities that have a body
public interface IBodyComponent : IComponent
{
}

public interface IAttributeComponent : IHasAbbreviation, IUniqueNameComponent, ILevelComponent
{
}

public interface IHasAbbreviation : IComponent
{
  string Abbreviation { get; set; }
}

// Defines properties for entities with attributes
public interface IAttributeListComponent : IComponent
{
  EntityAttributesComponent Attributes { get; set; }
}


/// A name that can be compared. If the element is used in an item, its unique name should be 'orange', so it can be compared to other items with the same name.
[JsonConverter(typeof(JsonBaseUniqueNameConverter))]
public interface IUniqueNameComponent : IComponent
{
  string UniqueName { get; }
}

public interface IEntityBehaviourComponent : IComponent, IHasPositionComponent, IHasTargetPositionComponent
{
  BehaviourType BehaviourType { get; set; }

  IUniqueNameComponent? CurrentStage { get; set; }

  void RunEntityBehaviour(BaseEntity entity);
}

public interface IActionComponent : IComponent, IUniqueNameComponent
{
  void Execute();
}

public interface IActionDictionaryComponent : IComponent
{
  Dictionary<string, IActionComponent> ActionByUniqueName { get; set; }
}

public interface IMovementComponent : IComponent, IHasTargetPositionComponent, IHasSpeedComponent, IHasFacingDirectionComponent, ITrackPositionComponent
{
  int SpeedModifier { get; set; }
}

public interface IAttackComponent : IComponent, IAttackCommandComponent
{
  IUniqueNameComponent Attacker { get; set; }
}

public interface IAttackCommandComponent : IComponent
{
  void Execute(IAttackParametersComponent attackParameters);
}

public interface ICommandComponent : IComponent
{
  void Execute();
}

public interface IAttackParametersComponent : IComponent
{
  int WeaponDamage { get; set; }

  AttackRangeType RangeType { get; set; }

  DamageType DamageType { get; set; }

  ElementalProperty ElementalProperty { get; set; }

  IUniqueNameComponent? Target { get; set; }
}

public interface IAnimatedBodyComponent : IComponent
{
  Dictionary<string, BodyPartComponent> PartsByComponent { get; set; }
}

public interface IBodyPartComponent : IComponent, IAnimatedPartComponent, IUniqueNameComponent
{

}

public interface IAnimatedPartComponent : IComponent
{
  BehaviourType DefaultAnimation { get; set; }

  List<BehaviourType> AvailableAnimations { get; set; }
}

public interface IEntityRoutineComponent : IComponent
{
  Dictionary<int, IEntityBehaviourComponent> EntityBehaviourByGameTime { get; set; }
}

public interface IEntityScheduleComponent : IComponent
{
  IEntityRoutineComponent DefaultRoutine { get; set; }
  Dictionary<int, IEntityRoutineComponent> EntityRoutineByGameDay { get; set; }
}

public interface IIdComponent : IComponent
{
  Guid Id { get; }
}

public interface IBuildComponent<T> : IComponent
{
  T Build();
}


public interface ICanSaveFileComponent : IComponent
{
  void SaveFile();
}

public interface ICanLoadFileComponent<T> : IComponent
{
  T LoadFile();
}

public interface IHasSaveFolderComponent : IComponent
{
  string SaveFolder { get; set; }
}