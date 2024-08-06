namespace Game;

public enum TaskType
{
  COLLECT,
  HUNT,
  FIND,
  ESCORT,
  REACH_POSITION,
  REACH_ENTITY
}

public enum MenuType
{
  NONE,
  SHOP,
  CRAFT,
  PICK_ITEM
}

public enum AttackOutcome
{
  NOT_ENOUGH_RANGE,
  MISS,
  HIT,
  NOT_EFFECTIVE,
  CRITICAL
}

public enum ElementalProperty
{
  NEUTRAL,
  FIRE,
  EARTH,
  WIND,
  WATER
}

public enum DamageType
{
  PHYSICAL,

  MAGICAL
}

public enum AttackRangeType
{
  MELEE,

  RANGED
}

public enum BehaviourType
{
  IDLE,
  MOVING,
  ATTACKING,
  CASTING,
  GATHERING,
  MINING,
  LOGGING,
  REFINING,
  CRAFTING,
  FISHING,
  TALKING
}

[Flags]
public enum MasteryTypes
{
  NONE = 1 << 0,
  BATTLING = 1 << 1,
  CRAFTING = 1 << 2,
  MINING = 1 << 3,
  GATHERING = 1 << 4,
  LOGGING = 1 << 5,
  REFINING = 1 << 6,
  FISHING = 1 << 7,
}

[Flags]
public enum ItemTypes
{
  NONE = 1 << 0,
  CONSUMABLE = 1 << 1,
  ARMOR = 1 << 2,
  WEAPON = 1 << 3,
  ACCESSORY = 1 << 4,
  MISC = 1 << 5,
  QUEST = 1 << 6,
  ORE = 1 << 7,
}

[Flags]
public enum GridCellStatus
{
  NONE = 1 << 0,
  FREE = 1 << 1,
  BLOCKED = 1 << 2,
  OCCUPIED = 1 << 3,
  VISITED = 1 << 4,
  HIDDEN = 1 << 5,
  HIGHLIGHTED = 1 << 6
}