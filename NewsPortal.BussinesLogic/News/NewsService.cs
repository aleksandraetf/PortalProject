using NewsPortal.BusinessLogic.News.Model;
using NewsPortal.BusinessLogic.User.Model;
using NewsPortal.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsPortal.BusinessLogic.News
{
    public class NewsService : INewsService
    {

        private readonly INewsUnitOfWork _newsUnitOfWork;

        public NewsService(INewsUnitOfWork newsUnitOfWork)
        {
            _newsUnitOfWork = newsUnitOfWork;
        }


        public List<NewsViewModel> GetAll()
        {
            return _newsUnitOfWork.News.GetAll().ToList().Select(news => new NewsViewModel
            {
                Id = news.Id,
                Date = news.Date.ToShortDateString(),
                Text = news.Text,
                UserId = news.UserId,
                UserName = news.User.Username

            }).ToList();
        }

        public NewsViewModel GetById(int id)
        {
            var dbModel = _newsUnitOfWork.News.Get(id);
            if (dbModel == null) return null;

            var result = new NewsViewModel
            {
                Id = dbModel.Id,
                Date = dbModel.Date.ToShortDateString(),
                Text = dbModel.Text,
                UserId = dbModel.UserId
            };

            return result;
        }

        public void Add(NewsCreateModel model,UserModel user)
        {
            _newsUnitOfWork.News.Add(new DAL.NewsPortal.News
            {
                Text = model.Text,
                Date = DateTime.Now,
                UserId = user.Id
            });

            _newsUnitOfWork.Complete();
        }

        public bool Exist(int id)
        {
            return _newsUnitOfWork.News.Get(id) != null ? true : false;
        }

        public void Edit(NewsEditModel model)
        {
            var newsDb = _newsUnitOfWork.News.Get(model.Id);
            newsDb.Text = model.Text;
            newsDb.Date = DateTime.Now;
            _newsUnitOfWork.Complete();
        }

        public List<NewsViewModel> GetAll(string search, int pageNumber, int pageSize)
        {
            return _newsUnitOfWork.News.GetAll(search,pageNumber-1,pageSize).Select(news=>new  NewsViewModel(){
                Id = news.Id,
                Date = news.Date.ToShortDateString(),
                Text = news.Text,
                UserId = news.UserId,
                UserName = news.User.Username
            }).ToList();
        }

        public List<NewsViewModel> GetByUser(string search, int pageNumber, int pageSize, UserModel model)
        {
            return _newsUnitOfWork.News.GetByUser(search, pageNumber - 1, pageSize,model.Id).Select(news => new NewsViewModel()
            {
                Id = news.Id,
                Date = news.Date.ToShortDateString(),
                Text = news.Text,
                UserId = news.UserId,
                UserName = news.User.Username
            }).ToList();
        }
    }
}
