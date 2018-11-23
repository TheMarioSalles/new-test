using Sow.Components.Databases.Models;
using System.Collections.Generic;

namespace Sow.Interfaces.AdminWAPP.WebApi.Models.Entities
{
    public class Client : MongoDbModelBase
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string AgentsQuantity { get; set; }
        //public string Image { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
