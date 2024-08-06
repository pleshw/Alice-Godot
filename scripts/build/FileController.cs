using System.Text.Json;
using System.Text.RegularExpressions;
using Godot;
using JSONConverters;

namespace Game;

public record class ProjectFileInfo<T>
{
  public required string FolderPath;
  public required string FileName;
  public required T FileData;
}

public static partial class FileController
{
  public static readonly JsonSerializerOptions JsonSerializerOptions = new()
  {
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    Converters = { new JsonBaseComponentConverter(), new JsonVector2Converter() }
  };

  public static string ApplicationBase => AppContext.BaseDirectory;

  public static string ProjectRoot => Path.GetFullPath(Path.Join(ApplicationBase, "..", "..", ".."));

  public static string ProjectDataFolder => Path.Join(ProjectRoot, "/data/");

  public static string GodotUserFolder
  {
    get
    {
      return ProjectSettings.GlobalizePath("user://");
    }
  }

  public static string GodotSavesFolder
  {
    get
    {
      return ProjectSettings.GlobalizePath("user://saves/");
    }
  }

  public static void CreateFile(string folderPath, string fileName, string fileData)
  {
    if (!folderPath.Contains(GodotUserFolder))
    {
      folderPath = Path.Join(GodotUserFolder, folderPath);
    }

    string filePath = Path.Join(folderPath, fileName);

    try
    {
      Directory.CreateDirectory(folderPath);

      File.WriteAllText(filePath, fileData);
    }
    catch (Exception err)
    {
      Console.WriteLine(err);
    }
  }

  public static void CreateProjectFile<T>(List<ProjectFileInfo<T>> fileDataList) => fileDataList.ForEach(f => CreateFile(f.FolderPath, f.FileName, JsonSerializer.Serialize(f.FileData, JsonSerializerOptions)));

  public static void CreateProjectFile<T>(ProjectFileInfo<T> fileData) => CreateFile(fileData.FolderPath, fileData.FileName, JsonSerializer.Serialize(fileData.FileData, JsonSerializerOptions));

  public static void CreateProjectFile<T>(string fileName, T fileData) => CreateProjectFile(fileName, JsonSerializer.Serialize(fileData, JsonSerializerOptions));

  public static void CreateProjectFile(string fileName, string fileData) => CreateProjectFile(GodotUserFolder, fileName, fileData);

  public static void CreateProjectFile<T>(string folderPath, string fileName, T fileData) => CreateProjectFile(folderPath, fileName, JsonSerializer.Serialize(fileData, JsonSerializerOptions));

  public static void CreateProjectFile(string folderPath, string fileName, string fileData) => CreateFile(folderPath, fileName, fileData);

  public static T? GetProjectFileDeserialized<T>(string fileName) where T : class => GetFileDeserialized<T>(Path.Join(GodotUserFolder, fileName));

  public static T? GetFileDeserialized<T>(string filePath) where T : class
  {
    if (!File.Exists(filePath))
    {
      Console.WriteLine($"File not found: {filePath}");
      return default;
    }

    try
    {
      var fileContent = File.ReadAllText(filePath);
      var cc = JsonSerializer.Deserialize(fileContent, typeof(T), JsonSerializerOptions);
      return cc as T;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error reading file: {ex.Message}");
      return default;
    }
  }


  public static string CreateNewSaveFolder(string folderName)
  {
    string? lastFolderWithSameName = GetLastSaveFolderName(GodotSavesFolder, folderName);

    string newSaveFolderName = lastFolderWithSameName != null ? $"{folderName}{GetFolderNumber(lastFolderWithSameName) + 1}" : $"{folderName}0";

    EnsureDirectoryExists(GodotSavesFolder, newSaveFolderName, out string folderPath);

    return folderPath;
  }

  public static string? GetLastSaveFolderName(string folderPath, string folderName)
  {
    string[] saveFolders = Directory.GetDirectories(folderPath, $"{folderName}*");

    string? result = saveFolders.OrderByDescending(f => new DirectoryInfo(f).LastWriteTime).FirstOrDefault();

    if (result is not null && !result.EndsWith('/'))
    {
      result += '/';
    }

    return result;
  }

  public static void EnsureDirectoryExists(string parentFolderPath, string folderName, out string folderPath)
  {
    folderPath = Path.Join(parentFolderPath, folderName);
    if (!Directory.Exists(folderPath))
    {
      Directory.CreateDirectory(folderPath);
    }

    if (!folderPath.EndsWith('/'))
    {
      folderPath += '/';
    }
  }

  public static void EnsureDirectoryExists(string folderName, out string folderPath)
  {
    EnsureDirectoryExists(GodotSavesFolder, folderName, out folderPath);
  }


  public static int GetFolderNumber(string folderName)
  {
    string numberPart = OnlyDigits().Match(folderName).Value;
    if (int.TryParse(numberPart, out int saveNumber))
    {
      return saveNumber;
    }
    else
    {
      return -1; // Indicates failure to parse
    }
  }


  [GeneratedRegex(@"\d+")]
  private static partial Regex OnlyDigits();
}
