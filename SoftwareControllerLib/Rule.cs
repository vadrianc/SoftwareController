﻿namespace SoftwareControllerLib
{
    using System;
    using System.Collections.Generic;
    using SoftwareControllerApi.Action;
    using SoftwareControllerApi.Rule;

    /// <summary>
    /// Rule defined by a collection of actions.
    /// </summary>
    public class Rule : IRule
    {
        private IList<IAction> mActions;

        /// <summary>
        /// Initialize a new instance of the <see cref="Rule"/> class with the given name.
        /// </summary>
        /// <param name="name">The name of the rule.</param>
        public Rule(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "Cannot be null");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The name cannot be empty", "name");

            Name = name;
            mActions = new List<IAction>();
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="Rule"/> class with the given name and collection of rules.
        /// </summary>
        /// <param name="name">The name of the rule.</param>
        /// <param name="actions">The collection of actions.</param>
        public Rule(string name, IList<IAction> actions) : this(name)
        {
            if (actions == null) throw new ArgumentNullException("actions", "Cannot be null");

            mActions = new List<IAction>(actions);
        }
        
        /// <summary>
        /// Get or set the name of the rule.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Apply the rule's actions.
        /// </summary>
        public void Apply()
        {
            foreach (IAction action in mActions) {
                action.Execute();
            }
        }

        /// <summary>
        /// Add the action to be executed as part of the rule.
        /// </summary>
        /// <param name="action">Action to be added.</param>
        public void AddAction(IAction action)
        {
            if (action == null) throw new ArgumentNullException("action", "Cannot be null");

            mActions.Add(action);
        }

        /// <summary>
        /// Remove the action from the rule.
        /// </summary>
        /// <param name="action">Action to be removed.</param>
        public void RemoveAction(IAction action)
        {
            mActions.Remove(action);
        }
    }
}
