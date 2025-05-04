namespace QuestSystemAPITest;

using dotnetquestsystem;
using System.Collections.Generic;

public class QuestControllerTest{

    public QuestControllerTest(){
        QuestManager.instance.questDatabase.Quests.Clear();
    }
    
    [Fact]
    public void CreateQuest_WithNameDescription_ReturnQuestAddedToDatabase(){
        // Arrange
        QuestManager instance = QuestManager.instance;
        string expectedName = "TestNameWithDescriptionQuest";
        string expectedDescription = "TestDescriptionWithNameQuest";
        string expectedObjective = "TestObjective";

        // Act
        Quest quest = instance.questController.CreateQuest(expectedName, expectedDescription, expectedObjective);

        // Assert
        Assert.Equal(expectedName, quest.Name);
        Assert.Equal(expectedDescription, quest.Description);
        Assert.Contains(instance.questDatabase.Quests, q => q.Name == expectedName &&
            q.Description == expectedDescription && q.Reward == null && q.Objective == expectedObjective);
    }

    [Fact]
    public void CreateQuest_WithNameDescriptionReward_ReturnQuestAddedToDatabase(){
        // Arrange
        QuestManager instance = QuestManager.instance;
        string expectedName = "TestNameWithDescriptionRewardQuest";
        string expectedDescription = "TestDescriptionWithNameRewardQuest";
        string expectedObjective = "TestObjective";
        IReward expectedReward = new ExperienceReward(0);

        // Act
        Quest quest = instance.questController.CreateQuest(expectedName, expectedDescription, expectedObjective, expectedReward);

        // Assert
        Assert.Equal(expectedName, quest.Name);
        Assert.Equal(expectedDescription, quest.Description);
        Assert.Equal(expectedReward, quest.Reward);
        Assert.Contains(instance.questDatabase.Quests, q => q.Name == expectedName && 
            q.Description == expectedDescription && q.Reward == expectedReward && q.Objective == expectedObjective);
    }

    [Fact]
    public void DeleteQuest_WithCreatedQuest_ReturnRemoveFromDatabase(){
        // Arrange
        QuestManager instance = QuestManager.instance;
        string expectedName = "TestName";
        string expectedDescription = "TestDescription";
        string expectedObjective = "TestObjective";
        Quest quest = instance.questController.CreateQuest(expectedName, expectedDescription, expectedObjective);

        // Act
        instance.questController.DeleteQuest(quest);

        // Assert
        Assert.DoesNotContain(instance.questDatabase.Quests, q => q.Name == expectedName && 
            q.Description == expectedDescription && q.Reward == null && q.Objective == expectedObjective);
    }

    [Fact]
    public void GetQuestByName_WithTestName_ReturnQuestByTestNameFromDatabase(){
        // Arrange
        QuestManager instance = QuestManager.instance;
        string expectedName = "TestName";
        Quest expectedQuest = instance.questController.CreateQuest(expectedName, "TestDescription", "TestObjective");

        // Act
        Quest? questFromDB = instance.questController.GetQuestByName(expectedName);

        // Assert
        Assert.Equal(expectedQuest, questFromDB);

    }

    [Fact]
    public void GetAllQuests_WithCreatedQuests_ReturnQuestsListFromDatabaseWithCreatedQuests(){
        // Arrange
        QuestManager instance = QuestManager.instance;
        string expectedName = "TestNameQuest";
        string expectedDescription = "TestDescriptionQuest";
        string expectedObjective = "TestObjective";
        Quest expectedQuest = instance.questController.CreateQuest(expectedName, expectedDescription, expectedObjective);

        // Act
        List<Quest> questsFromDatabase = instance.questController.GetAllQuests();

        // Assert
        Assert.Contains(questsFromDatabase, q => q.Name == expectedName &&
            q.Description == expectedDescription && q.Reward == null && q.Objective == expectedObjective);
    }
}