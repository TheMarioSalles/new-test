using Sow.Interfaces.AdminWAPP.WebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.WebApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<ICollection<User>> GetAll();
        Task<ICollection<User>> GetAllByUsername(string username);
        Task<User> GetById(string id);
        Task<User> GetByUsername(string username);
        Task<User> Add(User user, string password);
        Task Update(User user, string password = null);
    }
}
