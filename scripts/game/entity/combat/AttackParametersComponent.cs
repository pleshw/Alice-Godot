using System.Numerics;

namespace Game;

public class AttackParametersComponent : IAttackParametersComponent
{
  public required int WeaponDamage { get; set; }

  public required AttackRangeType RangeType { get; set; }

  public required DamageType DamageType { get; set; }

  public required ElementalProperty ElementalProperty { get; set; }

  public IUniqueNameComponent? Target { get; set; }
}