namespace SoftwareControllerLibTest
{
    using System;
    using NUnit.Framework;
    using SoftwareControllerApi.Action;
    using SoftwareControllerLib.Action;

    [TestFixture]
    public class ParallelActionTest
    {
        [Test]
        [TestCase("", TestName = "EmptyParallelActionName")]
        [TestCase("   ", TestName = "WhitespaceParallelActionName")]
        [ExpectedException(typeof(ArgumentException))]
        [Category("ParallelAction")]
        public void InvalidName(string name)
        {
            new ParallelAction(name);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("ParallelAction")]
        public void NullParallelActionName()
        {
            new ParallelAction(null);
        }

        [Test]
        [Category("ParallelAction")]
        public void CheckParallelActionName()
        {
            ParallelAction pAction = new ParallelAction("Test");
            Assert.That(pAction.Name, Is.EqualTo("Test"));

            pAction.Name = "NewName";
            Assert.That(pAction.Name, Is.EqualTo("NewName"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("ParallelAction")]
        public void AddNullAction()
        {
            ParallelAction pAction = new ParallelAction("Test");
            pAction.AddAction(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [Category("ParallelAction")]
        public void RemoveNullAction()
        {
            ParallelAction pAction = new ParallelAction("Test");
            pAction.RemoveAction(null);
        }

        [Test]
        [Category("ParallelAction")]
        public void ExecuteEmptyParallelAction()
        {
            ParallelAction pAction = new ParallelAction("Test");
            pAction.Execute();
        }

        [Test]
        [Category("ParallelAction")]
        public void ExecuteActionsInParallel()
        {
            ParallelAction pAction = new ParallelAction("ParallelAction");

            IAction action1 = new DummySequentialAction("dummy1");
            IAction action2 = new DummySequentialAction("dummy2");

            Assert.That(action1.Name, Is.EqualTo("dummy1"));
            Assert.That(action2.Name, Is.EqualTo("dummy2"));

            pAction.AddAction(action1);
            pAction.AddAction(action2);
            pAction.Execute();

            Assert.That(action1.Name, Is.EqualTo("Test"));
            Assert.That(action2.Name, Is.EqualTo("Test"));
        }
    }
}
