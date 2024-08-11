using Godot;
using System;

public partial class MenuControl : Control
{
  public MenuManager MenuManager
  {
    get
    {
      return GetNode<MenuManager>("/root/MenuManager");
    }
  }
}
