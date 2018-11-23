using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities
{
    public class MessageDto
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }
    }
}
