namespace SoftwareControllerLib.Action
{
    using SoftwareControllerApi.Action;

    /// <summary>
    /// Simple result class holding only status information.
    /// </summary>
    public class Result : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="state">The state of the result after executing the action.</param>
        public Result(ActionState state)
        {
            State = state;
        }

        /// <summary>
        /// Get the state of the result.
        /// </summary>
        public ActionState State
        {
            get;
            private set;
        }
    }
}
