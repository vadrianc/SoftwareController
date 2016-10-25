namespace SoftwareControllerApi.Utils
{
    /// <summary>
    /// Interface for defining an output class.
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Display normal message.
        /// </summary>
        /// <param name="msg">The normal message to be displayed.</param>
        void Message(string msg);

        /// <summary>
        /// Display warning message.
        /// </summary>
        /// <param name="msg">The warning message to be displayed.</param>
        void Warning(string msg);

        /// <summary>
        /// Display error message.
        /// </summary>
        /// <param name="msg">The error message to be displayed.</param>
        void Error(string msg);
    }
}
