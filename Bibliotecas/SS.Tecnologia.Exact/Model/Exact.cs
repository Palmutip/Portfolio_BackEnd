namespace SS.Tecnologia.Exact.Model
{
    public class Exact
    {
        public Exact()
        {
            Contatos = new List<ExactContato>();
            CamposPersonalizados = new List<ExactCustom>();
        }

        public int? Id { get; set; }
        public string Empresa { get; set; }
        public List<ExactContato> Contatos { get; set; }
        public ExactMercado Mercado { get; set; }
        public ExactOrigem Origem { get; set; }
        public ExactSubOrigem SubOrigem { get; set; }
        public ExactPreVendedor PreVendedor { get; set; }
        public string Grupo { get; set; }
        public string LinkMkt { get; set; }
        public string TelEmpresa { get; set; }
        public string Site { get; set; }
        public string ProdutoLead { get; set; }
        public ExactEndereco Endereco { get; set; }
        public string Obs { get; set; }
        public List<ExactCustom> CamposPersonalizados { get; set; }
        public string Etapa { get; set; }
        public List<ExactEtapaFiltro> Etapas { get; set; }
        public DateTime DtCadastro { get; set; }
        public string LinkPublico { get; set; }
        public string LinkFeedBack { get; set; }
    }
}
