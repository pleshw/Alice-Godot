using Build;
using Game;
using Godot;
using System;

public partial class Main : MainSceneNode
{
	public MainMenu MainMenu { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var playerBuilder = new PlayerActorBuild();
		var player = playerBuilder.LoadFile();

		RelationshipComponent playerRelationship = player.ComponentDictionary[typeof(RelationshipComponent)] as RelationshipComponent;

		MainMenu mainMenu = MenuCanvas.GetNode<MainMenu>("MainMenu");
		mainMenu.MenuManager.ShowMainMenu();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
