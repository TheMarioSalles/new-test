using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Sow.Components.Databases.Settings;
using Sow.Interfaces.AdminWAPP.WebApi.Infra.DataContexts;
using Sow.Interfaces.AdminWAPP.WebApi.Infra.Repositories.Interfaces;
using Sow.Interfaces.AdminWAPP.WebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.WebApi.Infra.Repositories.Entities
{
    public class UserRepository : IUserRepository
    {
        private readonly AdminWappContext _adminWappContext = null;

        public UserRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _adminWappContext = new AdminWappContext(mongoDbSettings);
        }

        public async Task Add(User e)
        {
            try
            {
                await _adminWappContext.Users.InsertOneAsync(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<User>> GetAll()
        {
            try
            {
                return await _adminWappContext.Users.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<User>> GetAllByUsername(string username)
        {
            try
            {
                var filter = Builders<User>.Filter.Regex("Username", new BsonRegularExpression(String.Format(".*{0}*.", username)));
                return await _adminWappContext.Users.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(string id)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq("Id", id);
                return await _adminWappContext.Users.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetByUsername(string username)
        {
            try
            {
                //var filter = Builders<User>.Filter.Regex("Username", new BsonRegularExpression(String.Format(".*{0}*.", username)));
                var filter = Builders<User>.Filter.Eq("Username", username);
                return await _adminWappContext.Users.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(User e)
        {
            try
            {
                ReplaceOneResult replaceOneResult = await _adminWappContext.Users.ReplaceOneAsync(n => n.Id.Equals(e.Id), e, new UpdateOptions { IsUpsert = true });
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
