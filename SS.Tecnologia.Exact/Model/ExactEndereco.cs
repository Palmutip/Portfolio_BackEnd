namespace SS.Tecnologia.Exact.Model
{
    public class ExactEndereco
    {

        public string Endereco_Maps { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string CepZipcode { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public ExactEndereco(string Endereco_Maps, string Logradouro, string Complemento,
            string CepZipcode, string Cidade, string Estado, string Pais)
        {
            this.Endereco_Maps = Endereco_Maps;
            this.Logradouro = Logradouro;
            this.Complemento = Complemento;
            this.CepZipcode = CepZipcode;
            this.Cidade = Cidade;
            this.Estado = Estado;
            this.Pais = Pais;
        }
        public ExactEndereco() { }

    }
}
