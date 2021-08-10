using M12_Dzianis_Dukhnou.Frame;
using NUnit.Framework;

namespace M12_Dzianis_Dukhnou.Tests
{
    public abstract class BaseTest
    {
        public Request request;
        public Response response;
        public ResourseType resourse;

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
            response.CloseSession();
            request = null;
            response = null;
        }

    }
}
