using Microsoft.Extensions.Options;
using Sow.Components.Databases.Settings;
using MarioLucci.Ituran.Api.Infra.Repositories.Entities;
using MarioLucci.Ituran.Api.Infra.Repositories.Interfaces;
using MarioLucci.Ituran.Api.Models.Entities;
using MarioLucci.Ituran.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioLucci.Ituran.Api.Services.Entities
{
    public class CurrencyService : ICurrencyService
    {
        private CurrencyRepository _CurrencyRepository;

        public CurrencyService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _CurrencyRepository = new CurrencyRepository(mongoDbSettings);
        }

        public async Task<Currency> Add(Currency Currency, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("O campo Senha é obrigatório!");

            if (await _CurrencyRepository.GetAllByShortName(Currency.ShortName) != null)
                throw new Exception(String.Format("O nome {0} já está em uso! Favor escolher outro!", Currency.ShortName));

            await _CurrencyRepository.Add(Currency);

            return Currency;
        }

        public async Task<ICollection<Currency>> GetAll()
        {
            return await _CurrencyRepository.GetAll();
        }

        public async Task<ICollection<Currency>> GetAllByShortName(string Currencyname)
        {
            return await _CurrencyRepository.GetAllByShortName(Currencyname);
        }

        public async Task<Currency> GetById(string id)
        {
            return await _CurrencyRepository.GetById(id);
        }

        public async Task Update(Currency CurrencyParam, string password = null)
        {
            //var Currency = await _CurrencyRepository.GetById(CurrencyParam.Id);

            //if (Currency == null)
            //    throw new Exception("Usuário não encontrado!");

            //if (CurrencyParam.Currencyname != Currency.Currencyname)
            //{
            //    // Currencyname has changed so check if the new Currencyname is already taken
            //    if (await _CurrencyRepository.GetByCurrencyname(CurrencyParam.Currencyname) != null)
            //        throw new Exception(String.Format("Currencyname {0} is already taken!", CurrencyParam.Currencyname));
            //}

            //// update Currency properties
            //Currency.ClientId = CurrencyParam.ClientId;
            //Currency.Email = CurrencyParam.Email;
            //Currency.Name = CurrencyParam.Name;
            //Currency.Status = CurrencyParam.Status;
            //Currency.Currencyname = CurrencyParam.Currencyname;

            //// update password if it was entered
            //if (!string.IsNullOrWhiteSpace(password))
            //{
            //    byte[] passwordHash, passwordSalt;
            //    CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //    Currency.PasswordHash = passwordHash;
            //    Currency.PasswordSalt = passwordSalt;
            //}

            //await _CurrencyRepository.Update(Currency);
        }
    }
}
