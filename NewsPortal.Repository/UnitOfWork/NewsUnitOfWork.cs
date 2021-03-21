using NewsPortal.DAL;
using NewsPortal.Repository.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Repository.UnitOfWork
{
    public class NewsUnitOfWork : INewsUnitOfWork
    {

        private readonly PortalDbContext _dbContext;
        public INewsRepository News { get; }

        public NewsUnitOfWork(PortalDbContext context)
        {
            _dbContext = context;
            News = new NewsRepository(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
    }
}
