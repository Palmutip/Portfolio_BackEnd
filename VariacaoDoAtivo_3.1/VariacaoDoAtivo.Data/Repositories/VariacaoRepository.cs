using System.Collections.Generic;
using System.Linq;
using VariacaoDoAtivo.Domain;

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

        public void DeleteAll()
        {
            var allEntities = DbSet.ToList();
            DbSet.RemoveRange(allEntities);
            Save();
        }
    }
}
