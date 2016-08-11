namespace SoftwareControllerApi.Action
{
    /// <summary>
    /// Interface for defining a sequential action.
    /// </summary>
    /// <remarks>
    /// Actions that implement this interface should have their logic executed sequentialy.
    /// </remarks>
    interface ISequentialAction : IAction
    {
    }
}
