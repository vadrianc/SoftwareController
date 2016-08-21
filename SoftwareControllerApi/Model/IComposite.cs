namespace SoftwareControllerApi.Model
{
    /// <summary>
    /// Composite data interface.
    /// </summary>
    public interface IComposite
    {
        /// <summary>
        /// Get the root node of the composite data.
        /// </summary>
        INode Root { get; }
    }
}
