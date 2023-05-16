using Newtonsoft.Json;

namespace SS.Tecnologia.Exact.Model
{
    public class Lead
    {
        public int id { get; set; }
        public string name { get; set; }
        public string site { get; set; }
        public string phone { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string phone2 { get; set; }
        public bool active { get; set; }
        public List<object> groupList { get; set; }
    }

    public class Meeting
    {
        public string type { get; set; }
        public DateTime registerDate { get; set; }
        public string meetingType { get; set; }
        public DateTime meetingDate { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finalTime { get; set; }
        public object managerDescription { get; set; }
        public string sdrDescription { get; set; }
        public string reference { get; set; }
        public int id { get; set; }
        public Lead lead { get; set; }
        public SalesRep salesRep { get; set; }
        public User user { get; set; }
    }

    public class ExactMeetings
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<Meeting> value { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string OdataNextLink { get; set; }
    }
}
