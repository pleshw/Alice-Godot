using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;


[JsonConverter(typeof(JsonMenuConverter))]
public class MenuComponent : IMenuComponent
{
  public virtual MenuType MenuType { get; set; }

  public required string UniqueName { get; set; }

  public required string DisplayName { get; set; }

  public void Close()
  {
    throw new NotImplementedException();
  }

  public void Open()
  {
    throw new NotImplementedException();
  }
}