using SS.Tecnologia.YahooFinance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoDoAtivo.Application
{
    public interface IVariacaoService
    {
        List<VariacaoViewModel> Get();
        VariacaoViewModel GetById(int dia);
        bool Post(string identificacaoAtivo, Intervalo intervalo, string range = "");
        bool Put(VariacaoViewModel variacaoViewModel);
        bool Delete(string id);
        bool Delete();
    }
}
