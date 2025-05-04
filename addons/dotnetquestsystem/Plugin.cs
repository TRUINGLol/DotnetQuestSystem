#if TOOLS
using Godot;
using System;

[Tool]
public partial class Plugin : EditorPlugin
{
	private Control _mainSceneInstance = null!;
	private PackedScene _mainScenePKJ = ResourceLoader.Load<PackedScene>("res://addons/dotnetquestsystem/MainPage.tscn");
	public override void _EnterTree()
	{
		_mainSceneInstance = (Control)_mainScenePKJ.Instantiate();
		EditorInterface.Singleton.GetEditorMainScreen().AddChild(_mainSceneInstance);
		_MakeVisible(false);
	}

	public override void _ExitTree()
	{
		if(_mainSceneInstance != null){
			_mainSceneInstance.QueueFree();
		}
	}

	public override bool _HasMainScreen()
	{
		return true;
	}

	public override string _GetPluginName()
	{
		return "Quest System";
	}

	public override void _MakeVisible(bool visible)
	{
		if(_mainSceneInstance != null){
			_mainSceneInstance.Visible = visible;
		}
	}

	public override Texture2D _GetPluginIcon()
	{
		return EditorInterface.Singleton.GetEditorTheme().GetIcon("Node", "EditorIcons");
	}
}
#endif
