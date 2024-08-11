using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public abstract class BaseEntity : IUniqueNameComponent, IHasSaveFolderComponent
{
  public string UniqueName { get; set; }

  public required string SaveFolder { get; set; }

  [JsonIgnore]
  private readonly Dictionary<Type, IComponent> _components = [];

  [JsonInclude]
  public List<IComponent> Components
  {
    get
    {
      return [.. _components.Values];
    }
  }

  [JsonIgnore]
  public Dictionary<Type, IComponent> ComponentDictionary
  {
    get
    {
      return _components;
    }
  }

  public BaseEntity(string uniqueName)
  {
    UniqueName = uniqueName;
  }

  [JsonConstructor]
  public BaseEntity(string uniqueName, List<IComponent> components)
  {
    UniqueName = uniqueName;

    foreach (var component in components)
    {
      _components[component.GetType()] = component;
    }
  }

  public void AddComponent(IComponent component)
  {
    _components[component.GetType()] = component;
  }

  public void AddComponent<T>(T component) where T : IComponent
  {
    _components[component.GetType()] = component;
  }

  public T GetComponent<T>() where T : IComponent
  {
    if (!_components.TryGetValue(typeof(T), out IComponent component))
    {
      throw new Exception($"Component {typeof(T)} does not exist in this entity. Entity Id: {UniqueName}");
    }

    return (T)component;
  }

  public void RemoveComponent<T>() where T : IComponent
  {
    _components.Remove(typeof(T));
  }

  public abstract IComponent Clone();
}