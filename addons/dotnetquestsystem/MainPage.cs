using Godot;
using System;
using dotnetquestsystem;
using System.Collections.Generic;
using System.Linq;

[Tool]
public partial class MainPage : Control
{
	[Export]
	private NodePath QuestListPath = null!;

	[Export]
	private NodePath PanelViewPath = null!;

	[Export]
	private NodePath NamePath = null!;

	[Export]
	private NodePath DescriptionPath = null!;

	[Export]
	private NodePath ObjectivePath = null!;

	[Export]
	private NodePath RewardPath = null!;

	[Export]
	private NodePath DeleteQuestPath = null!;

	[Export]
	private NodePath FileDialogPath = null!;

	private ItemList _questList = null!;
	private Panel _panelView = null!;
	private LineEdit _nameQuest = null!;
	private TextEdit _descriptionQuest = null!;
	private TextEdit _objectiveQuest = null!;
	private RewardOption _reward = null!;
	private Button _deleteQuest = null!;
	private FileDialog _fileDialog = null!;

	private string? _saveQuestsPath = null;
	private Quest _currentQuest = null!;
	private ConfigFile configFile = new ConfigFile();

	public override void _Ready()
	{
		InitFields();
		
		// We do it once plugin activate
		try
		{
			if(_saveQuestsPath != null){
				QuestManager.instance.questDatabase.LoadQuests(_saveQuestsPath);
			}
			else{
				QuestManager.instance.questDatabase.LoadQuests();
			}
		}
		catch (System.IO.FileNotFoundException)
		{  
			GD.Print("Quests json file not found");
		}

		foreach (var quest in QuestManager.instance.questDatabase.Quests)
		{
			_questList.AddItem(quest.Name);
		}
	}

	public void OnCreateNewQuestButtonPressed(){
		Quest newQuest = QuestManager.instance.questController
			.CreateQuest("New Quest", "New Description", "New Objective");

		int indexNewQuest = _questList.AddItem(newQuest.Name);

		// Since Select() does not trigger the item selection signal we emmit it directly
		_questList.Select(indexNewQuest);
		OnQuestItemSelect(indexNewQuest);
	}

	public void OnQuestItemSelect(int index){
		if(index < 0 || index >= QuestManager.instance.questDatabase.Quests.Count){
			GD.PushError("Quest index out of bounds, objects on scene created manually?");
			return;
		}

		_deleteQuest.Visible = true;
		
		_currentQuest = QuestManager.instance.questDatabase.Quests[index];

		_nameQuest.Text = _currentQuest.Name;
		_descriptionQuest.Text = _currentQuest.Description;
		_objectiveQuest.Text = _currentQuest.Objective;
		if(_currentQuest.Reward != null){
			SelectRewardByText(_currentQuest.Reward.GetType().Name.ToString()!.ToLower().Replace("reward", ""));
			SetRewardParamsValue(_currentQuest);
			_reward.attributeContainer.Visible = true;
		}
		else{
			_reward.optionRewards.Select(-1);
			_reward.attributeContainer.Visible = false;
		}

		_panelView.Visible = true;
	}

	public void OnSaveQuestButtonPressed(){
		if(_currentQuest == null){
			GD.PushError("Selected quest is null");
			return;
		}

		string newName = _nameQuest.Text.Trim();
		if(string.IsNullOrEmpty(newName)){
			GD.PushWarning("Quest name cannot be empty");
			return;
		}

		Quest? existsngQuest = QuestManager.instance.questDatabase.Quests.Find((q)=>q.Name == newName && q != _currentQuest);
		if(existsngQuest != null){
			GD.PushWarning("A quest with this name already exists");
			return;
		}

		int selectedRewardId = _reward.optionRewards.Selected;
		IReward? newReward = null;

		QuestManager.instance.questController.DeleteQuest(_currentQuest);

		if(selectedRewardId>=0){
			object[]? rewardParams = GetRewardParamsValue();

			newReward = Activator.CreateInstance(_reward.RewardableClass[selectedRewardId], rewardParams) as IReward;
		}

		if(newReward != null){
			_currentQuest = QuestManager.instance.questController.CreateQuest(
				name: newName,
				description: _descriptionQuest.Text,
				objective: _objectiveQuest.Text,
				reward: newReward
			);
		}
		else{
			_currentQuest = QuestManager.instance.questController.CreateQuest(
				name: newName,
				description: _descriptionQuest.Text,
				objective: _objectiveQuest.Text
			);
		}
		
		int selectedIndex = -1;
		int[] selectedItems = _questList.GetSelectedItems();

		if(selectedItems.Length > 0){
			selectedIndex = selectedItems[0];
		}
		if(selectedIndex >= 0){
			_questList.SetItemText(selectedIndex, newName);
		}
		
		GD.Print("Quest saved!");
	}

	public void OnDeleteQuestButtonPressed(){
		int[] selectedItems = _questList.GetSelectedItems();
		int selectedIndex = -1;

		if(selectedItems.Length > 0){
			selectedIndex = selectedItems[0];
		}
		if(selectedIndex >= 0){
			_questList.RemoveItem(selectedIndex);
		}

		QuestManager.instance.questController.DeleteQuest(_currentQuest);

		_deleteQuest.Visible = false;
		_panelView.Visible = false;

		GD.Print("Quest delete!");
	}

	public void OnSelectQuestPathButtonPressed(){
		_fileDialog.Visible = true;
	}

	public void OnQuestPathSelect(){
		_fileDialog.Visible = false;
		_saveQuestsPath = _fileDialog.CurrentPath + "Quests.json";
		GD.Print("Save quest path change to: "+ _saveQuestsPath);
	}

	private void SelectRewardByText(string text){
		int itemCount = _reward.optionRewards.ItemCount;

		for (int i = 0; i < itemCount; i++){
			if(_reward.optionRewards.GetItemText(i) == text){
				_reward.optionRewards.Select(i);

				// Select() method did not emmit OnSelect signal
				_reward.OnRewardTypeSelect(i);
				return;
			}
		}

	}

	private object[]? GetRewardParamsValue(){
		List<object> paramsValue = new List<object>();
		var allChild = _reward.attributeContainer.GetChildren();

		foreach (var child in allChild){
			if(child is Label label){
				int index = allChild.IndexOf(label) + 1;

				if(index < allChild.Count && allChild[index] is Control inputField){

					if(inputField is SpinBox spinBox){
						if(spinBox.MinValue >= int.MinValue && spinBox.MaxValue <= int.MaxValue){
							paramsValue.Add((int)spinBox.Value);
						}
						else{
							paramsValue.Add((float)spinBox.Value);
						}
					}
					else if(inputField is LineEdit lineEdit){
						paramsValue.Add(lineEdit.Text);
					}

				} 
			}
		}

		return paramsValue.Count > 0 ? paramsValue.ToArray() : null;
	}

	private void SetRewardParamsValue(Quest questWithReward){
		if(questWithReward.Reward is null) return;

		var allChild = _reward.attributeContainer.GetChildren();
		var rewardProperties = questWithReward.Reward.GetType().GetProperties();

		int valueIndex = 0;

		foreach (var child in allChild){
			if(child is Label label){
				int index = allChild.IndexOf(label)+1;

				if(index < allChild.Count && allChild[index] is Control inputField){
					if(valueIndex >= rewardProperties.Count()){
						GD.PushWarning("Reward count is out of bounds");
					}

					if(inputField is SpinBox spinBox){
						if (rewardProperties[valueIndex].GetValue(questWithReward.Reward) is int intValue &&
						 spinBox.MinValue >= int.MinValue && spinBox.MaxValue <= int.MaxValue){
							spinBox.Value = intValue;
						}
						else if (rewardProperties[valueIndex].GetValue(questWithReward.Reward) is float floatValue){
							spinBox.Value = floatValue;
						}
					}
					else if (inputField is LineEdit lineEdit){
						if (rewardProperties[valueIndex].GetValue(questWithReward.Reward) is string stringValue){
							lineEdit.Text = stringValue;
						}
			   		}

					valueIndex++;

				}
			}
		}
	}

	private void InitFields(){
		var err = configFile.Load("res://quest.cfg");
		if(err == Error.Ok){
			_saveQuestsPath = (string?)configFile.GetValue("settings","save_quest_path");
		}

		_questList = GetNode<ItemList>(QuestListPath);
		_panelView = GetNode<Panel>(PanelViewPath);
		_descriptionQuest = GetNode<TextEdit>(DescriptionPath);
		_nameQuest = GetNode<LineEdit>(NamePath);
		_objectiveQuest = GetNode<TextEdit>(ObjectivePath);
		_reward = GetNode<RewardOption>(RewardPath);
		_deleteQuest = GetNode<Button>(DeleteQuestPath);
		_fileDialog = GetNode<FileDialog>(FileDialogPath);
	}

	protected override void Dispose(bool disposing)
	{
		if(disposing){
			QuestListPath.Dispose();
			PanelViewPath.Dispose();
			RewardPath.Dispose();
			NamePath.Dispose();
			DescriptionPath.Dispose();
			ObjectivePath.Dispose();
			DeleteQuestPath.Dispose();
			FileDialogPath.Dispose();
		}
	}

	public override void _ExitTree()
	{
		if(_saveQuestsPath != null){
			QuestManager.instance.questDatabase.SaveQuests(_saveQuestsPath);
			configFile.SetValue("settings","save_quest_path", _saveQuestsPath);
			configFile.Save("res://quest.cfg");
		}
		else{
			// Use defualt value
			QuestManager.instance.questDatabase.SaveQuests();
		}
	}
}
