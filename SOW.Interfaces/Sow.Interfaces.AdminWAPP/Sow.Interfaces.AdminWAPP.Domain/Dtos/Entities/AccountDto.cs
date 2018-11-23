using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities
{
    public class AccountDto
    {
        [DisplayName("Identificação")]
        public Guid Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("CNPJ & CPF")]
        public string Document { get; set; }
        [DisplayName("Agentes")]
        public ICollection<AgentDto> Agents { get; set; }
        [DisplayName("EndPoints")]
        public ICollection<EndPointDto> EndPoints { get; set; }
        [DisplayName("Status")]
        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
