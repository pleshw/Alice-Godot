using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

[JsonConverter(typeof(JsonDisplayImageConverter))]
public class DisplayImageComponent : IDisplayImageComponent
{
  public required string DisplayImage { get; set; }

  public void LoadImage()
  {
    throw new NotImplementedException();
  }
}