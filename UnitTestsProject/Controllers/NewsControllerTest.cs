using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewsPortal.BusinessLogic.News;
using NewsPortal.BusinessLogic.News.Model;
using NewsPortal.BusinessLogic.User.Model;
using NewsPortalApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Net;

namespace UnitTestsProject
{
    [TestClass]
    public class NewsControllerTest
    {
        private Moq.Mock<INewsService> newsService;
        private Moq.Mock<IHttpContextAccessor> httpContextAccessor;
        private List<NewsViewModel> list;
        private UserModel user;

        [TestInitialize]
        public void Initialize()
        {
            newsService = new Moq.Mock<INewsService>();
            httpContextAccessor = new Moq.Mock<IHttpContextAccessor>();

            var model = new NewsViewModel { Date = DateTime.Now.ToString(), Id = 1, Text = "TEXT", UserId = 3 };
            list = new List<NewsViewModel>();
            list.Add(model);

            newsService.Setup(ob => ob.GetAll(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(list);
            newsService.Setup(ob => ob.GetByUser(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<UserModel>())).Returns(list);
            user = new UserModel { FirstName = "a", LastName = "b", Id = 1, Password = "sd", Username = "sadsadsda" };

            var context = new DefaultHttpContext();
            context.Items["User"] = user;

            httpContextAccessor.Setup(ob => ob.HttpContext).Returns(context);
        }

        [TestMethod]
        public void GetAll()
        {
            var newsController = new NewsController(newsService.Object, httpContextAccessor.Object);

            var result = newsController.Get();
            Assert.AreEqual(list, result.Value);
            newsService.Verify(mock => mock.GetAll("", 1, 250), Times.Once());
        }


        [TestMethod]
        public void GetAllWithParams()
        {
            var newsController = new NewsController(newsService.Object, httpContextAccessor.Object);

            var result = newsController.Get("ok", 5, 15);
            Assert.AreEqual(list, result.Value);
            newsService.Verify(mock => mock.GetAll("ok", 5, 15), Times.Once());
        }


        [TestMethod]
        public void GetAll_ThrowingException_Returns()
        {
            newsService.Setup(ob => ob.GetAll(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Throws(new Exception("Error"));

            var newsController = new NewsController(newsService.Object, httpContextAccessor.Object);

            var result = newsController.Get("ok", 5, 15);
            var resultStatusCode = result.Result as StatusCodeResult;
            Assert.AreEqual(404, resultStatusCode.StatusCode);
            newsService.Verify(mock => mock.GetAll("ok", 5, 15), Times.Once());
        }

        [TestMethod]
        public void GetByUser()
        {
            var newsController = new NewsController(newsService.Object, httpContextAccessor.Object);

            var result = newsController.GetByUser();
            Assert.AreEqual(list, result.Value);
            newsService.Verify(mock => mock.GetByUser("", 1, 250, user), Times.Once());
        }

        [TestMethod]
        public void CreatingNews_ShouldCreateNews()
        {
            var news = new NewsCreateModel { Text = "Testing" };
            var newsController = new NewsController(newsService.Object, httpContextAccessor.Object);

            var result = newsController.Post(news);
            var resStatusCode = result as StatusCodeResult;
            Assert.AreEqual(200, resStatusCode.StatusCode);
            newsService.Verify(mock => mock.Add(news, user), Times.Once());
        }

        [TestMethod]
        public void CreatingNews_ThrowingException_ShouldReturnBadRequest()
        {
            var news = new NewsCreateModel { Text = "Testing" };
            newsService.Setup(ob => ob.Add(It.IsAny<NewsCreateModel>(), It.IsAny<UserModel>())).Throws(new Exception());
            var newsController = new NewsController(newsService.Object, httpContextAccessor.Object);

            var result = newsController.Post(news);
            var resStatusCode = result as StatusCodeResult;
            Assert.AreEqual(400, resStatusCode.StatusCode);
            newsService.Verify(mock => mock.Add(news, user), Times.Once());
        }

        [TestMethod]
        public void UpdatingNews_ShouldUpdateNews()
        {
            var createdNews = new NewsViewModel { Date = DateTime.Now.ToString(), Id = 1, Text = "TESTING NEWS", UserId = user.Id };
            newsService.Setup(ob => ob.GetById(It.IsAny<int>())).Returns(createdNews);

            var news = new NewsEditModel { Text = "Testing", Id =1 };
            var newsController = new NewsController(newsService.Object, httpContextAccessor.Object);

            var result = newsController.Put(1, news);
            var resStatusCode = result as StatusCodeResult;
            Assert.AreEqual(200, resStatusCode.StatusCode);
            newsService.Verify(mock => mock.Edit(news), Times.Once());
        }


        [TestMethod]
        public void UpdatingNews_NotAllowedToEditSomeoneElsesNews()
        {
            var createdNews = new NewsViewModel { Date = DateTime.Now.ToString(), Id = 1, Text = "TESTING NEWS", UserId = user.Id + 5 };
            newsService.Setup(ob => ob.GetById(It.IsAny<int>())).Returns(createdNews);

            var news = new NewsEditModel { Text = "Testing", Id = 1 };
            var newsController = new NewsController(newsService.Object, httpContextAccessor.Object);

            var result = newsController.Put(1, news);
            var resStatusCode = result as StatusCodeResult;
            Assert.AreEqual(401, resStatusCode.StatusCode);
            newsService.Verify(mock => mock.Edit(It.IsAny<NewsEditModel>()), Times.Never());
        }


        [TestMethod]
        public void UpdatingNews_NotFound()
        {
            var news = new NewsEditModel { Text = "Testing", Id = 1 };
            var newsController = new NewsController(newsService.Object, httpContextAccessor.Object);

            var result = newsController.Put(1, news);
            var resStatusCode = result as StatusCodeResult;
            Assert.AreEqual(404, resStatusCode.StatusCode);
            newsService.Verify(mock => mock.Edit(It.IsAny<NewsEditModel>()), Times.Never());
        }

    }
}
