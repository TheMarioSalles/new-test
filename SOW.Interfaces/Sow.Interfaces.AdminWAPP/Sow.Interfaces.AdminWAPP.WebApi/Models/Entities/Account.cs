using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Sow.Components.Databases.Models;
using System;
using System.Collections.Generic;

namespace Sow.Interfaces.AdminWAPP.WebApi.Models.Entities
{
    public class Account //: MongoDbModelBase
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public ICollection<Agent> Agents { get; set; }
        public ICollection<EndPoint> EndPoints { get; set; }
        public bool Status { get; set; }
    }
}
