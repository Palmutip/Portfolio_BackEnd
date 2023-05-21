using CadastroClientes.Objetos;
using Comuns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessADO
{
    /// <summary>
    /// Realiza as operações, no Banco de Dados, na tabela Usuarios, com ADO NET (System.Data.SqlClient)
    /// </summary>
    public class UsuarioDAL : ICrud<UsuarioDTO>
    {
        public long Delete(UsuarioDTO Dados, DbTransaction Transaction = null)
        {
            using (Conexao cn = new Conexao())
            {
                try
                {
                    List<DbParameter> Parametros = new List<DbParameter>
                    {
                        cn.CriarParametro("@ID", DbType.Int64, Dados.ID)
                    };

                    StringBuilder sql = new StringBuilder();
                    sql.Append(string.Concat("DELETE FROM Usuarios WHERE ID = @ID"));

                    cn.RodaSql(sql.ToString(), Parametros, Transaction);

                    return cn.NumLinhasAfetadas;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public List<UsuarioDTO> Get(Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> Filtro = null, DbTransaction Transaction = null)
        {
            using (var cn = new Conexao())
            {
                List<UsuarioDTO> listaDados = new List<UsuarioDTO>();

                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(string.Concat("SELECT *"));
                    sql.Append(string.Concat(" FROM Usuarios"));
                    sql.Append(SqlFilter.GetSqlFilter(Filtro));

                    DataTable dt = cn.RodaSql(sql.ToString(), SqlFilter.GetParameters(Filtro), Transaction);

                    foreach (DataRow dr in dt.Rows)
                    {
                        UsuarioDTO dados = new UsuarioDTO
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Nome = dr["Nome"].ToString(),
                            Email = dr["Email"].ToString(),
                            Senha = Criptografia.Cript(dr["Senha"].ToString())
                        };

                        listaDados.Add(dados);
                    }

                    return listaDados;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public string Save(UsuarioDTO Dados, DbTransaction Transaction = null)
        {
            using (Conexao cn = new Conexao())
            {
                StringBuilder sql = new StringBuilder();

                try
                {
                    List<DbParameter> Parametros = new List<DbParameter>
                    {
                        cn.CriarParametro("@Nome", DbType.String, Dados.Nome),
                        cn.CriarParametro("@Email", DbType.String, Dados.Email),
                        cn.CriarParametro("@Senha", DbType.String, Criptografia.Cript(Dados.Senha))
                    };

                    sql = new StringBuilder();
                    if (Convert.ToInt64(Dados.ID).Equals(0))
                    {
                        sql.Append(string.Concat("INSERT INTO Usuarios"));
                        sql.Append(string.Concat(" (", cn.ReplaceCaracterParametro(cn.CamposParametro(Parametros, OperacaoSql.INSERT)), ")"));
                        sql.Append(string.Concat(" VALUES (", cn.CamposParametro(Parametros, OperacaoSql.INSERT), ")"));
                    }
                    else
                    {
                        sql.Append(string.Concat("UPDATE Usuarios"));
                        sql.Append(string.Concat(" SET ", cn.CamposParametro(Parametros, OperacaoSql.UPDATE)));
                        sql.Append(string.Concat($" WHERE ID = {Dados.ID}"));
                    }

                    cn.RodaSql(sql.ToString(), Parametros, Transaction);

                    if (Convert.ToInt64(Dados.ID).Equals(0)) { return string.Concat("ID=", cn.ID); }
                    else { return cn.NumLinhasAfetadas.ToString(); }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }
    }
}
