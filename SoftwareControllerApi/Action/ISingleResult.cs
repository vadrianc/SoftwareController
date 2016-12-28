namespace SoftwareControllerApi.Action
{
    /// <summary>
    /// Interface for defining the result of a single action.
    /// </summary>
    /// <typeparam name="T">The type of the result's content.</typeparam>
    public interface ISingleResult<out T> : IResult
    {
        /// <summary>
        /// Get the content of the result.
        /// </summary>
        T Content { get; }
    }
}
