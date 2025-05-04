namespace dotnetquestsystem;


/// <summary>
/// Enumeration representing the possible statuses of a quest.
/// </summary>
public enum QuestStatus{
    /// <summary>
    /// The quest has just been created and has not yet started.
    /// </summary>
    New,

    /// <summary>
    /// The quest is currently in progress.
    /// </summary>
    Current,

    /// <summary>
    /// The quest has been successfully completed.
    /// </summary>
    Complete,

    /// <summary>
    /// The quest has been canceled and will not be completed.
    /// </summary>
    Canceled
}