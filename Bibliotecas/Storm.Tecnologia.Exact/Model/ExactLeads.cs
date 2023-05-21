using Newtonsoft.Json;

namespace SS.Tecnologia.Exact.Model
{
    public class Source
    {
        public int? id { get; set; }
        public string value { get; set; }
    }

    public class Industry
    {
        public int? id { get; set; }
        public string value { get; set; }
    }

    public class SubSource
    {
        public int? id { get; set; }
        public string value { get; set; }
    }

    public class Sdr
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string phone2 { get; set; }
        public bool active { get; set; }
        public List<object> groupList { get; set; }
    }

    public class SalesRep
    {
        public object id { get; set; }
        public object name { get; set; }
        public object lastName { get; set; }
        public object email { get; set; }
        public object phone { get; set; }
        public object phone2 { get; set; }
        public bool active { get; set; }
        public List<object> groupList { get; set; }
    }

    public class Value
    {
        public string lead { get; set; }
        public DateTime registerDate { get; set; }
        public DateTime updateDate { get; set; }
        public string mktLink { get; set; }
        public string publicLink { get; set; }
        public object phone1 { get; set; }
        public object phone2 { get; set; }
        public string website { get; set; }
        public string leadProduct { get; set; }
        public object description { get; set; }
        public string stage { get; set; }
        public string cnpj { get; set; }
        public string street { get; set; }
        public string cep { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string district { get; set; }
        public object city { get; set; }
        public object state { get; set; }
        public object country { get; set; }
        public object integrationId { get; set; }
        public int? id { get; set; }
        public Source source { get; set; }
        public Industry industry { get; set; }
        public SubSource subSource { get; set; }
        public Sdr sdr { get; set; }
        public SalesRep salesRep { get; set; }
    }


    public class ExactLeads
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<Value> value { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string OdataNextLink { get; set; }
    }

    public class CustomField
    {
        public string id { get; set; }
        public object value { get; set; }
        public int leadId { get; set; }
        public List<string> options { get; set; }
    }

    public class ExactCustomFields
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<CustomField> value { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string OdataNextLink { get; set; }
    }

    public class Person
    {
        public string email { get; set; }
        public string name { get; set; }
        public int leadId { get; set; }
        public string jobTitle { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string messagingPlatform { get; set; }
        public object idMessagingPlatform { get; set; }
        public bool mainContact { get; set; }
        public int id { get; set; }
    }

    public class ExactPersons
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<Person> value { get; set; }

        [JsonProperty("@odata.nextLink")]
        public string OdataNextLink { get; set; }
    }
}
