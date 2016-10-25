using System;
using SoftwareControllerApi.Utils;

namespace SoftwareControllerLib.Utils
{
    /// <summary>
    /// Class for outputting to a console.
    /// </summary>
    public class ConsoleOutput : IOutput
    {
        private static ConsoleOutput m_Instance;

        /// <summary>
        /// Get the singleton instance.
        /// </summary>
        public static ConsoleOutput Instance
        {
            get
            {
                if (m_Instance == null) {
                    m_Instance = new ConsoleOutput();
                }

                return m_Instance;
            }
        }

        /// <summary>
        /// Display error message.
        /// </summary>
        /// <param name="msg">The error message to be displayed.</param>
        public void Error(string msg)
        {
            Console.Out.WriteLine(string.Format("ERROR: {0}", msg));
        }

        /// <summary>
        /// Display normal message.
        /// </summary>
        /// <param name="msg">The normal message to be displayed.</param>
        public void Message(string msg)
        {
            Console.Out.WriteLine(msg);
        }

        /// <summary>
        /// Display warning message.
        /// </summary>
        /// <param name="msg">The warning message to be displayed.</param>
        public void Warning(string msg)
        {
            Console.Out.WriteLine(string.Format("WARNING: {0}", msg));
        }
    }
}
