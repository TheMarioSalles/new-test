using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities
{
    public class EndPointDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
