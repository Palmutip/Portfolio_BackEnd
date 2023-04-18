using System;
using System.Collections.Generic;
using System.Text;

namespace VariacaoDoAtivo.Application
{
    public class VariacaoViewModel
    {
        public Guid Id { get; set; }
        public int Dia { get; set; }
        public string Data { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;
        public string VaricaoRelacaoD1 { get; set; } = string.Empty;
        public string VariacaoRelacaoPrimeiraData { get; set; } = string.Empty;
    }
}
