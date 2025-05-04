namespace QuestSystemAPITest;

using dotnetquestsystem;
using System.IO;

public class QuestManagerTest{

    [Fact]
    public void OnQuestCompleate_QuestStatusComplete_ReturnInvokeEvent(){
        // Arrange
        QuestManager instance = QuestManager.instance;
        Quest quest = new Quest("testName", "testDescription", "testObjective");

        bool eventInvoked = false;
        instance.OnQuestCompleate += (q)=>eventInvoked = true;

        // Act
        instance.FinishQuest(quest);

        // Assert
        Assert.True(eventInvoked);
    }

    [Fact]
    public void OnQuestStatusChanged_CreatedQuestStatusChanged_ReturnInvokeEvent(){
        // Arrange
        QuestManager instance = QuestManager.instance;
        Quest quest = new Quest("testName", "testDescription", "testObjective");

        bool eventInvoked = false;
        instance.OnQuestStatusChanged += (q)=>eventInvoked = true;

        // Act
        quest.ChangeQuestStatus(QuestStatus.Complete);

        // Assert
        Assert.True(eventInvoked);
    }
}