namespace SoftwareControllerLibTest
{
    using System;
    using NUnit.Framework;
    using SoftwareControllerLib;

    [TestFixture]
    public class RuleTest
    {
        [Test]
        [TestCase("", TestName = "EmptyRuleName")]
        [TestCase("   ", TestName = "WhitespaceRuleName")]
        [ExpectedException(typeof(ArgumentException))]
        [Category("Rule")]
        public void InvalidName(string name)
        {
            new Rule(name);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("Rule")]
        public void NullRuleName()
        {
            new Rule(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("Rule")]
        public void NullActions()
        {
            new Rule("Test", null);
        }

        [Test]
        [Category("Rule")]
        public void CheckRuleName()
        {
            Rule rule = new Rule("Test");
            Assert.That(rule.Name, Is.EqualTo("Test"));

            rule.Name = "NewName";
            Assert.That(rule.Name, Is.EqualTo("NewName"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("Rule")]
        public void AddNullAction()
        {
            Rule rule = new Rule("Test");
            rule.AddAction(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("Rule")]
        public void RemoveNullAction()
        {
            Rule rule = new Rule("Test");
            rule.RemoveAction(null);
        }
    }
}
