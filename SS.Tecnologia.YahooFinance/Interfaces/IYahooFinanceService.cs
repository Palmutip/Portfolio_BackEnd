using SS.Tecnologia.YahooFinance.Models;
using System.Threading.Tasks;

namespace SS.Tecnologia.YahooFinance.Inferfaces
{
    public interface IYahooFinanceService
    {
        Task<Ativo> ConsultaAtivoAsync(string identificacaoAtivo, Intervalo intervalo, string range = "");

        Ativo ConsultaAtivo(string identificacaoAtivo, Intervalo intervalo, string range = "");
    }
}
