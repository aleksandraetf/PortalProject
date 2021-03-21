using NewsPortal.DAL;
using NewsPortal.DAL.NewsPortal;
using NewsPortal.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace NewsPortal.Repository.UsersRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PortalDbContext context) : base(context)
        {

        }

        public User GetUser(string username, string password)
        {
            return DbContext.User.FirstOrDefault(user => user.Username == username && user.Password==password);
        }
    }
}
