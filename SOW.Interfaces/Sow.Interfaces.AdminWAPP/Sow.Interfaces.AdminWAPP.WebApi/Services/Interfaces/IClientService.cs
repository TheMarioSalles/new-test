using Sow.Interfaces.AdminWAPP.WebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.WebApi.Services.Interfaces
{
    public interface IClientService
    {
        Task<ICollection<Client>> GetAll();
        Task<Client> GetById(string id);
        Task<Client> Add(Client client);
        Task<bool> Update(Client client);

        Task AddAccount(Client client, Account account);
        Task UpdateAccount(Client client, Account account);
    }
}
