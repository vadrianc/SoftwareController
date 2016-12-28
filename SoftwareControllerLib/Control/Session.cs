namespace SoftwareControllerLib.Control
{
    using System;
    using System.Collections.Generic;
    using Action;
    using SoftwareControllerApi.Action;
    using SoftwareControllerApi.Control;
    using SoftwareControllerApi.Rule;

    /// <summary>
    /// Software controller session responsible with applying a set of rules.
    /// </summary>
    public class Session : ISession
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Session"/> class with the given name.
        /// </summary>
        /// <param name="name">The name of the session.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty or white space only.</exception>
        public Session(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "Cannot be null");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Cannot be empty", "name");

            Name = name;
            Rules = new List<IRule>();
        }

        /// <summary>
        /// Get or set the name of the session.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Get the list of rules.
        /// </summary>
        public IList<IRule> Rules
        {
            get;
            private set;
        }

        /// <summary>
        /// Add a new rule.
        /// </summary>
        /// <param name="rule">The rule to be added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="rule"/> is null.</exception>
        public void AddRule(IRule rule)
        {
            if (rule == null) throw new ArgumentNullException("rule", "Cannot be null");

            Rules.Add(rule);
        }

        /// <summary>
        /// Remove a rule.
        /// </summary>
        /// <param name="rule">The rule to be removed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="rule"/> is null.</exception>
        public void RemoveRule(IRule rule)
        {
            if (rule == null) throw new ArgumentNullException("rule", "Cannot be null");

            Rules.Remove(rule);
        }

        /// <summary>
        /// Applies a set of rules in a sequential order.
        /// </summary>
        /// <returns>
        /// The aggregated result of running the rules. <c>null</c> is returned if the rules count is 0.
        /// </returns>
        public IResult Run()
        {
            if (Rules.Count == 0) return null;

            List<IResult> resultList = new List<IResult>();

            foreach (IRule rule in Rules) {
                resultList.Add(rule.Apply());
            }

            return new MultiResult(ActionState.SUCCESS, resultList);
        }

        /// <summary>
        /// Applies a set of rules in a sequential order.
        /// </summary>
        /// <returns>The failed result.</returns>
        public IResult RunUntilFailure()
        {
            IResult result;

            do {
                result = Run();
            } while (result.State == ActionState.SUCCESS);

            return result;
        }
    }
}
