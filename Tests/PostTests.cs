using NUnit.Framework;
using M12_Dzianis_Dukhnou.Frame;
using System.Net;

namespace M12_Dzianis_Dukhnou.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class PostTests : BaseTest
    {
        string pathToFile;

        [SetUp]
        public void SetUpPostTests()
        {
            resourse = ResourseType.Users;
            pathToFile = "TestData/PostUserBody.json";
        }

        [Test]
        public void Verify_Post()
        {
            //Arrange
            request = new Request(MethodType.Post, resourse);
            request.CreatePostBody(pathToFile);

            //Act
            response = RestClient.Execute(request);

            //Assert
            Assert.AreEqual
                (
                    HttpStatusCode.Created,
                    response.GetStatusCode(),
                    "The object has not been created (posted)"
                );
        }
    }
}
