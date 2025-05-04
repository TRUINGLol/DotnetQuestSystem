# Getting started with DotnetQuestSystem

This quick guide will help you get started with installing and using the addon in your Godot projects.

## Prerequisites

Before you begin, ensure you have the following:
- Godot.NET.Sdk (version 4.0.0 or higher)
- .NET SDK (version 8.0 or higher)
- Basic knowledge of C# programming

## Installation
1. Download a copy of the `addons` folder
2. Copy the `addons` folder from the downloaded file to your project directory
3. Activate the addon in the editor `Project -> Project Settings -> Plugins`

##  Working with quest via code

Here is a simple example of creating and completing a quest state through code

```
using dotnetquestsystem;
using System;

public partial class PlayersHouse : Control{
	
	public Quest newQuest;
	
	public  override  void  _Ready(){
		newQuest = QuestManager.instance.questController.CreateQuest(
		    "The Secret of the Attic", // Quest name
		    "Locals claim that ancient artifacts and secrets of your family are hidden in the attic.", // Quest description
		    "Solve the riddles" // Quest objective
		);
		
		GD.Print("Quest status: "+ newQuest.Status); // Quest status: New
		
		QuestManager.instance.StartQuest(newQuest);

		GD.Print("Quest status: "+ newQuest.Status); // Quest status: Current
	}

	public void OnSolveRiddles(){
		QuestManager.instance.FinishQuest(newQuest);
		GD.Print("Quest status: "+ newQuest.Status); // Quest status: Complete
	}
}
```

All work with the quest management system API is carried out through the singleton `QuestManager`, which simplifies interaction and management of quest status.

To create a `Quest` object, the `CreateQuest()` method of the `questController` property is used here. Nothing stops you from creating a `Quest` manually via the constructor, but note that in this case the `Quest` object will not be added to the `QuestDatabase` quest store.

After creating a quest, we can start the quest by making its state `Current` using the `StartQuest()` method of the `QuestManager` instance.

To complete a quest and change its status to `Complete`, use the `FinishQuest()` method of the `QuestManager` instance.

> **_NOTE:_** It is worth considering that this addon was created as a library and is aimed at use through code.

## Working with quests via godot editor

After activating the addon, you are provided with an interface in the editor for managing quests. Please note that this interface does not provide the ability to change the status of the quest and is used only for working with the quest database.