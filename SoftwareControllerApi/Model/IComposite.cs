namespace SoftwareControllerApi.Model
{
    /// <summary>
    /// Composite data interface.
    /// </summary>
    /// <remarks>
    /// A composite data type shall make use of a tree data structure.
    /// </remarks>
    public interface IComposite
    {
        /// <summary>
        /// Get the root node of the composite data.
        /// </summary>
        INode Root { get; }
    }
}
