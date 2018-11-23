using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sow.Components.Databases.DataContexts;
using Sow.Components.Databases.Settings;
using Sow.Interfaces.AdminWAPP.WebApi.Models.Entities;

namespace Sow.Interfaces.AdminWAPP.WebApi.Infra.DataContexts
{
    public class AdminWappContext : MongoDbDataContext
    {
        public AdminWappContext(IOptions<MongoDbSettings> mongoDbSettings) : base(mongoDbSettings) { }
        public IMongoCollection<Account> Accounts { get { return base._mongoDatabase.GetCollection<Account>("Account"); } }
        public IMongoCollection<Agent> Agents { get { return base._mongoDatabase.GetCollection<Agent>("Agent"); } }
        public IMongoCollection<Chat> Chats { get { return base._mongoDatabase.GetCollection<Chat>("Chat"); } }
        public IMongoCollection<Client> Clients { get { return base._mongoDatabase.GetCollection<Client>("Client"); } }
        public IMongoCollection<EndPoint> EndPoints { get { return base._mongoDatabase.GetCollection<EndPoint>("EndPoint"); } }
        public IMongoCollection<Message> Messages { get { return base._mongoDatabase.GetCollection<Message>("Message"); } }
        public IMongoCollection<User> Users { get { return base._mongoDatabase.GetCollection<User>("User"); } }
    }
}
