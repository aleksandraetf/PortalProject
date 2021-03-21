using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewsPortal.BusinessLogic.User;
using NewsPortal.BusinessLogic.User.Model;
using NewsPortalApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestsProject.Controllers
{
    [TestClass]
    public class AuthenticationControllerTest
    {
        private Moq.Mock<IUserService> userService;
        private AuthenticationController authenticationController;
        private UserModel user;

        [TestInitialize]
        public void init() {
            userService = new Moq.Mock<IUserService>();
            user = new UserModel { FirstName = "a", LastName = "b", Id = 1, Password = "sd", Username = "sadsadsda" };
        }

        [TestMethod]
        public void Authenticate_NegativeCase()
        {
            authenticationController = new AuthenticationController(userService.Object);
            var result = authenticationController.Authenticate(new AuthenticateRequest());

            var resStatus = result  as ObjectResult;
            Assert.AreEqual(400, resStatus.StatusCode);
            Assert.AreEqual("Username or password is incorrect", resStatus.Value);
        }


        [TestMethod]
        public void Authenticate_PositiveCase()
        {
            var response = new AuthenticateResponse(user, "TOKEN");
            userService.Setup(ob => ob.Authenticate(It.IsAny<AuthenticateRequest>())).Returns(response);
            authenticationController = new AuthenticationController(userService.Object);
            var result = authenticationController.Authenticate(new AuthenticateRequest());

            var resStatus = result as ObjectResult;
            Assert.AreEqual(200, resStatus.StatusCode);
            Assert.AreEqual(response, resStatus.Value);
        }
    }
}
