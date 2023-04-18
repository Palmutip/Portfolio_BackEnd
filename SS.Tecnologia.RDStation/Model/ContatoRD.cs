using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.RDStation.Model
{
    /// <summary>
    /// Campos padrão para os contatos cadastrados na RD Station
    /// </summary>
    public class ContatoRD
    {
        public ContatoRD()
        {
            email = string.Empty;
            name = string.Empty;
            job_title = string.Empty;
            state = string.Empty;
            city = string.Empty;    
            mobile_phone = string.Empty;
            website = string.Empty;
            personal_phone = string.Empty;
        }

        public string email { get; set; }
        public string name { get; set; }
        public string job_title { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string mobile_phone { get; set; }
        public string website { get; set; }
        public string personal_phone { get; set; }
    }
}
