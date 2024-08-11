using Godot;
using System;

public partial class MainMenu : MenuControl
{
  [Export]
  public Button LoadGameButton { get; set; }

  [Export]
  public Button NewGameButton { get; set; }

  [Export]
  public Button OptionsButton { get; set; }

  [Export]
  public Button QuitButton { get; set; }

  public override void _Ready()
  {
    base._Ready();


    NewGameButton.Pressed += () =>
    {

    };

    OptionsButton.Pressed += () =>
    {

    };

    QuitButton.Pressed += () => GetTree().Quit();
  }
}
