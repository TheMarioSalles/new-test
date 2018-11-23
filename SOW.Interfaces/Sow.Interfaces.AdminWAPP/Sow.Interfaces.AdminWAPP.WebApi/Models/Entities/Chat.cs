using Sow.Components.Databases.Models;
using System.Collections.Generic;

namespace Sow.Interfaces.AdminWAPP.WebApi.Models.Entities
{
    public class Chat : MongoDbModelBase
    {
        public string FromPhone { get; set; }
        public string ToPhone { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
