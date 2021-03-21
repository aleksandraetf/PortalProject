using NewsPortal.BusinessLogic.News.Model;
using NewsPortal.BusinessLogic.User.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.BusinessLogic.News
{
    public interface INewsService
    {
        List<NewsViewModel> GetAll();
        List<NewsViewModel> GetAll(string search,int pageNumber,int pageSize);
        NewsViewModel GetById(int id);
        List<NewsViewModel> GetByUser(string search, int pageNumber, int pageSize, UserModel model);

        void Add(NewsCreateModel model, UserModel user);

        bool Exist(int id);
        void Edit(NewsEditModel model);
    }
}
