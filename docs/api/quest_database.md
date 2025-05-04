## `QuestDatabase`
**Description:** Represents a database for storing quests, providing methods to save and load quests.

### Properties

| Name      | Type                     | Description |
| --------- | ------------------------ | ----------- |
| `Quests`  | List<Quest>             | List of quests in the database. |

### Methods

| Name                                   | Return Type                     |
| -------------------------------------- | ------------------------------- |
| [**SetSaveType**](#void-setsavetypeisavesystemstrategy)**(ISaveSystemStrategy saveType)** | **void**                        |
| [**SaveQuests**](#void-savequestsstring)**(string pathToSave)** | **void**                        |
| [**LoadQuests**](#void-loadquestsstring)**(string pathToData)** | **void**                        |

#### _void SetSaveType(ISaveSystemStrategy saveType)_
> Sets the save strategy to be used for saving and loading quests. By default, the `QuestLocalSave` type is set

- **Parameters:**
  - `saveType`: The [`ISaveSystemStrategy`](#isavesystemstrategy) implementation to use for saving and loading quests.

#### _void SaveQuests(string pathToSave = "./database/Quests.json")_
> Saves the current list of quests to a specified file path.

- **Parameters:**
  - `pathToSave`: The file path where the quests will be saved (default is `"./database/Quests.json"`).

#### _void LoadQuests(string pathToData = "./database/Quests.json")_
> Loads quests from a specified file path into the database.

- **Parameters:**
  - `pathToData`: The file path from which to load the quests (default is `"./database/Quests.json"`).

### Summary

The `QuestDatabase` class serves as a storage system for managing quests within a game. It provides functionality to save and load quests using a specified saving strategy, allowing for flexibility in how quest data is handled. The class maintains a list of quests and offers methods to set the saving strategy, save the current list of quests to a file, and load quests from a file into the database.

>You can also create your own quest saving strategy by creating a class that implements the `ISaveSystemStrategy` interface.