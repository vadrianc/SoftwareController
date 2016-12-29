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

        public int Count
        {
            get; private set;
        }

        public DummySequentialAction(string name)
        {
            Name = name;
            Count = 0;
        }

        public IResult Execute()
        {
            Name = "Test";
            Count++;

            return new SingleResult<string>("Test", ActionState.SUCCESS);
        }
    }
}
