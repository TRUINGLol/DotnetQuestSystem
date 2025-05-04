namespace dotnetquestsystem;

using System.Collections.Generic;
using System.Text.Json;
using System.IO;

/// <summary>
/// Provides a json local file-based implementation of the <see cref="ISaveSystemStrategy"/> interface for saving and loading quests.
/// </summary>
public class QuestLocalSave : ISaveSystemStrategy{
    public void Save(List<Quest> quests, string pathToSave){
        var option = new JsonSerializerOptions {WriteIndented = true};
        string questsJson = JsonSerializer.Serialize(quests, option);

        string? directoryPath = Path.GetDirectoryName(pathToSave);

        if(!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath)){
            Directory.CreateDirectory(directoryPath);
        }
        
        File.WriteAllText(pathToSave, questsJson);
    }

    public List<Quest> Load(string pathToData){

        if(!File.Exists(pathToData)){
            throw new FileNotFoundException("Quests file not found", pathToData);
        }

        string json = File.ReadAllText(pathToData);

        List<Quest>? quests = JsonSerializer.Deserialize<List<Quest>>(json);

        return quests?? new List<Quest>();
    }
}