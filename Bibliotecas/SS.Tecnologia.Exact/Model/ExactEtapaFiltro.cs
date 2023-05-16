namespace SS.Tecnologia.Exact.Model
{
    public class ExactEtapaFiltro
    {
        public string Etapa { get; set; }
        public string Qualificacao { get; set; }
        public DateTime DtAvaliacao { get; set; }
        public List<ExactPerguntaFiltro> PerguntasRespostas { get; set; }

        public ExactEtapaFiltro() { }
    }
}
