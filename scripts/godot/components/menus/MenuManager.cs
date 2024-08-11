using Godot;
using System;

public partial class MenuManager : MainSceneNode
{
  public Stack<Control> MenuHistory = [];

  private MainMenu _mainMenu;
  public MainMenu MainMenu
  {
    get
    {
      return _mainMenu ??= MenuCanvas.GetNode<MainMenu>("MainMenu");
    }
  }

  public List<Control> AllMenus
  {
    get
    {
      return MenuCanvas.GetChildren().Select(m => (Control)m).ToList();
    }
  }

  public void HideMenus()
  {
    MenuCanvas.Hide();
    GameCanvas.Show();

    MenuHistory.Clear();
  }

  public void ShowMainMenu()
  {
    GameCanvas.Hide();
    AllMenus.ForEach(m => m.Hide());

    MenuCanvas.Show();

    MenuHistory.Push(MainMenu);
    MenuHistory.Peek().Show();
  }
}