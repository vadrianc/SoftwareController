namespace SoftwareControllerLibTest
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using SoftwareControllerApi.Action;
    using SoftwareControllerLib.Action;

    [TestFixture]
    public class MultiRuleTest
    {
        [Test]
        [Category("MultiRule")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullResults()
        {
            new MultiResult(null, ActionState.SUCCESS, null);
        }

        [Test]
        [Category("MultiRule")]
        public void AllSuccessful()
        {
            List<IResult> results = new List<IResult>();
            results.Add(new Result(1, ActionState.SUCCESS));
            results.Add(new Result(2, ActionState.SUCCESS));

            MultiResult multiResult = new MultiResult(null, ActionState.SUCCESS, results);

            Assert.That(multiResult.State, Is.EqualTo(ActionState.SUCCESS));
        }

        [Test]
        [Category("MultiRule")]
        public void OneFailed()
        {
            List<IResult> results = new List<IResult>();
            results.Add(new Result(1, ActionState.SUCCESS));
            results.Add(new Result(2, ActionState.FAIL));

            MultiResult multiResult = new MultiResult(null, ActionState.SUCCESS, results);

            Assert.That(multiResult.State, Is.EqualTo(ActionState.FAIL));
        }

        [Test]
        [Category("MultiRule")]
        public void AllNotExecuted()
        {
            List<IResult> results = new List<IResult>();
            results.Add(new Result(1, ActionState.NOT_EXECUTED));
            results.Add(new Result(2, ActionState.NOT_EXECUTED));

            MultiResult multiResult = new MultiResult(null, ActionState.SUCCESS, results);

            Assert.That(multiResult.State, Is.EqualTo(ActionState.NOT_EXECUTED));
        }

        [Test]
        [Category("MultiRule")]
        public void CheckResults()
        {
            List<IResult> results = new List<IResult>();
            IResult result1 = new Result(1, ActionState.SUCCESS);
            results.Add(result1);
            IResult result2 = new Result(2, ActionState.NOT_EXECUTED);
            results.Add(result2);
            IResult result3 = new Result(3, ActionState.FAIL);
            results.Add(result3);

            MultiResult multiResult = new MultiResult(null, ActionState.SUCCESS, results);

            Assert.That(multiResult.State, Is.EqualTo(ActionState.FAIL));

            Assert.That(results[0], Is.EqualTo(result1));
            Assert.That(results[0].Content, Is.EqualTo(result1.Content));
            Assert.That(results[0].State, Is.EqualTo(result1.State));

            Assert.That(results[1], Is.EqualTo(result2));
            Assert.That(results[1].Content, Is.EqualTo(result2.Content));
            Assert.That(results[1].State, Is.EqualTo(result2.State));

            Assert.That(results[2], Is.EqualTo(result3));
            Assert.That(results[2].Content, Is.EqualTo(result3.Content));
            Assert.That(results[2].State, Is.EqualTo(result3.State));
        }
    }
}
