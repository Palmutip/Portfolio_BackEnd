using SS.Tecnologia.YahooFinance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VariacaoDoAtivo.Application
{
    public class VariacaoRequestViewModel
    {
        public VariacaoRequestViewModel()
        {
            IdentificacaoAtivo = string.Empty;
            Intervalo = Intervalo.m1;
            Range = string.Empty;
        }

        [Required]
        public string IdentificacaoAtivo { get; set; }
        public Intervalo Intervalo { get; set; }
        public string Range { get; set; }
    }
}
