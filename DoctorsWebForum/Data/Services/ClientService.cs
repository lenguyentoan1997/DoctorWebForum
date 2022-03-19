using DoctorsWebForum.Data.Repositories.Interfaces;
using DoctorsWebForum.Data.Services.Interfaces;
using DoctorsWebForum.Data.UnitOfWork.Interfaces;
using DoctorsWebForum.Models.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DoctorsWebForum.Data.Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;

        private IUnitOfWork _unitOfWork;

        public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Client client)
        {
            _clientRepository.Add(client);
        }

        public void Remove(Client client)
        {
            _clientRepository.Remove(client);
        }
       
        public void Update(Client client)
        {
            _clientRepository.Update(client);
        }

        public int SaveChanges()
        {
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}