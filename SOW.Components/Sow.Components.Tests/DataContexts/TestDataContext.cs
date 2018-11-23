using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sow.Components.Databases.DataContexts;
using Sow.Components.Databases.Settings;
using Sow.Components.Tests.Models.Entities;

namespace Sow.Components.Tests.DataContexts
{
    public class TestDataContext : MongoDbDataContext
    {
        public TestDataContext(IOptions<MongoDbSettings> mongoDbSettings) : base(mongoDbSettings) {}

        public IMongoCollection<User> Users
        {
            get { return base._mongoDatabase.GetCollection<User>("User"); }
        }
    }
}
