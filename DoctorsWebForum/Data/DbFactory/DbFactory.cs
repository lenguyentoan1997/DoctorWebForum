using DoctorsWebForum.Data.DbFactory.Interfaces;
using DoctorsWebForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorsWebForum.Data.DbFactory
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ApplicationDbContext _db;
       
        public ApplicationDbContext Init()
        {
            return _db ?? (_db = new ApplicationDbContext());
        }

        protected override void DisposeCore()
        {
            if(_db != null)
            {
                _db.Dispose();
            }
        }
    }
}