using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities
{
    public class ChatDto
    {
        public string Id { get; set; }
        public string FromPhone { get; set; }
        public string ToPhone { get; set; }
        public ICollection<MessageDto> Messages { get; set; }
        public bool Status { get; set; }
    }
}
