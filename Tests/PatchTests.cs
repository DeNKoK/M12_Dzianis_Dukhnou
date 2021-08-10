using NUnit.Framework;
using M12_Dzianis_Dukhnou.Frame;
using M12_Dzianis_Dukhnou.Utilities;
using M12_Dzianis_Dukhnou.JsonObjects;

namespace M12_Dzianis_Dukhnou.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class PatchTests : BaseTest
    {
        string pathToFile;

        [SetUp]
        public void SetUpPatchTests()
        {
            resourse = ResourseType.Posts;
            pathToFile = "TestData/PatchPostsBody.json";
        }

        [TestCase(1)]
        [TestCase(10)]
        public void Verify_Patch_TitleUpdate(int postId)
        {
            //Arrange
            PostsRoot post = Utility.ReadJsonFile<PostsRoot>(pathToFile);
            string expectedTitle = post.title;
            request = new Request(MethodType.Patch, resourse, postId);
            request.CreatePostBody(pathToFile);

            //Act
            response = RestClient.Execute(request);
            var responseBody = response.GetJsonResponseBody<PostsRoot>();

            //Assert
            string actualTitle = responseBody.title;
            Assert.AreEqual
                (
                    expectedTitle,
                    actualTitle,
                    "The title of the object has not been updated"
                );
        }
    }
}
