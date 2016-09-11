namespace SoftwareControllerLib.Action
{
    using System;
    using SoftwareControllerApi.Action;

    /// <summary>
    /// The result of an action.
    /// </summary>
    public class Result : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class. 
        /// </summary>
        /// <param name="content">The content of the result.</param>
        /// <param name="state">The state of executing an action.</param>
        public Result(object content, ActionState state)
        {
            Content = content;
            State = state;
        }

        /// <summary>
        /// Get the content of the result.
        /// </summary>
        public object Content
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
