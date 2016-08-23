namespace SoftwareControllerLibTest
{
    using System;
    using NUnit.Framework;
    using SoftwareControllerLib.Control;

    [TestFixture]
    public class SessionTest
    {
        [Test]
        [TestCase("", TestName = "EmptySessionName")]
        [TestCase("   ", TestName = "WhitespaceSessionName")]
        [ExpectedException(typeof(ArgumentException))]
        [Category("Session")]
        public void InvalidName(string name)
        {
            new Session(name);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("Session")]
        public void NullSessionName()
        {
            new Session(null);
        }

        [Test]
        [Category("Session")]
        public void CheckSessionName()
        {
            Session session = new Session("Test");
            Assert.That(session.Name, Is.EqualTo("Test"));

            session.Name = "NewName";
            Assert.That(session.Name, Is.EqualTo("NewName"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("Session")]
        public void AddNullRule()
        {
            Session session = new Session("Test");
            session.AddRule(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("Session")]
        public void RemoveNullRule()
        {
            Session session = new Session("Test");
            session.RemoveRule(null);
        }
    }
}
