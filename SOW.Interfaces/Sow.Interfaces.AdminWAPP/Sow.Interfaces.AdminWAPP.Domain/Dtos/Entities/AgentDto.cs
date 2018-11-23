using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities
{
    public class AgentDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public ICollection<EndPointDto> EndPoints { get; set; }
        public ICollection<ChatDto> Chats { get; set; }
        public bool Status { get; set; }
    }
}
