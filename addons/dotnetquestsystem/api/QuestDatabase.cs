namespace dotnetquestsystem;

using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

/// <summary>
/// Represents a database for storing quests, providing methods to save and load quests.
/// </summary>
public sealed class QuestDatabase{
    /// <summary>
    /// List of quests in the database.
    /// </summary>
    public List<Quest> Quests {get;set;} = new List<Quest>();

    private ISaveSystemStrategy _saveStrategy = new QuestLocalSave();

    /// <summary>
    /// Sets the save strategy to be used for saving and loading quests.
    /// </summary>
    /// <param name="saveType">The <see cref="ISaveSystemStrategy"/> implementation to use for saving and loading quests.</param>
    public void SetSaveType(ISaveSystemStrategy saveType){
        _saveStrategy = saveType;
    }

    /// <summary>
    /// Saves the current list of quests to a specified file path.
    /// </summary>
    /// <param name="pathToSave">The file path where the quests will be saved..</param>
    public void SaveQuests(string pathToSave = "./database/Quests.json"){
        _saveStrategy.Save(Quests, pathToSave);
    }

    /// <summary>
    /// Loads quests from a specified file path into the database.
    /// </summary>
    /// <param name="pathToData">The file path from which to load the quests.</param>
    public void LoadQuests(string pathToData = "./database/Quests.json"){
        Quests = _saveStrategy.Load(pathToData);
    }
}