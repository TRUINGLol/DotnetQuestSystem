namespace dotnetquestsystem;

/// <summary>
/// Represents a reward in the form of an item with the possibility of gaining experience.
/// </summary>
/// <typeparam name="TItem">The type of the item that will be the reward.</typeparam>
public class ItemReward<TItem> : IReward{
    /// <summary>
    /// Item that is part of the reward.
    /// </summary>
    public TItem Item {get;private set;}

    /// <summary>
    /// Gets the experience associated with the reward, if any. 
    /// If there is no experience, this value is null.
    /// </summary>
    public ExperienceReward? Exp {get;private set;} = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemReward{TItem}"/> class with the specified item.
    /// </summary>
    /// <param name="item">The item that will be part of the reward.</param>
    public ItemReward(TItem item){
        Item = item;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ItemReward{TItem}"/> class with the specified item and experience.
    /// </summary>
    /// <param name="item">The item that will be part of the reward.</param>
    /// <param name="exp">The experience associated with the reward.</param>
    public ItemReward(TItem item, ExperienceReward exp){
        Item = item;
        Exp = exp;
    }

    public string GetDescription(){
        string description = $"This reward includes an item: {Item}.";

        if (Exp != null)
        {
            description += $" Additionally, it grants {Exp.Amount} experience points.";
        }

        return description;
    }
}