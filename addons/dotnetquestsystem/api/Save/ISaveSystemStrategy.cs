namespace dotnetquestsystem;

using System.Collections.Generic; 

public interface ISaveSystemStrategy{
    /// <summary>
    /// Saves a list of quests to a specified file path.
    /// </summary>
    /// <param name="quests">The list of quests to be saved.</param>
    /// <param name="pathToSave">The file path where the quests will be saved.</param>
    void Save(List<Quest> quests, string pathToSave);

    /// <summary>
    /// Loads a list of quests from a specified file path.
    /// </summary>
    /// <param name="pathToData">The file path from which the quests will be loaded.</param>
    /// <returns>A list of quests loaded from the specified file.</returns>
    List<Quest> Load(string pathToData);
}