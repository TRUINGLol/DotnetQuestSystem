using Godot;
using System;
using System.Linq;
using System.Reflection;
using dotnetquestsystem;

[Tool]
public partial class RewardOption : OptionButton
{
	[Export]
	public NodePath ButtonPath = null!;

	[Export]
	public NodePath AttributeContainerPath = null!;

	public Type[] RewardableClass {get;set;} = null!;

	public OptionButton optionRewards = null!;
	public HBoxContainer attributeContainer = null!;

	public override void _Ready()
	{
		optionRewards = GetNode<OptionButton>(ButtonPath);
		attributeContainer = GetNode<HBoxContainer>(AttributeContainerPath);

		RewardableClass = Assembly.GetExecutingAssembly().GetTypes()
		.Where((t)=>typeof(IReward).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface && !t.ContainsGenericParameters)
		.ToArray();
	
		if(RewardableClass.Length > 0){
			foreach (Type item in RewardableClass)
			{
				optionRewards.AddItem(item.Name.ToLower().Replace("reward", ""));
			}
		}

		optionRewards.Select(-1);
	}

	public void OnRewardTypeSelect(int selectedId){
		RemoveAllChild();
		attributeContainer.Visible = true;

		var selectedReward = RewardableClass[selectedId];
		var rewardConstructor = selectedReward.GetConstructors().OrderByDescending(c=>c.GetParameters().Length).FirstOrDefault();
	
		if(rewardConstructor != null){
			var constructorParams = rewardConstructor.GetParameters();

			foreach (var param in constructorParams)
			{
				Control input_field;

				if(param.ParameterType == typeof(int)){
					input_field = new SpinBox();
					((SpinBox)input_field).MinValue = int.MinValue;
					((SpinBox)input_field).MaxValue = int.MaxValue;
				}
				else if(param.ParameterType == typeof(float)){ 
					input_field = new SpinBox();
					((SpinBox)input_field).MinValue = float.MinValue;
					((SpinBox)input_field).MaxValue = float.MaxValue;
				}
				else if(param.ParameterType == typeof(string)){
					input_field = new LineEdit();
				}
				else{
					GD.PushWarning($"Сonstructor parameter type '{param.ParameterType}' is not supported for UI view, try creating object directly via API");
					continue;
				}

				input_field.Name = param.Name!;
				Label labelField = new Label{ Text = param.Name };

				attributeContainer.AddChild(labelField);
				attributeContainer.AddChild(input_field);
			}
		}
	}

	private void RemoveAllChild(){
		var allChild = attributeContainer.GetChildren();
		foreach (var child in allChild){
			child.Free();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if(disposing){
			AttributeContainerPath.Dispose();
			ButtonPath.Dispose();
		}
	}
}
