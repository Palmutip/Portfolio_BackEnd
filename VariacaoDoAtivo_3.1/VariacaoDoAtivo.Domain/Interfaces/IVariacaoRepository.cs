using System.Collections.Generic;

namespace VariacaoDoAtivo.Domain
{
    public interface IVariacaoRepository : IRepository<Variacao>
    {
        IEnumerable<Variacao> GetAll();
        void DeleteAll();
    }
}
