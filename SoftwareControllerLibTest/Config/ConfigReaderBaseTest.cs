using System;
using NUnit.Framework;
using SoftwareControllerLib.Control;

namespace SoftwareControllerLibTest.Config
{
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
            DummyConfigReader reader = new DummyConfigReader("Resources\\default.xml");
            reader.Read();

            Assert.That(reader.ReadActionsDone, Is.True);
            Assert.That(reader.ReadInitSessionDone, Is.True);
        }

        [Test]
        [Category("ConfigReaderBase")]
        public void RuleCount()
        {
            DummyConfigReader reader = new DummyConfigReader("Resources\\default.xml");
            Session session = reader.Read();

            Assert.That(session, Is.Not.Null);
            Assert.That(session.Rules.Count, Is.EqualTo(2));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "No <automaton> element found")]
        [Category("ConfigReaderBase")]
        public void MissingAutomatonTag()
        {
            DummyConfigReader reader = new DummyConfigReader("Resources\\missing_automaton.xml");
            reader.Read();
        }

        [Test]
        [Category("ConfigReaderBase")]
        public void NoRules()
        {
            DummyConfigReader reader = new DummyConfigReader("Resources\\missing_rules.xml");
            Session session = reader.Read();

            Assert.That(session, Is.Not.Null);
            Assert.That(reader.ReadActionsDone, Is.False);
            Assert.That(reader.ReadInitSessionDone, Is.True);
            Assert.That(session.Rules.Count, Is.EqualTo(0));
        }
    }
}
