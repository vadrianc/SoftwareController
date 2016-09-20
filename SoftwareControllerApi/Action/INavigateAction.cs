namespace SoftwareControllerApi.Action
{
    /// <summary>
    /// Interface for defining a navigation action.
    /// </summary>
    public interface INavigateAction : ISequentialAction
    {
        /// <summary>
        /// Get the link to which to navigate to.
        /// </summary>
        string Link { get; }
    }
}
