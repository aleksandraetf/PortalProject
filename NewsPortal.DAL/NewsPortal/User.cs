using NewsPortal.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.DAL.NewsPortal
{
    public partial class User : IBaseEntity
    {
        public User()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; private set; }

        public virtual ICollection<News> News { get; set; }

    }
}
