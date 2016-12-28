namespace SoftwareControllerApi.Action
{
    /// <summary>
    /// Interface for defining an action result.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// The state after executing an action.
        /// </summary>
        ActionState State { get; }
    }
}
