namespace dotnetquestsystem;

using System;

/// <summary>
/// Manages the quest system, providing methods to start, finish, and cancel quests.
/// Implements the singleton design pattern to ensure a single instance of the manager.
/// </summary>
public class QuestManager{
    private static readonly Lazy<QuestManager> _Singleton = new Lazy<QuestManager>(()=>new QuestManager());
    public static QuestManager instance => _Singleton.Value;

    /// <summary>
    /// The controller responsible for managing quest operations.
    /// </summary>
    public QuestController questController = new QuestController();

    /// <summary>
    /// The database that stores all quests.
    /// </summary>
    public QuestDatabase questDatabase = new QuestDatabase();

    private QuestManager(){}
    static QuestManager(){}

    /// <summary>
    /// Starts a specified quest by changing its status to 'Current'.
    /// </summary>
    /// <param name="quest">The <see cref="Quest"/> object to be started.</param>
    public void StartQuest(Quest quest){
        quest.ChangeQuestStatus(QuestStatus.Current);
    }

    /// <summary>
    /// Finishes a specified quest by changing its status to 'Complete'.
    /// Invokes the completion event and returns the reward associated with the quest.
    /// </summary>
    /// <param name="quest">The <see cref="Quest"/> object to be finished.</param>
    /// <returns>The reward associated with the completed quest, or null if no reward exists.</returns>
    public IReward? FinishQuest(Quest quest){
        quest.ChangeQuestStatus(QuestStatus.Complete);
        OnQuestCompleate?.Invoke(quest);
        return quest.Reward;
    }

    /// <summary>
    /// Cancels a specified quest by changing its status to 'Canceled'.
    /// </summary>
    /// <param name="quest">The <see cref="Quest"/> object to be canceled.</param>
    public void CancelQuest(Quest quest){
        quest.ChangeQuestStatus(QuestStatus.Canceled);
    }
    
    /// <summary>
    /// Invokes the event that notifies subscribers about changes in a quest's status.
    /// </summary>
    /// <param name="quest">The <see cref="Quest"/> object whose status has changed.</param>
    public void InvokeQuestStatusChanged(Quest quest){
        OnQuestStatusChanged?.Invoke(quest);
    }
    
    /// <summary>
    /// Event triggered when a quest is completed.
    /// </summary>
    public event Action<Quest>? OnQuestCompleate;

    /// <summary>
    /// Event triggered when a quest's status changes.
    /// </summary>
    public event Action<Quest>? OnQuestStatusChanged;
}