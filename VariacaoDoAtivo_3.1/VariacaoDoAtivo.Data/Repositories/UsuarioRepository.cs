using System;
using System.Collections.Generic;
using System.Text;
using VariacaoDoAtivo.Domain;

namespace VariacaoDoAtivo.Data
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(VariacaoDbContext context) : base(context)
        {

        }

        public IEnumerable<Usuario> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
