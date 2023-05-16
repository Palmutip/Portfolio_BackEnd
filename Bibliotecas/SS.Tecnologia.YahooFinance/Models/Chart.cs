using System.Collections.Generic;

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
