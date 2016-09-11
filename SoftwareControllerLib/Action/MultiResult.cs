namespace SoftwareControllerLib.Action
{
    using System;
    using System.Collections.Generic;
    using SoftwareControllerApi.Action;

    /// <summary>
    /// The aggregated results of multiple actions.
    /// </summary>
    public class MultiResult : Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiResult"/> class.
        /// </summary>
        /// <param name="content">The content of the result.</param>
        /// <param name="state">The state of executing multiple actions.</param>
        public MultiResult(object content, ActionState state) : this(content, state, new List<IResult>())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiResult"/> class.
        /// </summary>
        /// <param name="content">The content of the result.</param>
        /// <param name="state">The state of executing multiple actions.</param>
        /// <param name="results">The results of multiple actions.</param>
        public MultiResult(object content, ActionState state, List<IResult> results) : base(content, state)
        {
            if (results == null) throw new ArgumentNullException("results", "Cannot be null");

            CalculateState(results);
            Results = results;
        }

        private void CalculateState(List<IResult> results)
        {
            State = ActionState.SUCCESS;
            int notExecuted = 0;

            foreach (IResult result in results) {
                if (result.State == ActionState.FAIL) {
                    State = ActionState.FAIL;
                    break;
                } else if (result.State == ActionState.NOT_EXECUTED) {
                    notExecuted++;
                }
            }

            if (notExecuted == results.Count) {
                State = ActionState.NOT_EXECUTED;
            }
        }

        /// <summary>
        /// The aggregated results of multiple actions.
        /// </summary>
        public List<IResult> Results
        {
            get;
            private set;
        }
    }
}
