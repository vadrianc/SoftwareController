namespace SoftwareControllerLib.Action
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SoftwareControllerApi.Action;

    /// <summary>
    /// Composite action that executes a collection of actions in parallel.
    /// </summary>
    public class ParallelAction : IParallelAction
    {
        private IList<IAction> mActions;

        /// <summary>
        /// Get or set the name of the action.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParallelAction"/> class with the given name.
        /// </summary>
        /// <param name="name">The name of the action.</param>
        public ParallelAction(string name)
        {
            if (name == null) throw new ArgumentNullException("name", "Cannot be null.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Cannot be empty", "name");

            Name = name;
            mActions = new List<IAction>();
        }

        /// <summary>
        /// Execute a collection of actions in parallel.
        /// </summary>
        public void Execute()
        {
            if (mActions.Count == 0) return;

            Task[] tasks = new Task[mActions.Count];
            int index = 0;

            foreach (IAction action in mActions) {
                Task task = new Task(() => { action.Execute(); });
                task.Start();
                tasks[index++] = task;
            }

            Task.WaitAll(tasks);
        }

        /// <summary>
        /// Add a new action.
        /// </summary>
        /// <param name="action">The action to be added.</param>
        public void AddAction(IAction action)
        {
            if (action == null) throw new ArgumentNullException("action", "Cannot be null");

            mActions.Add(action);
        }

        /// <summary>
        /// Remove an action.
        /// </summary>
        /// <param name="action">The action to be removed.</param>
        public void RemoveAction(IAction action)
        {
            if (action == null) throw new ArgumentNullException("action", "Cannot be null");

            mActions.Remove(action);
        }
    }
}
