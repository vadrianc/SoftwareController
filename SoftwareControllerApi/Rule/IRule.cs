namespace SoftwareControllerApi.Rule
{
    using Action;

    /// <summary>
    /// Interface for defining a rule.
    /// </summary>
    interface IRule
    {
        /// <summary>
        /// The name of the rule.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Apply the rule's actions.
        /// </summary>
        void Apply();

        /// <summary>
        /// Add action to be executed as part of the rule.
        /// </summary>
        /// <param name="action">Action to be added.</param>
        void AddAction(IAction action);

        /// <summary>
        /// Remove action from the rule.
        /// </summary>
        /// <param name="action">Action to be removed.</param>
        void RemoveAction(IAction action);
    }
}
