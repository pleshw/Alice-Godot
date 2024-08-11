using Game;

namespace Build;

public abstract class EntityActorBuild<T> : ICanSaveFileComponent, ICanLoadFileComponent<T>
where T : BaseEntity
{
  public abstract T Actor { get; }

  public string ActorSaveFolder
  {
    get
    {
      return $"{FileController.GodotSavesFolder}{Actor.SaveFolder}";
    }
  }

  public void SaveFile()
  {
    FileController.CreateProjectFile(
                $"{ActorSaveFolder}/entity/{Actor.UniqueName}/",
                "actor.json",
                Actor
        );
  }

  public T LoadFile()
  {
    return LoadFile(Actor.UniqueName);
  }

  public T LoadFile(string actorUniqueName)
  {
    T result = FileController.GetFileDeserialized<T>($"{ActorSaveFolder}/entity/{actorUniqueName}/actor.json");

    if (result != null)
    {
      return result;
    }

    SaveFile();
    return Actor;
  }
}