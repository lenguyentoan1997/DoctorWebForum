using DoctorsWebForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsWebForum.Data.DbFactory.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        ApplicationDbContext Init();
    }
}
