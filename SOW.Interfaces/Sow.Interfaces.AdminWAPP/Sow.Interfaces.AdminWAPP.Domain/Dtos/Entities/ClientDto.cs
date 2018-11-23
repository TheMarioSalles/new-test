using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sow.Interfaces.AdminWAPP.Domain.Dtos.Entities
{
    public class ClientDto
    {
        [DisplayName("Identificação")]
        public string Id { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("CNPJ / CPF")]
        public string Document { get; set; }
        [DisplayName("Agentes")]
        public string AgentsQuantity { get; set; }
        //[DisplayName("Logotipo")]
        //public string Image { get; set; }
        [DisplayName("Contas")]
        public ICollection<AccountDto> Accounts { get; set; }
        [DisplayName("Status")]
        [DefaultValue(true)]
        public bool Status { get; set; }
    }
}
