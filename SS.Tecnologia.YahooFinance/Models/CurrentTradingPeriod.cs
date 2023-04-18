using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.YahooFinance.Models
{
    public class CurrentTradingPeriod
    {
        public TradingPeriod? Pre { get; set; }
        public TradingPeriod? Regular { get; set; }
        public TradingPeriod? Post { get; set; }
    }
}
