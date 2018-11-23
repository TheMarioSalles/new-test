using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities
{
    public class UserDto
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
    }
}
