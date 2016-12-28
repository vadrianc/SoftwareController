namespace SoftwareControllerLibTest
{
    using SoftwareControllerApi.Action;
    using SoftwareControllerLib.Action;

    /// <summary>
    /// Dummy action implementation used only for running unit tests.
    /// </summary>
    public class DummySequentialAction : IAction
    {
        public string Name
        {
            get; set;
        }

        public DummySequentialAction(string name)
        {
            Name = name;
        }

        public IResult Execute()
        {
            Name = "Test";

            return new SingleResult<string>("Test", ActionState.SUCCESS);
        }
    }
}
