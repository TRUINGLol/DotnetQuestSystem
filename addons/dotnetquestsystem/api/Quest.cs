namespace dotnetquestsystem;

using System.Text.Json.Serialization;

/// <summary>
/// Represents a quest.
/// </summary>
public class Quest{
    /// <summary>
    /// Name of the quest.
    /// </summary>
    public string Name {get;}

    /// <summary>
    /// Description of the quest.
    /// </summary>
    public string Description {get;}

    /// <summary>
    /// Current status of the quest.
    /// </summary>
    public QuestStatus Status {get; private set;}

    /// <summary>
    /// Reward associated with the quest, if any;
    /// Null by defualt
    /// </summary>
    public IReward? Reward {get;} = null;

    public string Objective {get;}

     /// <summary>
    /// Initializes a new instance of the <see cref="Quest"/> class with a specified name, description, and reward.
    /// </summary>
    /// <param name="name">The name of the quest.</param>
    /// <param name="description">The description of the quest.</param>
    /// <param name="reward">The reward associated with the quest.</param>
    [JsonConstructor]
    public Quest(string name, string description, string objective, IReward reward){
        Name = name;
        Description = description;
        Objective = objective;
        Status = QuestStatus.New;
        Reward = reward;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Quest"/> class with a specified name and description.
    /// </summary>
    /// <param name="name">The name of the quest.</param>
    /// <param name="description">The description of the quest.</param>
    public Quest(string name, string description, string objective){
        Name = name;
        Description = description;
        Objective = objective;
        Status = QuestStatus.New;
    }

    /// <summary>
    /// Changes the status of the quest to a new specified status.
    /// </summary>
    /// <param name="newStatus">The new status to set for the quest.</param>
    public void ChangeQuestStatus(QuestStatus newStatus){
        Status = newStatus;
        QuestManager.instance.InvokeQuestStatusChanged(this);
    }
}