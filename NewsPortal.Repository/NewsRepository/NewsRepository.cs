using NewsPortal.DAL;
using NewsPortal.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;
using NewsPortal.DAL.NewsPortal;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NewsPortal.Repository.News
{
    public class NewsRepository : BaseRepository<DAL.NewsPortal.News>, INewsRepository
    {
        public NewsRepository(PortalDbContext context) : base(context)
        {

        }
        public override IQueryable<DAL.NewsPortal.News> GetAll(bool asNoTracking)
        {
           
           return DbContext.News.Include(news => news.User);
        }

        public  IQueryable<DAL.NewsPortal.News> GetAll(string search, int pageNumber,int pageSize)
        {
            return DbContext.News.Include(news => news.User)
                .Where(news=>news.Text.ToLower().Contains(search.ToLower()))
                .Skip((pageNumber)*pageSize).Take(pageSize);
        }

        public IQueryable<DAL.NewsPortal.News> GetByUser(string search, int pageNumber, int pageSize, int userId)
        {
            return DbContext.News.Include(news => news.User)
                .Where(news => news.Text.ToLower().Contains(search.ToLower()) && news.UserId==userId)
                .Skip((pageNumber) * pageSize).Take(pageSize);
        }
    }
}
