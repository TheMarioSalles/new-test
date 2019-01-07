using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarioLucci.Ituran.Domain.Dtos.Entities
{
    public class CurrencyDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Value { get; set; }
    }
}
