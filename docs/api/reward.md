## Reward

As you can see, the `Quest` class allows you to store a `Reward` property that will be returned when the quest is completed via the `FinishQuest()` method of the `QuestManager` instance. The `Reward` property is of type `IReward`, which means you can create your own reward types.

For example, two types of rewards have already been created: `ExperienceReward` and `ItemReward`

To create your own reward type, you need to implement the `IReward` interface.
**Please note** that for the `QuestLocalSave` strategy to work correctly, you will need to add the `JsonDerivedType` attribute for the `IReward` interface, this is due to the polymorphic serialization of `System.Text.Json` used in the `QuestLocalSave` strategy.
For an example, you can go to the source code of already created rewards.

> **_Note_** New reward types will only display correctly in godot editor if they follow the type class name: `NewReward` and are not a generic type.