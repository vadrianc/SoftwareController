namespace SoftwareControllerLib.Config
{
    using System;
    using System.Xml;
    using SoftwareControllerApi.Rule;
    using SoftwareControllerLib.Control;

    /// <summary>
    /// Base class for defining a configuration reader.
    /// </summary>
    /// <remarks>
    /// Each configuration file shall contain a single automaton with a collection of states defined as
    /// rules. Any class that derives from this class shall implement the custom logic for parsing 
    /// specific actions and settings defined within the configuration file.
    /// </remarks>
    public abstract class ConfigReaderBase<T> where T : Session
    {
        protected XmlReader m_Reader;
        protected T m_Session;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigReaderBase"/> class with the given configuration file path.
        /// </summary>
        /// <param name="config">The configuration file path.</param>
        public ConfigReaderBase(string config)
        {
            if (config == null) throw new ArgumentNullException("config", "Cannot be null");
            if (string.IsNullOrWhiteSpace(config)) throw new ArgumentException("Cannot be empty or whitespace only", "config");

            m_Reader = XmlReader.Create(config);
        }

        /// <summary>
        /// Read the configuration file and update the session.
        /// </summary>
        /// <returns>The session containing the parsed configuration settings.</returns>
        public T Read()
        {
            InitSession();
            ReadAutomaton();

            return m_Session;
        }

        private void ReadAutomaton()
        {
            if (!m_Reader.ReadToFollowing("automaton")) {
                throw new ArgumentException("No <automaton> element found");
            }

            XmlReader automatonReader = m_Reader.ReadSubtree();

            while (automatonReader.Read()) {
                if (automatonReader.NodeType == XmlNodeType.Element && automatonReader.Name.Equals("rule")) {
                    Rule rule = new Rule(automatonReader.GetAttribute("name"));
                    m_Session.AddRule(rule);
                    XmlReader ruleReader = automatonReader.ReadSubtree();
                    ReadActions(ruleReader, rule);
                }
            }
        }

        /// <summary>
        /// Read the application specific settings from the configuration file.
        /// </summary>
        protected abstract void InitSession();

        /// <summary>
        /// Read the application specific actions from the configuration file.
        /// </summary>
        /// <param name="ruleReader">The XML representing the rule.</param>
        /// <param name="rule">The rule where the read actions are to be added.</param>
        protected abstract void ReadActions(XmlReader ruleReader, IRule rule);
    }
}
