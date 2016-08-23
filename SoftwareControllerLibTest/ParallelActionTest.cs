namespace SoftwareControllerLibTest
{
    using System;
    using NUnit.Framework;
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
    }
}
