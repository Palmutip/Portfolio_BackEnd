using System;
using System.Collections.Generic;
using System.Text;

namespace VariacaoDoAtivo.Domain
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> GetAll();
    }
}
