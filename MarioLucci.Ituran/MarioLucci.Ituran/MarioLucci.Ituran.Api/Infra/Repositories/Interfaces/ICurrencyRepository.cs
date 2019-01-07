using Sow.Components.Databases.Repositories.Interfaces;
using MarioLucci.Ituran.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioLucci.Ituran.Api.Infra.Repositories.Interfaces
{
    public interface ICurrencyRepository : IReadRepositoryBase<Currency>, IWriteRepositoryBase<Currency>
    {
        Task<ICollection<Currency>> GetAllByShortName(string shortName);
    }
}
