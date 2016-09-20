using SoftwareControllerApi.Action;

namespace SoftwareControllerLib.Action
{
    /// <summary>
    /// Base class for creating an action factory.
    /// </summary>
    public abstract class ActionFactoryBase
    {
        /// <summary>
        /// Create a new action given the type.
        /// </summary>
        /// <param name="type">The type of the action that is to be created.</param>
        /// <returns>The action.</returns>
        public abstract IAction Create(ActionType type);
    }
}
