## `Quest`

### Description

The `Quest` class represents a basic structure for quests in a game. It contains information about the quest's title, description, status, and objective, as well as any potential rewards for its completion. The class provides methods for changing the quest's status and initializing its properties.

### Properties

| Name           | Type        | Description |
| ---------------| ------------| ------------|
| `Name`         | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The title of the quest. |
| `Description`  | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A description of the quest. |
| `Status`       | [QuestStatus](#queststatus) | The current status of the quest. |
| `Reward`       | [IReward?](#ireward) | The reward associated with the quest, if any; defaults to null. |
| `Objective`    | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The objective of the quest. |

### Constructors

#### _Quest(string name, string description, string objective, IReward reward)_
> Initializes a new instance of the `Quest` class with the specified title, description, objective and reward.

- **Parameters:**
  - `name`: The title of the quest.
  - `description`: A description of the quest.
  - `objective`: The objective of the quest.
  - `reward`: The reward associated with the quest.

#### _Quest(string name, string description, string objective)_
> Initializes a new instance of the `Quest` class with the specified title, objective and description.

- **Parameters:**
  - `name`: The title of the quest.
  - `description`: A description of the quest.
  - `objective`: The objective of the quest.

### Methods

| Name | Return Type |
| ---- | ----------- |
| [**ChangeQuestStatus**](#void-changequeststatusqueststatus-newstatus)**(QuestStatus newStatus)** | **void** |

#### _void ChangeQuestStatus(QuestStatus newStatus)_
> Changes the status of the quest to the specified new status.

- **Parameters:**
  - `newStatus`: The new status to set for the quest.

### Summary

The `Quest` class provides essential properties and methods for managing the state and information about quests in a game. It allows setting titles and descriptions for quests, as well as managing their statuses and rewards. The method `ChangeQuestStatus` allows changing a quest's status and notifying the quest management system about changes through a call to this method in an instance of the `QuestManager`.