using NewsPortal.DAL;
using NewsPortal.Repository.UsersRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Repository.UnitOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly PortalDbContext _dbContext;
        public IUserRepository User { get; }

        public UserUnitOfWork(PortalDbContext context)
        {
            _dbContext = context;
            User = new UserRepository(_dbContext);
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
