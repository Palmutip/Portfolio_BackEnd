using System.Collections.Generic;

namespace SS.Tecnologia.YahooFinance.Models
{
    public class Quote
    {
        public List<double?>? Open { get; set; }
        public List<double?>? Low { get; set; }
        public List<double?>? High { get; set; }
        public List<long?>? Volume { get; set; }
        public List<double?>? Close { get; set; }
    }
}
