namespace QuestSystemAPITest;

using dotnetquestsystem;
using System.Collections.Generic;
using System.IO;

public class QuestDatabseTest{

    [Fact]
    public void SaveQuests_LocalSaveCreatedQuests_ReturnCreateNewJsonFile(){
        // Arrange
        QuestDatabase instance = new QuestDatabase();
        Quest quest = new Quest("TestName", "TestDescription", "TestObjective");

        instance.SetSaveType(new QuestLocalSave());
        string expectedJsonPath = "../Quest.json";

        // Act
        instance.Quests.Add(quest);
        instance.SaveQuests(expectedJsonPath);

        // Assert
        Assert.True(File.Exists(expectedJsonPath), "Json file was not created!");
    }

    [Fact]
    public void LoadQuests_LocalLoadSavedQuests_ReturnQuestListData(){
        // Arrange
        QuestDatabase instance = new QuestDatabase();
        string expectedName = "TestName";
        string expectedDescription = "TestDescription";
        string expectedObjective = "TestObjective";
        Quest quest = new Quest(expectedName, expectedDescription, expectedObjective);

        instance.SetSaveType(new QuestLocalSave());
        string expectedJsonPath = "../Quest.json";

        // Act
        instance.Quests.Add(quest);
        instance.SaveQuests(expectedJsonPath);
        instance.LoadQuests(expectedJsonPath);

        // Assert
        Assert.Contains(instance.Quests, q=> q.Name==expectedName && 
            q.Description==expectedDescription && q.Objective == expectedObjective);
    }
}