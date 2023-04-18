using System;
using System.Collections.Generic;
using System.Text;

namespace VariacaoDoAtivo.Domain
{
    public interface IVariacaoRepository : IRepository<Variacao>
    {
        IEnumerable<Variacao> GetAll();
    }
}
