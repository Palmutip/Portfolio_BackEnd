using System.Collections.Generic;

namespace VariacaoDoAtivo.Domain
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> GetAll();
    }
}
