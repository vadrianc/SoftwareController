namespace SoftwareControllerApi.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Node interface.
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Get the descendents of this node.
        /// </summary>
        IList<INode> Descendents { get; }

        /// <summary>
        /// Get the data contained by the node.
        /// </summary>
        IData Data { get; }
    }
}
