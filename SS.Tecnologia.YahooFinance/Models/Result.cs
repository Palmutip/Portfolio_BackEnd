using System.Collections.Generic;

namespace SS.Tecnologia.YahooFinance.Models
{
    public class Result
    {
        public Meta? Meta { get; set; }
        public List<int>? Timestamp { get; set; }
        public Indicators? Indicators { get; set; }
    }
}
