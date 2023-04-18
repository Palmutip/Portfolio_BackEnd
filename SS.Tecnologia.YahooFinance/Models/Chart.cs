using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.YahooFinance.Models
{
    public class Chart
    {
        public Chart()
        {
            Error = string.Empty;
        }

        public List<Result>? Result { get; set; }
        public string Error { get; set; }
    }
}
