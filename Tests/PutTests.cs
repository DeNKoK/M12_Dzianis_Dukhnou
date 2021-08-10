using NUnit.Framework;
using M12_Dzianis_Dukhnou.Frame;
using System.Net;

namespace M12_Dzianis_Dukhnou.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class PutTests : BaseTest
    {
        string pathToFile;

        [SetUp]
        public void SetUpPutTests()
        {
            resourse = ResourseType.Posts;
            pathToFile = "TestData/PutPostsBody.json";
        }

        [TestCase(1)]
        [TestCase(10)]
        public void Verify_Put_Ok(int postId)
        {
            //Arrange
            request = new Request(MethodType.Put, resourse, postId);
            request.CreatePostBody(pathToFile);

            //Act
            response = RestClient.Execute(request);

            //Assert
            Assert.AreEqual
                (
                    HttpStatusCode.OK,
                    response.GetStatusCode(),
                    "The object has not been updated"
                );
        }
    }
}
