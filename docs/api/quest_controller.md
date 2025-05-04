## `QuestController`
**Description:** Provides methods to create, delete, and retrieve quests in the quest management system.

### Methods

| Name                                   | Return Type                     |
| -------------------------------------- | ------------------------------- |
| [**CreateQuest**](#quest-createqueststring-string-string)**(string name, string description, string objective)** | **Quest**                       |
| [**CreateQuest**](#quest-createqueststring-string-string-ireward)**(string name, string description, string objective, IReward reward)** | **Quest**                       |
| [**DeleteQuest**](#void-deletequestquest)**(Quest questToDelete)** | **void**                        |
| [**GetQuestByName**](#quest-getquestbynamestring)**(string name)** | **Quest?**                     |
| [**GetAllQuests**](#listquest-getallquests)**()** | **List <Quest**                |

#### _Quest CreateQuest(string name, string description, string objective)_
> Creates a new quest with the specified name, objective and description. And adds it to `QuestDatabase`. 

- **Parameters:**
  - `name`: The name of the quest.
  - `description`: The description of the quest.
  - `objective`: The objective of the quest.
- **Returns:** The newly created [`Quest`](#quest) object.

#### _Quest CreateQuest(string name, string description, string objective, IReward reward)_
> Creates a new quest with the specified name, description, objective and reward. And adds it to `QuestDatabase`.

- **Parameters:**
  - `name`: The name of the quest.
  - `description`: The description of the quest.
  - `objective`: The objective of the quest.
  - `reward`: The reward associated with the quest.
- **Returns:** The newly created [`Quest`](#quest) object.

#### _void DeleteQuest(Quest questToDelete)_
> Deletes a specified quest from the quest database.

- **Parameters:**
  - `questToDelete`: The [`Quest`](#quest) object to be deleted.

#### _Quest? GetQuestByName(string name)_
> Retrieves a quest by its name.

- **Parameters:**
  - `name`: The name of the quest to retrieve.
- **Returns:** The matching [`Quest`](#quest) object if found; otherwise, null.

#### _List<Quest> GetAllQuests()_
> Retrieves all quests in the quest database.

- **Returns:** A list of all available [`Quest`](#quest) objects.

### Summary

The `QuestController` class is responsible for managing quests within a game. It provides functionality to create new quests (with or without rewards), delete existing quests from the database, and retrieve quests either by their names or as a complete list. This class acts as an interface between the user and the underlying data structure that holds all quests.