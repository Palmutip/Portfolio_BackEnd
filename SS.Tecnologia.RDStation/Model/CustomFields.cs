using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.RDStation.Model
{
    public class CustomFields : ContatoRD
    {
        public string cf_vertical_crm { get; set; }
        public long? cf_cep { get; set; }
        public string cf_motivodescarte { get; set; }
        public string cf_cnpj { get; set; }
        public string cf_razao_social { get; set; }
        public string cf_etapaatual { get; set; }
        public string cf_etapadescarte { get; set; }
        public string cf_ext_origem { get; set; }
        public string cf_observacao { get; set; }
    }
}
