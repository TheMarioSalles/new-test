using Sow.Components.Databases.Models;
using System;
namespace MarioLucci.Ituran.Api.Models.Entities
{
    public class Currency : MongoDbModelBase
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Value { get; set; }
    }
}
