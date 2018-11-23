using Sow.Components.Databases.Repositories.Interfaces;
using Sow.Interfaces.AdminWAPP.WebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.WebApi.Infra.Repositories.Interfaces
{
    public interface IUserRepository : IReadRepositoryBase<User>, IWriteRepositoryBase<User>
    {
        Task<User> GetByUsername(string username);

        Task<ICollection<User>> GetAllByUsername(string username);
    }
}
