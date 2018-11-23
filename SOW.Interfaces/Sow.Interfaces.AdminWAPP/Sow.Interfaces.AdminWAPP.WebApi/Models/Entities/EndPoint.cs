using Sow.Components.Databases.Models;
using System.Collections.Generic;

namespace Sow.Interfaces.AdminWAPP.WebApi.Models.Entities
{
    public class EndPoint : MongoDbModelBase
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}
