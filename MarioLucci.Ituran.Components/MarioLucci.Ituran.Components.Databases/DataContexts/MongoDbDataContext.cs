using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sow.Components.Databases.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sow.Components.Databases.DataContexts
{
    public class MongoDbDataContext
    {
        protected readonly IMongoDatabase _mongoDatabase = null;

        public MongoDbDataContext(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            if (mongoClient != null)
                _mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.Database);
        }
    }
}
