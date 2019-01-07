using System.Collections.Generic;

namespace MarioLucci.Ituran.Domain.Dtos.Entities
{
    public class CurrencyLayerDto
    {
        public string success { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public long timestamp { get; set; }
        public string source { get; set; }
        public QuotesDto quotes { get; set; }
    }
}
