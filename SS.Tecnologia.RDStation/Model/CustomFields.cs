using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.RDStation.Model
{
    /// <summary>
    /// Campos customizados conforme a necessidade do cliente. Herda as propriedades dos campos padrões.
    /// </summary>
    public class CustomFields : ContatoRD
    {
        public CustomFields() 
        {
            cf_vertical_crm = string.Empty;
            cf_cep = null;
            cf_motivodescarte = string.Empty;
            cf_cnpj = string.Empty;
            cf_etapaatual = string.Empty;
            cf_etapadescarte = string.Empty;
            cf_ext_origem = string.Empty;
            cf_observacao = string.Empty;   
            cf_razao_social = string.Empty;
        }
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
