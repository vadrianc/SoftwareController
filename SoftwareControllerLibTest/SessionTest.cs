namespace SoftwareControllerLibTest
{
    using System;
    using NUnit.Framework;
    using SoftwareControllerApi.Action;
    using SoftwareControllerApi.Control;
    using SoftwareControllerLib;
    using SoftwareControllerLib.Action;
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

        [Test]
        [Category("Session")]
        public void RunEmptySession()
        {
            Session session = new Session("Test");
            session.Run();
        }

        [Test]
        [Category("Session")]
        public void RunSessionWith2Rules()
        {
            // Rule 1
            Rule rule1 = new Rule("Test");

            IAction action1 = new DummySequentialAction("dummy1");
            Assert.That(action1.Name, Is.EqualTo("dummy1"));
            IAction action2 = new DummySequentialAction("dummy2");
            Assert.That(action2.Name, Is.EqualTo("dummy2"));

            ParallelAction pAction = new ParallelAction("ParallelAction");
            pAction.AddAction(action1);
            pAction.AddAction(action2);
            rule1.AddAction(pAction);

            // Rule 2
            Rule rule2 = new Rule("Test");

            IAction action3 = new DummySequentialAction("dummy1");
            Assert.That(action3.Name, Is.EqualTo("dummy1"));

            rule2.AddAction(action3);

            // Session
            ISession session = new Session("TestSession");
            session.AddRule(rule1);
            session.AddRule(rule2);
            session.Run();

            Assert.That(action1.Name, Is.EqualTo("Test"));
            Assert.That(action2.Name, Is.EqualTo("Test"));
            Assert.That(action3.Name, Is.EqualTo("Test"));
        }

        [Test]
        [Category("Session")]
        public void RemoveRuleFromSession()
        {
            // Rule 1
            Rule rule1 = new Rule("Test1");
            IAction action1 = new DummySequentialAction("dummy1");
            rule1.AddAction(action1);

            // Rule 2
            Rule rule2 = new Rule("Test2");
            IAction action2 = new DummySequentialAction("dummy2");
            rule2.AddAction(action2);

            // Session
            ISession session = new Session("TestSession");
            session.AddRule(rule1);
            session.AddRule(rule2);
            session.RemoveRule(rule1);
            session.Run();

            Assert.That(action1.Name, Is.EqualTo("dummy1"));
            Assert.That(action2.Name, Is.EqualTo("Test"));
        }

        [Test]
        [Category("Session")]
        public void CheckRepeat()
        {
            RepeatableRule rule = new RepeatableRule("RepeatableRule");
            rule.CanRepeat += Repeat;

            DummySequentialAction action = new DummySequentialAction("action");
            rule.AddAction(action);

            Session session = new Session("session");
            session.AddRule(rule);
            session.Run();

            Assert.That(action.Count, Is.EqualTo(4));
        }

        private static int s_Count = 5;

        private static bool Repeat()
        {
            s_Count--;

            return s_Count != 0;
        }

        [Test]
        [Category("Session")]
        public void CheckNonRepeat()
        {
            RepeatableRule rule = new RepeatableRule("RepeatableRule");

            DummySequentialAction action = new DummySequentialAction("action");
            rule.AddAction(action);

            Session session = new Session("session");
            session.AddRule(rule);
            session.Run();

            Assert.That(action.Count, Is.EqualTo(1));
        }
    }
}
