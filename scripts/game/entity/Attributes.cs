namespace Game;

public class Agility : IAttributeComponent
{
  public int Level { get; set; } = 0;

  public string Abbreviation { get; set; } = "agi";

  public string UniqueName { get; set; } = "Agility";
}

public class Dexterity : IAttributeComponent
{
  public int Level { get; set; } = 0;

  public string Abbreviation { get; set; } = "dex";

  public string UniqueName { get; set; } = "Dexterity";
}

public class Intelligence : IAttributeComponent
{
  public int Level { get; set; } = 0;

  public string Abbreviation { get; set; } = "int";

  public string UniqueName { get; set; } = "Intelligence";
}

public class Luck : IAttributeComponent
{
  public int Level { get; set; } = 0;

  public string Abbreviation { get; set; } = "luk";

  public string UniqueName { get; set; } = "Luck";
}

public class Strength : IAttributeComponent
{
  public int Level { get; set; } = 0;

  public string Abbreviation { get; set; } = "str";

  public string UniqueName { get; set; } = "Strength";
}

public class Vitality : IAttributeComponent
{
  public int Level { get; set; } = 0;

  public string Abbreviation { get; set; } = "vit";

  public string UniqueName { get; set; } = "Vitality";
}