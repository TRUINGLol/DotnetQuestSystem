namespace dotnetquestsystem;

using System.Collections.Generic;

/// <summary>
/// Provides a database implementation of the <see cref="ISaveSystemStrategy"/> interface for saving and loading quests.
/// </summary>
///TODO
public class QuestDatabaseSave : ISaveSystemStrategy{
    public void Save(List<Quest> quests, string pathToSave){}

    public List<Quest> Load(string pathToData){
        return new List<Quest>();
    }
}