namespace SoftwareControllerApi.Action
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for defining the aggregated result of multiple actions.
    /// </summary>
    public interface IMultiResult : IResult
    {
        /// <summary>
        /// Get the list of aggregated results.
        /// </summary>
        IList<IResult> Results { get; }
    }
}
