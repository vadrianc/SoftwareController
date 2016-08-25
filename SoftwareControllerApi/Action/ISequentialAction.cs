namespace SoftwareControllerApi.Action
{
    /// <summary>
    /// Interface for defining a sequential action.
    /// </summary>
    /// <remarks>
    /// Actions that implement this interface should have their logic executed sequentially.
    /// </remarks>
    public interface ISequentialAction : IAction
    {
    }
}
