using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sow.Components.Databases.Repositories.Interfaces;
using Sow.Components.Databases.Settings;
using Sow.Components.Tests.DataContexts;
using Sow.Components.Tests.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Components.Tests.Repositories.Entities
{
    public class UserRepository : IReadRepositoryBase<User>, IWriteRepositoryBase<User>
    {
        private readonly TestDataContext _testDataContext = null;

        public UserRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _testDataContext = new TestDataContext(mongoDbSettings);
        }

        public async Task<ICollection<User>> GetAll()
        {
            try
            {
                return await _testDataContext.Users.Find(_ => true).ToListAsync();
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
                return await _testDataContext.Users.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Add(User e)
        {
            try
            {
                await _testDataContext.Users.InsertOneAsync(e);
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
                ReplaceOneResult replaceOneResult = await _testDataContext.Users.ReplaceOneAsync(
                    n => n.Id.Equals(e.Id), e, new UpdateOptions { IsUpsert = true });
                return (replaceOneResult.IsAcknowledged && replaceOneResult.ModifiedCount > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
