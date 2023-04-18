using SS.Tecnologia.YahooFinance.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VariacaoDoAtivo.Domain
{
    public interface IVariacaoBusiness
    {
        List<Variacao> RetornaVariacoes(Ativo dadosYahooo);
    }
}
