namespace SoftwareControllerApi.Action
{
    /// <summary>
    /// Interface for defining an action.
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// The name of the action.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Execute the action.
        /// </summary>
        IResult Execute();
    }
}
