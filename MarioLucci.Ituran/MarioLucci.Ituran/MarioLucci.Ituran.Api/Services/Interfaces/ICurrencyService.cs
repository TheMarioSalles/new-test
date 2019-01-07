using MarioLucci.Ituran.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioLucci.Ituran.Api.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<ICollection<Currency>> GetAll();
        Task<ICollection<Currency>> GetAllByShortName(string shortName);
        Task<Currency> GetById(string id);
    }
}
