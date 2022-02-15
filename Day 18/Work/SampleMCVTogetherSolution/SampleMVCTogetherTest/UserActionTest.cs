using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SampleMCVTogetherApp;
using SampleMCVTogetherApp.Services;
using SampleMCVTogetherApp.Models;
using Moq;

namespace SampleMVCTogetherTest
{
    public class UserActionTest
    {
        //[SetUp]
        //public void Setup()
        //{
        //    //arrange
        //}

        [Test]
        public void SimpleTest()
        {
            //arrange
            Mock<UserEFRepo> mockRepo = new Mock<UserEFRepo>();
            mockRepo.Setup(x => x.GetT("abc")).Returns(
                new User() 
                { 
                    Username = "abc", 
                    Password = "abc123" 
                }
            );
            LoginService service = new LoginService(mockRepo.Object);
            User user = new User() { Username = "abc", Password = "abc123" };
            //act
            var resultuser = service.LoginCheck(user);
            //assert
            Assert.IsNotNull(resultuser);
        }
    }
}
