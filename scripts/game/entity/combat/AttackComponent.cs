using System.Numerics;

namespace Game;

public class AttackComponent : IAttackComponent
{
  public required IUniqueNameComponent Attacker { get; set; }

  public void Execute(IAttackParametersComponent attackParameters)
  {
    throw new NotImplementedException();
  }
}