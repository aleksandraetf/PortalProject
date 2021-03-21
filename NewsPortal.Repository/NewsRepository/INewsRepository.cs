using NewsPortal.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsPortal.Repository.News
{
    public interface INewsRepository : IBaseRepository<NewsPortal.DAL.NewsPortal.News>
    {
         IQueryable<DAL.NewsPortal.News> GetAll(string search, int pageNumber, int pageSize);
         IQueryable<DAL.NewsPortal.News> GetByUser(string search, int pageNumber, int pageSize, int userId)


;    }
}
