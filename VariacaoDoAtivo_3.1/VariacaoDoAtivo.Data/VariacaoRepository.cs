using VariacaoDoAtivo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace VariacaoDoAtivo.Data
{
    public class VariacaoRepository : Repository<Variacao>, IVariacaoRepository
    {
        public VariacaoRepository(VariacaoDbContext context) : base(context)
        {

        }

        public IEnumerable<Variacao> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
