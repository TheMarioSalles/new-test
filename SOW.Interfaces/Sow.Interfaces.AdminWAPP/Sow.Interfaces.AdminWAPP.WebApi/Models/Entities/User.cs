using Sow.Components.Databases.Models;
using System;
namespace Sow.Interfaces.AdminWAPP.WebApi.Models.Entities
{
    public class User : MongoDbModelBase
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string ClientId { get; set; }
    }
}
