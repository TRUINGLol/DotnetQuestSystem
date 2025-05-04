namespace dotnetquestsystem;

using System;
using System.Collections.Generic;

/// <summary>
/// Provides methods to create, delete, and retrieve quests in the quest management system.
/// </summary>
public sealed class QuestController{
    /// <summary>
    /// Creates a new quest with the specified name and description.
    /// </summary>
    /// <param name="name">The name of the quest.</param>
    /// <param name="description">The description of the quest.</param>
    /// <returns>The newly created <see cref="Quest"/> object.</returns>
    public Quest CreateQuest(string name, string description, string objective){
        Quest quest = new Quest(name,description,objective);
        QuestManager.instance.questDatabase.Quests.Add(quest);
        return quest;
    }

    /// <summary>
    /// Creates a new quest with the specified name, description, and reward.
    /// </summary>
    /// <param name="name">The name of the quest.</param>
    /// <param name="description">The description of the quest.</param>
    /// <param name="reward">The reward associated with the quest.</param>
    /// <returns>The newly created <see cref="Quest"/> object.</returns>
    public Quest CreateQuest(string name, string description, string objective, IReward reward){
        Quest quest = new Quest(name,description,objective,reward);
        QuestManager.instance.questDatabase.Quests.Add(quest);
        return quest;
    }

    /// <summary>
    /// Deletes a specified quest from the quest database.
    /// </summary>
    /// <param name="questToDelete">The <see cref="Quest"/> object to be deleted.</param>
    public void DeleteQuest(Quest questToDelete){
        QuestManager.instance.questDatabase.Quests.Remove(questToDelete);
    }

    /// <summary>
    /// Retrieves a quest by its name.
    /// </summary>
    /// <param name="name">The name of the quest to retrieve.</param>
    /// <returns>The matching <see cref="Quest"/> object if found; otherwise, null.</returns>
    public Quest? GetQuestByName(string name){
        Predicate<Quest> matchByName = (quest) => quest.Name.Equals(name,StringComparison.OrdinalIgnoreCase);
        return QuestManager.instance.questDatabase.Quests.Find(matchByName);
    }

    /// <summary>
    /// Retrieves all quests in the quest database.
    /// </summary>
    /// <returns>A list of all available <see cref="Quest"/> objects.</returns>
    public List<Quest> GetAllQuests(){
        return QuestManager.instance.questDatabase.Quests;
    }
}