using System.Text.Json.Serialization;

namespace dotnetquestsystem;

/// <summary>
/// Represents a reward that grants experience points to the player.
/// </summary>
public class ExperienceReward : IReward{

    /// <summary>
    ///  Amount of experience points granted by this reward.
    /// </summary>
    public int Amount {get; private set;}

    /// <summary>
    /// Initializes a new instance of the <see cref="ExperienceReward"/> class with a specified amount of experience.
    /// </summary>
    /// <param name="expAmount">The amount of experience points to be awarded.</param>
    public ExperienceReward(int amount){
        Amount = amount;
    }

    public string GetDescription(){
        return "This reward grants experience points to the player.";
    }
}