namespace SoftwareControllerLib.Config
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using Control;
    using SoftwareControllerApi.Rule;

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
        private readonly List<string> c_BooleanAttrValues = new List<string>() { "true", "false", null };

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigReaderBase"/> class with the given configuration file path.
        /// </summary>
        /// <param name="config">The configuration file path.</param>
        /// <exception cref="ArgumentNullException"><paramref name="config"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="config"/> is empty of white space only.</exception>
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
                if (automatonReader.NodeType != XmlNodeType.Element || !automatonReader.Name.Equals("rule")) continue;
                
                string name = automatonReader.GetAttribute("name");
                bool isRepeatable = GetBooleanAttribute(automatonReader, "isRepeatable");
                Rule rule = isRepeatable ? new RepeatableRule(name) : new Rule(name);

                m_Session.AddRule(rule);
                XmlReader ruleReader = automatonReader.ReadSubtree();
                ReadActions(ruleReader, rule);
            }
        }

        /// <summary>
        /// Reads a boolean attribute and returns it's value.
        /// </summary>
        /// <param name="xmlReader">XML reader.</param>
        /// <param name="attribute">The attribute name.</param>
        /// <returns><c>true</c> if the attribute string value is true, <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException"><see cref="XmlReader"/> is null.</exception>
        /// <exception cref="XmlException">The read value of the attribute is not valid.</exception>
        protected bool GetBooleanAttribute(XmlReader xmlReader, string attribute)
        {
            if (xmlReader == null) throw new ArgumentNullException("xmlReader");

            string isRepeatableStr = xmlReader.GetAttribute(attribute);
            if (!c_BooleanAttrValues.Contains(isRepeatableStr)) {
                string msg = string.Format("Unrecognized attribute value {0}", isRepeatableStr);
                throw new XmlException(msg);
            }

            return (isRepeatableStr != null) && isRepeatableStr.ToLower().Equals("true");
        }

        /// <summary>
        /// Reads a string attribute and returns it's value.
        /// </summary>
        /// <param name="xmlReader">XML reader.</param>
        /// <param name="attribute">The attribute name.</param>
        /// <returns>The string value of the given attribute, <c>null</c> if not found.</returns>
        /// <exception cref="ArgumentNullException"><see cref="XmlReader"/> is null.</exception>
        protected string GetStringAttribute(XmlReader xmlReader, string attribute)
        {
            if (xmlReader == null) throw new ArgumentNullException("xmlReader");

            return xmlReader.GetAttribute(attribute);
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
