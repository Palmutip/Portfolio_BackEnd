using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessADO
{
    public interface ICrud<T>
    {
        string Save(T Dados, DbTransaction Transaction = null);

        long Delete(T Dados, DbTransaction Transaction = null);

        List<T> Get(Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> Filtro = null, DbTransaction Transaction = null);
    }
}
