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
        private readonly IList<IAction> mActions;

        /// <summary>
        /// Get or set the name of the action.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParallelAction"/> class with the given name.
        /// </summary>
        /// <param name="name">The name of the action.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty or whitespace only.</exception>
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
        /// <returns>
        /// An object containing the result of the action.
        /// </returns>
        public IResult Execute()
        {
            if (mActions.Count == 0) return new SingleResult<object>(ActionState.NOT_EXECUTED);

            Task[] tasks = new Task[mActions.Count];
            int index = 0;
            List<IResult> results = new List<IResult>();

            foreach (IAction action in mActions) {
                Task task = new Task(() => { results.Add(action.Execute()); });
                task.Start();
                tasks[index++] = task;
            }

            Task.WaitAll(tasks);

            return new MultiResult(ActionState.SUCCESS, results);
        }

        /// <summary>
        /// Add a new action.
        /// </summary>
        /// <param name="action">The action to be added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public void AddAction(IAction action)
        {
            if (action == null) throw new ArgumentNullException("action", "Cannot be null");

            mActions.Add(action);
        }

        /// <summary>
        /// Remove an action.
        /// </summary>
        /// <param name="action">The action to be removed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
        public void RemoveAction(IAction action)
        {
            if (action == null) throw new ArgumentNullException("action", "Cannot be null");

            mActions.Remove(action);
        }
    }
}
