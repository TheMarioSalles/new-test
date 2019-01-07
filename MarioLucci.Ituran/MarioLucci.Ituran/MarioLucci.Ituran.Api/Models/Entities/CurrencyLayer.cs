namespace MarioLucci.Ituran.Api.Models.Entities
{
    public class CurrencyLayer
    {
        public string success { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public long timestamp { get; set; }
        public string source { get; set; }
        public Quotes quotes { get; set; }
    }
}
