namespace SS.Tecnologia.YahooFinance.Models
{
    public class TradingPeriod
    {
        public TradingPeriod()
        {
            Timezone = string.Empty;
        }

        public string Timezone { get; set; }
        public int End { get; set; }
        public int Start { get; set; }
        public int GmtOffset { get; set; }
    }
}
