namespace SoftwareControllerLib.Control
{
    using System;
    using System.Collections.Generic;
    using SoftwareControllerApi.Control;
    using SoftwareControllerApi.Rule;

    /// <summary>
    /// Software controller session responsible with applying a set of rules.
    /// </summary>
    public class Session : ISession
    {
        private IList<IRule> mRules;

        /// <summary>
        /// Initialize a new instance of the <see cref="Session"/> class with the given name.
        /// </summary>
        /// <param name="name">The name of the session.</param>
        public Session(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "Cannot be null");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Cannot be empty", "name");

            Name = name;
            mRules = new List<IRule>();
        }

        /// <summary>
        /// Get or set the name of the session.
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        /// Applies a set of rules in a sequential order.
        /// </summary>
        public void Run()
        {
            if (mRules.Count == 0) return;

            foreach (IRule rule in mRules) {
                rule.Apply();
            }
        }

        /// <summary>
        /// Add a new rule.
        /// </summary>
        /// <param name="rule">The rule to be added.</param>
        public void AddRule(IRule rule)
        {
            if (rule == null) throw new ArgumentNullException("rule", "Cannot be null");

            mRules.Add(rule);
        }

        /// <summary>
        /// Remove a rule.
        /// </summary>
        /// <param name="rule">The rule to be removed.</param>
        public void RemoveRule(IRule rule)
        {
            if (rule == null) throw new ArgumentNullException("rule", "Cannot be null");

            mRules.Remove(rule);
        }
    }
}
