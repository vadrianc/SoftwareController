namespace SoftwareControllerLibTest
{
    using NUnit.Framework;
    using SoftwareControllerApi.Action;
    using SoftwareControllerLib.Action;

    [TestFixture]
    public class ResultTest
    {
        [Test]
        [Category("Result")]
        public void CreateResult()
        {
            object content = new object();
            IResult result = new Result(content, ActionState.SUCCESS);

            Assert.That(result.Content, Is.EqualTo(content));
            Assert.That(result.State, Is.EqualTo(ActionState.SUCCESS));
        }
    }
}
