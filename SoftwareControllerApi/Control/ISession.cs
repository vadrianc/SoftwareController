namespace SoftwareControllerApi.Control
{
    using System.Collections.Generic;
    using Rule;

    /// <summary>
    /// Interface for defining a session.
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// Get the name of the session.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get the list of rules.
        /// </summary>
        IList<IRule> Rules { get; }

        /// <summary>
        /// Run the session.
        /// </summary>
        void Run();

        /// <summary>
        /// Add a new rule to the session.
        /// </summary>
        /// <param name="rule">The rule to be added.</param>
        void AddRule(IRule rule);

        /// <summary>
        /// Remove the given rule.
        /// </summary>
        /// <param name="rule">The rule to be removed.</param>
        void RemoveRule(IRule rule);
    }
}
