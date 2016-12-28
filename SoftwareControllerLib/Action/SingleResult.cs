namespace SoftwareControllerLib.Action
{
    using SoftwareControllerApi.Action;

    /// <summary>
    /// The result of executing a single action.
    /// </summary>
    public class SingleResult<T> : ISingleResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleResult"/> class. 
        /// </summary>
        /// <param name="state">The state after executing an action.</param>
        public SingleResult(ActionState state)
        {
            State = state;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleResult"/> class. 
        /// </summary>
        /// <param name="content">The content of the result.</param>
        /// <param name="state">The state of executing an action.</param>
        public SingleResult(T content, ActionState state)
        {
            Content = content;
            State = state;
        }

        /// <summary>
        /// Get the content of the result.
        /// </summary>
        public T Content
        {
            get;
            private set;
        }

        /// <summary>
        /// Get the state of executing an action.
        /// </summary>
        public ActionState State
        {
            get;
            protected set;
        }
    }
}
