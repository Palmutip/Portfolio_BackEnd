namespace SS.Tecnologia.Exact.Model
{
    public class ExactPerguntaFiltro
    {
        public string Pergunta { get; set; }
        public List<ExactRespostaFiltro> Respostas { get; set; }

        public ExactPerguntaFiltro() { }
    }
}
