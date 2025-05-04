namespace dotnetquestsystem;

using System.Text.Json.Serialization;

/// <summary>
/// Interface representing rewards in the quest system.
/// </summary>
[JsonPolymorphic]
[JsonDerivedType(typeof(ExperienceReward),"ExperienceReward")]
[JsonDerivedType(typeof(ItemReward<string>), "ItemReward")]
public interface IReward{

    /// <summary>
    /// Gets the description of the reward.
    /// </summary>
    /// <returns>A string containing the description of the reward.</returns>
    string GetDescription(); 
}