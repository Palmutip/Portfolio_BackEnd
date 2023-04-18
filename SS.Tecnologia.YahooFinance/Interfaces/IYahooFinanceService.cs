using SS.Tecnologia.YahooFinance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.YahooFinance.Inferfaces
{
    public interface IYahooFinanceService
    {
        Task<Ativo> ConsultaAtivoAsync(string identificacaoAtivo);

        Ativo ConsultaAtivo(string identificacaoAtivo);
    }
}
