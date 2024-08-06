using System.Text.Json.Serialization;

namespace Game;

public class EntityAttributesComponent : IEntityAttributesComponent
{

  public Agility Agility { get; set; }


  public Dexterity Dexterity { get; set; }


  public Intelligence Intelligence { get; set; }


  public Luck Luck { get; set; }


  public Strength Strength { get; set; }


  public Vitality Vitality { get; set; }

  public EntityAttributesComponent()
  {
    Agility = new();
    Dexterity = new();
    Intelligence = new();
    Luck = new();
    Strength = new();
    Vitality = new();
  }

  [JsonConstructor]
  public EntityAttributesComponent(Agility Agility, Dexterity Dexterity, Intelligence Intelligence, Luck Luck, Strength Strength, Vitality Vitality)
  {
    this.Agility = Agility ?? new();
    this.Dexterity = Dexterity ?? new();
    this.Intelligence = Intelligence ?? new();
    this.Luck = Luck ?? new();
    this.Strength = Strength ?? new();
    this.Vitality = Vitality ?? new();
  }
}