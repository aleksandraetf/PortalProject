using Microsoft.EntityFrameworkCore;
using NewsPortal.DAL;
using NewsPortal.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NewsPortal.Repository.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        TEntity Get(int id);

        IQueryable<TEntity> GetAll(bool asNoTracking = true);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        int Count();

        void Remove(int id);
    }


    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IBaseEntity
    {
        protected readonly PortalDbContext DbContext;
        internal DbSet<TEntity> DbSet;

        public BaseRepository(PortalDbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            var temp = DbSet.Add(entity);
            return temp.Entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual IQueryable<TEntity> GetAll(bool asNoTracking)
        {
            return asNoTracking ? DbContext.Set<TEntity>() : DbContext.Set<TEntity>().AsNoTracking();
        }

        public virtual TEntity Get(int id)
        {
            return DbSet.FirstOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(Get(id));
        }
    }
}
