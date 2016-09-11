namespace SoftwareControllerApi.Action
{
    /// <summary>
    /// The possible states of an action's result.
    /// </summary>
    public enum ActionState
    {
        /// <summary>
        /// Successful action.
        /// </summary>
        SUCCESS,

        /// <summary>
        /// Failed action.
        /// </summary>
        FAIL,

        /// <summary>
        /// The action was not executed.
        /// </summary>
        NOT_EXECUTED
    }
}
