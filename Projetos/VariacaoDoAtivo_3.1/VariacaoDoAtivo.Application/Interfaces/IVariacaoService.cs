using SS.Tecnologia.YahooFinance;
using System.Collections.Generic;

namespace VariacaoDoAtivo.Application
{
    public interface IVariacaoService
    {
        List<VariacaoViewModel> Get();
        VariacaoViewModel GetById(int dia);
        bool Post(VariacaoRequestViewModel variacaoRequestViewModel);
        bool Put(VariacaoViewModel variacaoViewModel);
        bool Delete(string id);
        bool Delete();
    }
}
