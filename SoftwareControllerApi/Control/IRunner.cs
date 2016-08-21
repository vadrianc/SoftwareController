namespace SoftwareControllerApi.Control
{
    /// <summary>
    /// Interface for defining a runner responsible with executing the logic of a session.
    /// </summary>
    public interface IRunner
    {
        /// <summary>
        /// Execute the logic of a session.
        /// </summary>
        void Execute();
    }
}
