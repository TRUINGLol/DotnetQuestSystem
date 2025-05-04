## `QuestManager`

**Description:** Manages the quest system, providing methods to start, finish, and cancel quests. Implements the singleton design pattern to ensure a single instance of the manager.

### Properties

| Name                | Type                     | Description |
| ------------------- | ------------------------ | ----------- |
| `instance`          | [QuestManager](#questmanager) | The singleton instance of the `QuestManager`. |
| `questController`   | [QuestController](#questcontroller) | The controller responsible for managing quest operations. |
| `questDatabase`     | [QuestDatabase](#questdatabase) | The database that stores all quests. |

### Constructors

#### _QuestManager()_
> Initializes a new instance of the `QuestManager`. This constructor is private to enforce the singleton pattern.

### Methods

| Name                                   | Return Type                     |
| -------------------------------------- | ------------------------------- |
| [**StartQuest**](#void-startquestquest)**(Quest quest)** | **void**                        |
| [**FinishQuest**](#ireward-finishquestquest)**(Quest quest)** | **IReward?**                   |
| [**CancelQuest**](#void-cancelquestquest)**(Quest quest)** | **void**                        |
| [**InvokeQuestStatusChanged**](#void-invokequeststatuschangedquest)**(Quest quest)** | **void**                        |

#### _void StartQuest(Quest quest)_
> Starts a specified quest by changing its status to 'Current'.

- **Parameters:**
  - `quest`: The [`Quest`](#quest) object to be started.

#### _IReward? FinishQuest(Quest quest)_
> Finishes a specified quest by changing its status to 'Complete'. Invokes the completion event and returns the reward associated with the quest.

- **Parameters:**
  - `quest`: The [`Quest`](#quest) object to be finished.
- **Returns:** The reward associated with the completed quest, or null if no reward exists.

#### _void CancelQuest(Quest quest)_
> Cancels a specified quest by changing its status to 'Canceled'.

- **Parameters:**
  - `quest`: The [`Quest`](#quest) object to be canceled.

#### _void InvokeQuestStatusChanged(Quest quest)_
> Invokes the event that notifies subscribers about changes in a quest's status.

- **Parameters:**
  - `quest`: The [`Quest`](#quest) object whose status has changed.

### Events

| Name                          | Description |
| ----------------------------- | ----------- |
| `OnQuestCompleate`           | Event triggered when a quest is completed. |
| `OnQuestStatusChanged`       | Event triggered when a quest's status changes. |

### Summary

The `QuestManager` class serves as a central hub for managing quests within a game. It allows for starting, finishing, and canceling quests while ensuring that only one instance of the manager exists through the singleton design pattern. Additionally, it provides events for notifying subscribers about changes in quest statuses and completions.`.