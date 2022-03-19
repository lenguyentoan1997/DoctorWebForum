using DoctorsWebForum.Models.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DoctorsWebForum.Data.Services.Interfaces
{
    public interface IClientService
    {
        void Add(Client client);

        void Update(Client client);

        void Remove(Client client);

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}