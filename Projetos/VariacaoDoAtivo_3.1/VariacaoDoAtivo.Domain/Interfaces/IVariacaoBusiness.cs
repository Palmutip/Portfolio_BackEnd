using SS.Tecnologia.YahooFinance.Models;
using System.Collections.Generic;

namespace VariacaoDoAtivo.Domain
{
    public interface IVariacaoBusiness
    {
        List<Variacao> RetornaVariacoes(Ativo dadosYahooo);
    }
}
