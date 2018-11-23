using Sow.Components.Databases.Models;
using System.Collections.Generic;

namespace Sow.Interfaces.AdminWAPP.WebApi.Models.Entities
{
    public class Agent : MongoDbModelBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public ICollection<EndPoint> EndPoints { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }
}
