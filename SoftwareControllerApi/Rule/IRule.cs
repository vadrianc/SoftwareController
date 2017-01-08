namespace SoftwareControllerApi.Rule
{
    using System.Collections.Generic;
    using Action;

    /// <summary>
    /// Interface for defining a rule.
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// The name of the rule.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get a boolean value that indicates if the rule result(s) can be processed or not.
        /// </summary>
        /// <value>
        /// <c>true</c> if the rule result(s) can be processed, <c>false</c> otherwise.
        /// </value>
        bool IsProcessable { get; }

        /// <summary>
        /// Get or set the list of result processors.
        /// </summary>
        IList<IResultProcessor> ResultProcessors { get; set; }

        /// <summary>
        /// Get the list of actions.
        /// </summary>
        IList<IAction> Actions { get; }

        /// <summary>
        /// Apply the rule's actions.
        /// </summary>
        /// <returns>
        /// The aggregated result of running the actions.
        /// </returns>
        IResult Apply();

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
