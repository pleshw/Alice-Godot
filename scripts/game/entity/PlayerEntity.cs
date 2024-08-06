using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class PlayerEntity : BaseEntity
{
  public PlayerEntity(string uniqueName) : base(uniqueName)
  {
    AddComponent(new DisplayNameComponent
    {
      DisplayName = "Alice"
    });

    AddComponent(new HasPositionComponent
    {
      Position = Vector2.Zero
    });

    AddComponent(new InventoryComponent
    {
      Owner = this,
      Items = [],
      MaxStackSize = 10
    });

    AddComponent(new EntityAttributesComponent
    {
      Agility = new() { Level = 1 },
      Dexterity = new() { Level = 1 },
      Intelligence = new() { Level = 1 },
      Luck = new() { Level = 1 },
      Strength = new() { Level = 1 },
      Vitality = new() { Level = 1 }
    });

    AddComponent(new AliveComponent
    {
      IsAlive = true
    });

    AddComponent(new RelationshipComponent
    {
      CompletedDialogs = [],
      Level = 0,
    });

    AddComponent(new QuestListComponent
    {
      OnGoingQuests = [],
      CancelledQuests = [],
      CompletedQuests = []
    });

    AddComponent(new ActionDictionaryComponent
    {
      ActionByUniqueName = []
    });

    AddComponent(new AnimatedBodyComponent
    {
      PartsByComponent = new()
      {
        {
          "Hat", new BodyPartComponent
          {
            UniqueName = "Hat",
            AvailableAnimations = [BehaviourType.IDLE, BehaviourType.MOVING],
            DefaultAnimation = BehaviourType.IDLE,
          }
        },
        {
          "Body", new BodyPartComponent
          {
            UniqueName = "Body",
            AvailableAnimations =
            [
              BehaviourType.IDLE,
              BehaviourType.MOVING,
              BehaviourType.ATTACKING,
              BehaviourType.CASTING,
              BehaviourType.GATHERING,
              BehaviourType.MINING,
              BehaviourType.LOGGING,
              BehaviourType.REFINING,
              BehaviourType.CRAFTING,
              BehaviourType.FISHING,
              BehaviourType.TALKING
            ],
            DefaultAnimation = BehaviourType.IDLE,
          }
        },
        {
          "Shirt", new BodyPartComponent
          {
            UniqueName = "Shirt",
            AvailableAnimations =
            [
              BehaviourType.IDLE,
              BehaviourType.MOVING,
              BehaviourType.ATTACKING,
              BehaviourType.CASTING,
              BehaviourType.GATHERING,
              BehaviourType.MINING,
              BehaviourType.LOGGING,
              BehaviourType.REFINING,
              BehaviourType.CRAFTING,
              BehaviourType.FISHING,
              BehaviourType.TALKING
            ],
            DefaultAnimation = BehaviourType.IDLE,
          }
        },
        {
          "Pants", new BodyPartComponent
          {
            UniqueName = "Pants",
            AvailableAnimations =
            [
              BehaviourType.IDLE,
              BehaviourType.MOVING,
              BehaviourType.ATTACKING,
              BehaviourType.GATHERING,
              BehaviourType.MINING,
              BehaviourType.LOGGING,
              BehaviourType.REFINING,
              BehaviourType.CRAFTING,
              BehaviourType.FISHING
            ],
            DefaultAnimation = BehaviourType.IDLE,
          }
        },
        {
          "Boots", new BodyPartComponent
          {
            UniqueName = "Boots",
            AvailableAnimations =
            [
              BehaviourType.IDLE,
              BehaviourType.MOVING,
              BehaviourType.ATTACKING,
              BehaviourType.CASTING,
              BehaviourType.GATHERING,
              BehaviourType.MINING,
              BehaviourType.LOGGING,
              BehaviourType.FISHING
            ],
            DefaultAnimation = BehaviourType.IDLE,
          }
        },
      }
    });

    AddComponent(new MovementComponent
    {
      Speed = 1,
      TargetPosition = new(),
      FacingDirection = new(),
      LastPosition = new(),
      SpeedModifier = 1
    });

    AddComponent(new AttackComponent
    {
      Attacker = this
    });
  }

  [JsonConstructor]
  public PlayerEntity(string uniqueName, List<IComponent> components) : base(uniqueName, components)
  {

  }

  public override IComponent Clone()
  {
    throw new NotImplementedException();
  }
}