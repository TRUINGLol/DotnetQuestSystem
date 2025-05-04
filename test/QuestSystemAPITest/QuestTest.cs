namespace QuestSystemAPITest;

using dotnetquestsystem;

public class QuestTest
{
    [Fact]
    public void ChangeQuestStatus_NewToComplete_ReturnComplete()
    {
        // Arrange
        Quest quest = new Quest("TestName", "TestDescription", "TestObjective");

        // Act
        quest.ChangeQuestStatus(QuestStatus.Complete);

        // Assert
        Assert.Equal(QuestStatus.Complete,quest.Status);
    }
}
