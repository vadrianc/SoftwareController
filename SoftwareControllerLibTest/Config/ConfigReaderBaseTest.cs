namespace SoftwareControllerLibTest.Config
{
    using System;
    using System.IO;
    using System.Xml;
    using NUnit.Framework;
    using SoftwareControllerLib;
    using SoftwareControllerLib.Control;

    [TestFixture]
    public class ConfigReaderBaseTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("ConfigReaderBase")]
        public void NullConfig()
        {
            new DummyConfigReader(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        [Category("ConfigReaderBase")]
        public void EmptyConfig()
        {
            new DummyConfigReader(string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        [Category("ConfigReaderBase")]
        public void WhitespaceOnlyConfig()
        {
            new DummyConfigReader("   ");
        }

        [Test]
        [Category("ConfigReaderBase")]
        public void CheckImplMethodExecution()
        {
            DummyConfigReader reader = new DummyConfigReader(Path.Combine("Resources", "default.xml"));
            reader.Read();

            Assert.That(reader.ReadActionsDone, Is.True);
            Assert.That(reader.ReadInitSessionDone, Is.True);
        }

        [Test]
        [Category("ConfigReaderBase")]
        public void RuleCount()
        {
            DummyConfigReader reader = new DummyConfigReader(Path.Combine("Resources", "default.xml"));
            Session session = reader.Read();

            Assert.That(session, Is.Not.Null);
            Assert.That(session.Rules.Count, Is.EqualTo(2));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "No <automaton> element found")]
        [Category("ConfigReaderBase")]
        public void MissingAutomatonTag()
        {
            DummyConfigReader reader = new DummyConfigReader(Path.Combine("Resources", "missing_automaton.xml"));
            reader.Read();
        }

        [Test]
        [Category("ConfigReaderBase")]
        public void NoRules()
        {
            DummyConfigReader reader = new DummyConfigReader(Path.Combine("Resources", "missing_rules.xml"));
            Session session = reader.Read();

            Assert.That(session, Is.Not.Null);
            Assert.That(reader.ReadActionsDone, Is.False);
            Assert.That(reader.ReadInitSessionDone, Is.True);
            Assert.That(session.Rules.Count, Is.EqualTo(0));
        }

        [Test]
        [Category("ConfigReaderBase")]
        public void RepeatableRule()
        {
            DummyConfigReader reader = new DummyConfigReader(Path.Combine("Resources", "with_repeatable_rule.xml"));
            Session session = reader.Read();

            Assert.That(session, Is.Not.Null);
            Assert.That(session.Rules.Count, Is.EqualTo(1));
            Assert.That(session.Rules[0], Is.InstanceOf<RepeatableRule>());
        }

        [Test]
        [Category("ConfigReaderBase")]
        public void NoneRepeatableRule()
        {
            DummyConfigReader reader = new DummyConfigReader(Path.Combine("Resources", "none_repeatable_rule.xml"));
            Session session = reader.Read();

            Assert.That(session, Is.Not.Null);
            Assert.That(session.Rules.Count, Is.EqualTo(1));
            Assert.That(session.Rules[0], Is.Not.InstanceOf<RepeatableRule>());
        }

        [Test]
        [ExpectedException(typeof(XmlException))]
        [Category("ConfigReaderBase")]
        public void InvalidRepeatableRule()
        {
            DummyConfigReader reader = new DummyConfigReader(Path.Combine("Resources", "invalid_repeatable_rule.xml"));
            reader.Read();
        }
    }
}
