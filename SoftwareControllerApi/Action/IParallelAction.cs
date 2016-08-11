namespace SoftwareControllerApi.Action
{
    /// <summary>
    /// Interface for defining a parallel action.
    /// </summary>
    /// <remarks>
    /// IParalelAction shall contain a collection of actions that can be executed in parallel. 
    /// The individual actions can be either of sequential or parallel type.
    /// </remarks>
    interface IParallelAction : IAction
    {
        /// <summary>
        /// Add a action that can be executed in parallel with other actions.
        /// </summary>
        /// <param name="action"></param>
        void AddAction(IAction action);

        /// <summary>
        /// Remove a given action.
        /// </summary>
        /// <param name="action"></param>
        void RemoveAction(IAction action);
    }
}
