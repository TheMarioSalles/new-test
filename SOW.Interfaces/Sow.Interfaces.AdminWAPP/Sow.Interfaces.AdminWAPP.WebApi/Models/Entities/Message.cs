using Sow.Components.Databases.Models;
using System;
using System.Collections.Generic;

namespace Sow.Interfaces.AdminWAPP.WebApi.Models.Entities
{
    public class Message : MongoDbModelBase
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
