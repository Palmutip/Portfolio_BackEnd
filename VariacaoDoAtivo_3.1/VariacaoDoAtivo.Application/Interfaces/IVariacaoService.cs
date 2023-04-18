using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VariacaoDoAtivo.Application
{
    public interface IVariacaoService
    {
        List<VariacaoViewModel> Get();
        bool Post(string identificacaoAtivo);
    }
}
