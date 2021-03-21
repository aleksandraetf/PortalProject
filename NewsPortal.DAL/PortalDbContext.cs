using Microsoft.EntityFrameworkCore;
using NewsPortal.DAL.NewsPortal;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.DAL
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options)
          : base(options)
        {

        }

        public DbSet<News> News { get; set; }
        public DbSet<User> User { get; set; }
    }
}
