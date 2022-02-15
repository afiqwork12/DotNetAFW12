using NUnit.Framework;
using SampleMCVTogetherApp;
using SampleMCVTogetherApp.Services;
using SampleMCVTogetherApp.Models;

namespace SampleMVCTogetherTest
{
    public class Tests
    {
        IRepo<string, User> repo;
        [SetUp]
        public void Setup()
        {
            //arrange
            repo = new UserTempService();
        }

        [Test]
        public void SimpleTest()
        {
            //act
            var result = repo.Delete("1");
            //assert
            Assert.IsTrue(result);
        }
    }
}