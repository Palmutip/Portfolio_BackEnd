using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.YahooFinance.Models
{
    public class Quote
    {
        public List<double?>? Open { get; set; }
        public List<double?>? Low { get; set; }
        public List<double?>? High { get; set; }
        public List<int?>? Volume { get; set; }
        public List<double?>? Close { get; set; }
    }
}
