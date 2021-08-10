using NUnit.Framework;
using M12_Dzianis_Dukhnou.Frame;
using System.Net;
using System.Collections.Generic;
using M12_Dzianis_Dukhnou.JsonObjects;

[assembly: LevelOfParallelism(2)]
namespace M12_Dzianis_Dukhnou.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class GetTests : BaseTest
    {
        [SetUp]
        public void SetUpGetTests()
        {
            resourse = ResourseType.Users;
        }

        [Test]
        public void Verify_Get_HttpStatusCode()
        {
            //Arrange
            request = new Request(MethodType.Get, resourse);

            //Act
            response = RestClient.Execute(request);

            //Assert
            Assert.AreEqual
                (
                    HttpStatusCode.OK,
                    response.GetStatusCode(),
                    "The response status is not 200 (OK)"
                );
        }

        [Test]
        public void Verify_Get_HttpResponseHeader()
        {
            //Arrange
            request = new Request(MethodType.Get, resourse);

            //Act
            response = RestClient.Execute(request);

            //Assert
            Assert.AreEqual
                (
                    "application/json; charset=utf-8", 
                    response.GetHeaderContent("Content-Type"),
                    "The header \"Content-Type\" is not equal to \"application/json\""
                );
        }

        [Test]
        public void Verify_Get_HttpResponseBody()
        {
            //Arrange
            int expectedNumberOfUsers = 10;
            request = new Request(MethodType.Get, resourse);

            //Act
            response = RestClient.Execute(request);
            var responseBody = response.GetJsonResponseBody<List<UserRoot>>();

            //Assert
            int actualNumberOfUsers = responseBody.Count;
            Assert.AreEqual
                (
                    expectedNumberOfUsers, 
                    actualNumberOfUsers,
                    $"The number of users are not equal {expectedNumberOfUsers}"
                );
        }
    }
}
