namespace SoftwareControllerLibTest
{
    using System.Collections.Generic;
    using SoftwareControllerApi.Action;
    using SoftwareControllerApi.Rule;

    public class DummyResultProcessor : IResultProcessor
    {
        public static int Count
        {
            get;
            private set;
        }

        public void Process(IList<IResult> results)
        {
            Count = results.Count;
        }
    }
}
