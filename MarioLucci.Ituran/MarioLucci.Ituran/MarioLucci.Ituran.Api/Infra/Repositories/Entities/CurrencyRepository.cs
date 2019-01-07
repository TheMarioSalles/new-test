using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Sow.Components.Databases.Settings;
using MarioLucci.Ituran.Api.Infra.DataContexts;
using MarioLucci.Ituran.Api.Infra.Repositories.Interfaces;
using MarioLucci.Ituran.Api.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioLucci.Ituran.Api.Infra.Repositories.Entities
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly IturanTestContext _ituranTestContext = null;

        public CurrencyRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _ituranTestContext = new IturanTestContext(mongoDbSettings);
        }

        public async Task Add(Currency e)
        {
            try
            {
                await _ituranTestContext.Currency.InsertOneAsync(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<Currency>> GetAll()
        {
            try
            {
                return await _ituranTestContext.Currency.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<Currency>> GetAllByShortName(string username)
        {
            try
            {
                var filter = Builders<Currency>.Filter.Regex("ShortName", new BsonRegularExpression(String.Format(".*{0}*.", username)));
                return await _ituranTestContext.Currency.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Currency> GetById(string id)
        {
            try
            {
                var filter = Builders<Currency>.Filter.Eq("Id", id);
                return await _ituranTestContext.Currency.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Currency> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Currency e)
        {
            throw new NotImplementedException();
        }
    }
}
