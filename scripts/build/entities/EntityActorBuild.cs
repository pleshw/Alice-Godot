using Game;

namespace Build;

public abstract class EntityActorBuild<T> : ICanSaveFileComponent, ICanLoadFileComponent<T>
where T : BaseEntity
{
  public abstract T Actor { get; }

  public void SaveFile()
  {
    FileController.CreateProjectFile(
                $"{FileController.GodotSavesFolder}{Actor.SaveFolder}/entity/{Actor.UniqueName}/",
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
    T? result = FileController.GetFileDeserialized<T>($"{FileController.GodotSavesFolder}{Actor.SaveFolder}/entity/{actorUniqueName}/actor.json");

    if (result != null)
    {
      return result;
    }

    SaveFile();
    return Actor;
  }
}