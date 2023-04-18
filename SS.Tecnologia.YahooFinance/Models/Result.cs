using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.YahooFinance.Models
{
    public class Result
    {
        public Meta? Meta { get; set; }
        public List<int>? Timestamp { get; set; }
        public Indicators? Indicators { get; set; }
    }
}
