namespace SoftwareControllerApi.Action
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Interface for defining an action related to data collection.
    /// </summary>
    public interface ICollectAction : ISequentialAction
    {
        /// <summary>
        /// Get the regular expression used to identify an item to collect from.
        /// </summary>
        Regex RegEx { get; }
    }
}
