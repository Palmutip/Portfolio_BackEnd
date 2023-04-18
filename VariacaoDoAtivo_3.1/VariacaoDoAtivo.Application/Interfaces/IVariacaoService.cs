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
        bool Post(string identificacaoAtivo);
        bool Put(VariacaoViewModel variacaoViewModel);
        bool Delete(string id);
    }
}
