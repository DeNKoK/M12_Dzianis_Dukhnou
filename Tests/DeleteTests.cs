using NUnit.Framework;
using M12_Dzianis_Dukhnou.Frame;
using System.Net;

namespace M12_Dzianis_Dukhnou.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DeleteTests : BaseTest
    {
        [SetUp]
        public void SetUpDeleteTests()
        {
            resourse = ResourseType.Posts;
        }

        [TestCase(1)]
        [TestCase(10)]
        public void Verify_Delete_Ok(int postId)
        {
            //Arrange
            request = new Request(MethodType.Delete, resourse, postId);

            //Act
            response = RestClient.Execute(request);

            //Assert
            Assert.AreEqual
                (
                    HttpStatusCode.OK,
                    response.GetStatusCode(),
                    "The object has not been deleted"
                );
        }
    }
}
