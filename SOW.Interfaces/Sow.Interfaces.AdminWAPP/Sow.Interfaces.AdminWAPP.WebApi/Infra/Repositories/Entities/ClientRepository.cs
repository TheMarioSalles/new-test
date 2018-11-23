using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Sow.Components.Databases.Repositories.Interfaces;
using Sow.Components.Databases.Settings;
using Sow.Interfaces.AdminWAPP.WebApi.Infra.DataContexts;
using Sow.Interfaces.AdminWAPP.WebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.WebApi.Infra.Repositories.Entities
{
    public class ClientRepository : IReadRepositoryBase<Client>, IWriteRepositoryBase<Client>
    {
        private readonly AdminWappContext _adminWappContext = null;

        public ClientRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _adminWappContext = new AdminWappContext(mongoDbSettings);
        }

        internal async Task<Client> GetByDocument(string document)
        {
            var filter = Builders<Client>.Filter.Eq("Document", document);
            try
            {
                return await _adminWappContext.Clients.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task Add(Client e)
        {
            try
            {
                await _adminWappContext.Clients.InsertOneAsync(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<Client>> GetAll()
        {
            try
            {
                return await _adminWappContext.Clients.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Client> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetById(string id)
        {
            try
            {
                var filter = Builders<Client>.Filter.Eq("Id", id);
                return await _adminWappContext.Clients.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(Client e)
        {
            try
            {
                ReplaceOneResult replaceOneResult = await _adminWappContext.Clients.ReplaceOneAsync(n => n.Id.Equals(e.Id), e, new UpdateOptions { IsUpsert = true });
                return replaceOneResult.IsAcknowledged
                    && replaceOneResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
