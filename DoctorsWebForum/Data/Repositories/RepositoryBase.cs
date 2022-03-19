using DoctorsWebForum.Data.DbFactory.Interfaces;
using DoctorsWebForum.Data.Repositories.Interfaces;
using DoctorsWebForum.Models;
using System.Data.Entity;

namespace DoctorsWebForum.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private ApplicationDbContext _db;
        private readonly IDbSet<T> _dbSet;

        protected IDbFactory DbFactory { get; private set; }

        protected ApplicationDbContext DbContext
        {
            get
            {
                return _db ?? (_db = DbFactory.Init());
            }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}