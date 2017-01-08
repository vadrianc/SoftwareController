namespace SoftwareControllerApi.Rule
{
    using System.Collections.Generic;
    using Action;

    /// <summary>
    /// Interface for defining a rule's result processor.
    /// </summary>
    public interface IResultProcessor
    {
        /// <summary>
        /// Process the given list of results.
        /// </summary>
        /// <param name="results">List of results to be processed.</param>
        void Process(IList<IResult> results);
    }
}
