using DoctorsWebForum.Data.DbFactory.Interfaces;
using DoctorsWebForum.Data.Repositories.Interfaces;
using DoctorsWebForum.Models.Forum;

namespace DoctorsWebForum.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}