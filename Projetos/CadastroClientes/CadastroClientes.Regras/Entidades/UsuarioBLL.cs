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
    public class UsuarioBLL : DataAccessADO.ICrud<UsuarioDTO>, DataAccess.ICrud<UsuarioDTO>
    {
        /// <summary>
        /// Faz um INSERT no BD com EntityFramework
        /// </summary>
        /// <param name="usuario">Dados da tabela Usuarios</param>
        /// <returns></returns>
        public Retorno Inserir(UsuarioDTO usuario)
        {
            return new DataAccess.UsuarioDAL().Inserir(usuario);
        }

        /// <summary>
        /// Faz um SELECT * no BD com EntityFramework
        /// </summary>
        /// <returns></returns>
        public List<UsuarioDTO> Buscar()
        {
            return new DataAccess.UsuarioDAL().Buscar();
        }

        /// <summary>
        /// Faz um SELECT * no BD com EntityFramework
        /// </summary>
        /// <param name="ID">Where ID = ID</param>
        /// <returns></returns>
        public UsuarioDTO Buscar(int ID)
        {
            return new DataAccess.UsuarioDAL().Buscar(ID);
        }

        /// <summary>
        /// Faz um SELECT * no BD com EntityFramework
        /// </summary>
        /// <param name="usuario">Dados da tabela Usuarios</param>
        /// <returns></returns>
        public bool Buscar(UsuarioDTO usuario)
        {
            return new DataAccess.UsuarioDAL().Buscar(usuario);
        }

        /// <summary>
        /// Faz um UPDATE no BD com EntityFramework
        /// </summary>
        /// <param name="usuario">Dados da tabela Usuarios</param>
        /// <returns></returns>
        public Retorno Atualizar(UsuarioDTO usuario)
        {
            return new DataAccess.UsuarioDAL().Atualizar(usuario);
        }

        /// <summary>
        /// Faz um DELETE no BD com EntityFramework
        /// </summary>
        /// <param name="usuario">Dados da tabela Usuarios</param>
        /// <returns></returns>
        public Retorno Deletar(UsuarioDTO usuario)
        {
            return new DataAccess.UsuarioDAL().Deletar(usuario);
        }

        /// <summary>
        /// Faz um DELETE no BD com ADO .NET
        /// </summary>
        /// <param name="Dados">Dados da tabela Usuarios</param>
        /// <param name="Transaction">Transação da operação para commit ou rollback</param>
        /// <returns></returns>
        public long Delete(UsuarioDTO Dados, DbTransaction Transaction = null)
        {
            return new DataAccessADO.UsuarioDAL().Delete(Dados, Transaction);
        }

        /// <summary>
        /// Faz um SELECT * no BD com ADO .NET
        /// </summary>
        /// <param name="Filtro">Filtro para passar no WHERE. Ex: Nome=Pedro</param>
        /// <param name="Transaction">Transação da operação para commit ou rollback</param>
        /// <returns></returns>
        public List<UsuarioDTO> Get(Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> Filtro = null, DbTransaction Transaction = null)
        {
            return new DataAccessADO.UsuarioDAL().Get(Filtro, Transaction);
        }

        /// <summary>
        /// Faz um INSERT ou UPDATE no BD com ADO .NET. Se passar ID faz UPDATE, se não é INSERT.
        /// </summary>
        /// <param name="Dados">Dados da tabela Usuarios</param>
        /// <param name="Transaction">Transação da operação para commit ou rollback</param>
        /// <returns></returns>
        public string Save(UsuarioDTO Dados, DbTransaction Transaction = null)
        {
            return new DataAccessADO.UsuarioDAL().Save(Dados, Transaction);
        }
    }
}
