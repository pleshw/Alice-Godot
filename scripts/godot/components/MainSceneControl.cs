
using Godot;
using System;

public partial class MainSceneNode : Node
{
  public Node MainScene
  {
    get
    {
      return GetTree().Root.GetNode<Node>("Main");
    }
  }

  private Node _menuContainer;
  public Node MenuContainer
  {
    get
    {
      return _menuContainer ??= MainScene.GetNode<Node>("MenuContainer");
    }
  }

  private CanvasLayer _menuCanvas;
  public CanvasLayer MenuCanvas
  {
    get
    {
      return _menuCanvas ??= MenuContainer.GetNode<CanvasLayer>("MenuCanvas");
    }
  }

  private Node _gameContainer;
  public Node GameContainer
  {
    get
    {
      return _gameContainer ??= MainScene.GetNode<Node>("GameContainer");
    }
  }

  private CanvasLayer _gameCanvas;
  public CanvasLayer GameCanvas
  {
    get
    {
      return _gameCanvas ??= GameContainer.GetNode<CanvasLayer>("GameCanvas");
    }
  }
}

