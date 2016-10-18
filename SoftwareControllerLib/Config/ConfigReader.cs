using System;
using System.Xml;
using SoftwareControllerApi.Rule;
using SoftwareControllerLib.Control;

namespace SoftwareControllerLib.Config
{
    /// <summary>
    /// Base class for defining a configuration reader.
    /// </summary>
    /// <remarks>
    /// Each configuration file shall contain a single automaton with a collection of states defined as
    /// rules. Any class that derives from this class shall implement the custom logic for parsing 
    /// specific actions and settings defined within the configuration file.
    /// </remarks>
    public abstract class ConfigReaderBase
    {
        protected XmlReader m_Reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigReaderBase"/> class with the given session and configuration file path.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="config">The configuration file path.</param>
        public ConfigReaderBase(Session session, string config)
        {
            if (session == null) throw new ArgumentNullException("session", "Cannot be null");
            if (config == null) throw new ArgumentNullException("config", "Cannot be null");
            if (string.IsNullOrWhiteSpace(config)) throw new ArgumentException("Cannot be empty or whitespace only", "config");

            m_Reader = XmlReader.Create(config);
            Session = session;
        }

        /// <summary>
        /// Get or set the session.
        /// </summary>
        public Session Session
        {
            get;
            private set;
        }

        /// <summary>
        /// Read the configuration file and update the session.
        /// </summary>
        public void Read()
        {
            ReadAutomaton();
            ReadSettings();
        }

        private void ReadAutomaton()
        {
            if (!m_Reader.ReadToFollowing("automaton")) {
                throw new ArgumentException("No <automaton> element found");
            }

            if (m_Reader.ReadToFollowing("automaton")) {
                throw new ArgumentException("Cannot define more than one <automaton> elements");
            }

            while (m_Reader.ReadToDescendant("rule")) {
                Rule rule = new Rule(m_Reader.GetAttribute("name"));

                while (m_Reader.ReadToDescendant("action")) {
                    ReadActions(rule);
                }

                Session.AddRule(rule);
            }
        }

        /// <summary>
        /// Read the application specific settings from the configuration file.
        /// </summary>
        protected abstract void ReadSettings();

        /// <summary>
        /// Read the application specific actions from the configuration file.
        /// </summary>
        /// <param name="rule">The rule where the read actions are to be added.</param>
        protected abstract void ReadActions(IRule rule);
    }
}
