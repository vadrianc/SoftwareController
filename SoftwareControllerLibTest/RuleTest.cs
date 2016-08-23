namespace SoftwareControllerLibTest
{
    using System;
    using NUnit.Framework;
    using SoftwareControllerApi.Action;
    using SoftwareControllerLib;
    using SoftwareControllerLib.Action;

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

        [Test]
        [Category("Rule")]
        public void ApplyEmptyRule()
        {
            Rule rule = new Rule("Test");
            rule.Apply();
        }

        [Test]
        [Category("Rule")]
        public void RuleWithSingleSequentialAction()
        {
            Rule rule = new Rule("Test");

            IAction action1 = new DummySequentialAction("dummy1");
            Assert.That(action1.Name, Is.EqualTo("dummy1"));

            rule.AddAction(action1);
            rule.Apply();

            Assert.That(action1.Name, Is.EqualTo("Test"));
        }

        [Test]
        [Category("Rule")]
        public void RuleWithSingleParallelAction()
        {
            Rule rule = new Rule("Test");

            IAction action1 = new DummySequentialAction("dummy1");
            Assert.That(action1.Name, Is.EqualTo("dummy1"));
            IAction action2 = new DummySequentialAction("dummy2");
            Assert.That(action2.Name, Is.EqualTo("dummy2"));

            ParallelAction pAction = new ParallelAction("ParallelAction");
            pAction.AddAction(action1);
            pAction.AddAction(action2);
            rule.AddAction(pAction);
            rule.Apply();

            Assert.That(action1.Name, Is.EqualTo("Test"));
            Assert.That(action2.Name, Is.EqualTo("Test"));
        }

        [Test]
        [Category("Rule")]
        public void RuleWithTwoSequentialActions()
        {
            Rule rule = new Rule("Test");

            IAction action1 = new DummySequentialAction("dummy1");
            Assert.That(action1.Name, Is.EqualTo("dummy1"));
            IAction action2 = new DummySequentialAction("dummy2");
            Assert.That(action2.Name, Is.EqualTo("dummy2"));

            rule.AddAction(action1);
            rule.AddAction(action2);
            rule.Apply();

            Assert.That(action1.Name, Is.EqualTo("Test"));
            Assert.That(action2.Name, Is.EqualTo("Test"));
        }

        [Test]
        [Category("Rule")]
        public void RuleWithTwoParallelActions()
        {
            Rule rule = new Rule("Test");

            IAction action1 = new DummySequentialAction("dummy1");
            Assert.That(action1.Name, Is.EqualTo("dummy1"));
            IAction action2 = new DummySequentialAction("dummy2");
            Assert.That(action2.Name, Is.EqualTo("dummy2"));

            ParallelAction pAction1 = new ParallelAction("ParallelAction1");
            pAction1.AddAction(action1);
            pAction1.AddAction(action2);
            rule.AddAction(pAction1);

            IAction action3 = new DummySequentialAction("dummy3");
            Assert.That(action3.Name, Is.EqualTo("dummy3"));
            IAction action4 = new DummySequentialAction("dummy4");
            Assert.That(action4.Name, Is.EqualTo("dummy4"));

            ParallelAction pAction2 = new ParallelAction("ParallelAction2");
            pAction2.AddAction(action3);
            pAction2.AddAction(action4);
            rule.AddAction(pAction2);

            rule.Apply();

            Assert.That(action1.Name, Is.EqualTo("Test"));
            Assert.That(action2.Name, Is.EqualTo("Test"));
            Assert.That(action3.Name, Is.EqualTo("Test"));
            Assert.That(action4.Name, Is.EqualTo("Test"));
        }

        [Test]
        [Category("Rule")]
        public void RuleWithSequentialAndParallelActions()
        {
            Rule rule = new Rule("Test");

            IAction action1 = new DummySequentialAction("dummy1");
            Assert.That(action1.Name, Is.EqualTo("dummy1"));
            IAction action2 = new DummySequentialAction("dummy2");
            Assert.That(action2.Name, Is.EqualTo("dummy2"));
            IAction action3 = new DummySequentialAction("dummy3");
            Assert.That(action3.Name, Is.EqualTo("dummy3"));

            ParallelAction pAction = new ParallelAction("ParallelAction");
            pAction.AddAction(action1);
            pAction.AddAction(action2);

            rule.AddAction(pAction);
            rule.AddAction(action3);
            rule.Apply();

            Assert.That(action1.Name, Is.EqualTo("Test"));
            Assert.That(action2.Name, Is.EqualTo("Test"));
            Assert.That(action3.Name, Is.EqualTo("Test"));
        }
    }
}
