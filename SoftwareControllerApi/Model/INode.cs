namespace SoftwareControllerApi.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Node interface.
    /// </summary>
    /// <remarks>
    /// To be used for defining the nodes in a tree data structure.
    /// </remarks>
    public interface INode
    {
        /// <summary>
        /// Get the descendants of this node.
        /// </summary>
        IList<INode> Descendents { get; }

        /// <summary>
        /// Get the data contained by the node.
        /// </summary>
        IData Data { get; }
    }
}
