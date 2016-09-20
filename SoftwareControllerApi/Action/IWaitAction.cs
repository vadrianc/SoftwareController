namespace SoftwareControllerApi.Action
{
    /// <summary>
    /// Interface for defining a wait action.
    /// </summary>
    /// <remarks>
    /// A Wait Action should be complementary to other actions, sequential or parallel, 
    /// by implementing the functionality to wait for the action to finish.
    /// </remarks>
    public interface IWaitAction : ISequentialAction
    {
        /// <summary>
        /// Get the number of milliseconds to wait for.
        /// </summary>
        int Milliseconds { get; }
    }
}
