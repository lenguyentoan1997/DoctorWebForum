using DoctorsWebForum.Data.DbFactory.Interfaces;
using DoctorsWebForum.Data.UnitOfWork.Interfaces;
using DoctorsWebForum.Models;
using System;
using System.Threading.Tasks;

namespace DoctorsWebForum.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private ApplicationDbContext _db;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public ApplicationDbContext DbContext
        {
            get
            {
                return _db ?? (_db = _dbFactory.Init());
            }
        }

        /// <summary>
        /// Save all changes
        /// </summary>
        /// <returns>Int: Quantity has changed</returns>
        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// Asynchronously saves all changes
        /// </summary>
        /// <returns>Int: Quantity has changed</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}