using Game;

namespace Build;

public abstract class StageBuild<T> : ICanSaveFileComponent, ICanLoadFileComponent<T>
where T : StageComponent
{
  public abstract T Stage { get; }

  public void SaveFile()
  {
    FileController.CreateProjectFile(
                $"stage/{Stage.UniqueName}/",
                "stage.json",
                Stage
        );
  }

  public T LoadFile()
  {
    T? result = FileController.GetFileDeserialized<T>($"C:/Users/Usuário/Desktop/echo-box/data/stage/{Stage.UniqueName}/stage.json");

    if (result != null)
    {
      return result;
    }

    SaveFile();
    return Stage;
  }
}