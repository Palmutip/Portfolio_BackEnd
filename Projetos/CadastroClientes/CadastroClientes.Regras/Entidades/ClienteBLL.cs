using CadastroClientes.Objetos;
using DataAccess;
using DataAccessADO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes.Regras
{
    public class ClienteBLL : DataAccessADO.ICrud<ClienteDTO>, DataAccess.ICrud<ClienteDTO>
    {
        /// <summary>
        /// Faz um INSERT no BD com EntityFramework
        /// </summary>
        /// <param name="entidade">Dados da tabela Clientes</param>
        /// <returns></returns>
        public Retorno Inserir(ClienteDTO entidade)
        {
            return new DataAccess.ClienteDAL().Inserir(entidade);
        }

        /// <summary>
        /// Faz um SELECT * no BD com EntityFramework
        /// </summary>
        /// <returns></returns>
        public List<ClienteDTO> Buscar()
        {
            return new DataAccess.ClienteDAL().Buscar();
        }

        /// <summary>
        /// Faz um SELECT * no BD com EntityFramework
        /// </summary>
        /// <param name="ID">Where ID = ID</param>
        /// <returns></returns>
        public ClienteDTO Buscar(int ID)
        {
            return new DataAccess.ClienteDAL().Buscar(ID);
        }

        /// <summary>
        /// Faz um UPDATE no BD com EntityFramework
        /// </summary>
        /// <param name="entidade">Dados da tabela Clientes</param>
        /// <returns></returns>
        public Retorno Atualizar(ClienteDTO entidade)
        {
            return new DataAccess.ClienteDAL().Atualizar(entidade);
        }

        /// <summary>
        /// Faz um DELETE no BD com EntityFramework
        /// </summary>
        /// <param name="entidade">Dados da tabela Clientes</param>
        /// <returns></returns>
        public Retorno Deletar(ClienteDTO entidade)
        {
            return new DataAccess.ClienteDAL().Deletar(entidade);
        }

        /// <summary>
        /// Faz um DELETE no BD com ADO .NET
        /// </summary>
        /// <param name="Dados">Dados da tabela Clientes</param>
        /// <param name="Transaction">Transação da operação para commit ou rollback</param>
        /// <returns></returns>
        public long Delete(ClienteDTO Dados, DbTransaction Transaction = null)
        {
            return new DataAccessADO.ClienteDAL().Delete(Dados, Transaction);
        }

        /// <summary>
        /// Faz um SELECT * no BD com ADO .NET
        /// </summary>
        /// <param name="Filtro">Filtro para passar no WHERE. Ex: Nome=Pedro</param>
        /// <param name="Transaction">Transação da operação para commit ou rollback</param>
        /// <param name="forUpdate"></param>
        /// <returns></returns>
        public List<ClienteDTO> Get(Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> Filtro = null, DbTransaction Transaction = null)
        {
            return new DataAccessADO.ClienteDAL().Get(Filtro, Transaction);
        }

        /// <summary>
        /// Faz um INSERT ou UPDATE no BD com ADO .NET. Se passar ID faz UPDATE, se não é INSERT.
        /// </summary>
        /// <param name="Dados">Dados da tabela Clientes</param>
        /// <param name="Transaction">Transação da operação para commit ou rollback</param>
        /// <returns></returns>
        public string Save(ClienteDTO Dados, DbTransaction Transaction = null)
        {
            return new DataAccessADO.ClienteDAL().Save(Dados, Transaction);
        }
    }
}
