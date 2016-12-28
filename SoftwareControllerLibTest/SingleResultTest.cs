namespace SoftwareControllerLibTest
{
    using NUnit.Framework;
    using SoftwareControllerApi.Action;
    using SoftwareControllerLib.Action;

    [TestFixture]
    public class SingleResultTest
    {
        [Test]
        [Category("Result")]
        public void CreateResult()
        {
            object content = new object();
            SingleResult<object> result = new SingleResult<object>(content, ActionState.SUCCESS);

            Assert.That(result.Content, Is.EqualTo(content));
            Assert.That(result.State, Is.EqualTo(ActionState.SUCCESS));
        }
    }
}
