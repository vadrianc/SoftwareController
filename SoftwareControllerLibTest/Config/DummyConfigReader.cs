using System;
using System.Threading;
using System.Xml;
using SoftwareControllerApi.Rule;
using SoftwareControllerLib.Config;
using SoftwareControllerLib.Control;

namespace SoftwareControllerLibTest.Config
{
    /// <summary>
    /// Dummy class used only for testing the <see cref="ConfigReaderBase{T}"/> logic.
    /// </summary>
    public class DummyConfigReader : ConfigReaderBase<Session>
    {
        public bool ReadInitSessionDone { get; private set; }
        public bool ReadActionsDone { get; private set; }

        public DummyConfigReader(string config) : base(config) { }

        protected override void InitSession()
        {
            m_Session = new Session("dummy");
            ReadInitSessionDone = true;
        }

        protected override void ReadActions(XmlReader ruleReader, IRule rule)
        {
            ReadActionsDone = true;
        }
    }
}
