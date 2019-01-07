using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sow.Components.Databases.DataContexts;
using Sow.Components.Databases.Settings;
using MarioLucci.Ituran.Api.Models.Entities;

namespace MarioLucci.Ituran.Api.Infra.DataContexts
{
    public class IturanTestContext : MongoDbDataContext
    {
        public IturanTestContext(IOptions<MongoDbSettings> mongoDbSettings) : base(mongoDbSettings) { }
        public IMongoCollection<Currency> Currency { get { return base._mongoDatabase.GetCollection<Currency>("Currency"); } }
    }
}
