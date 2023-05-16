using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DataAccessADO
{
    /// <summary>
    /// Classe responsável por executar as operações no Banco de Dados
    /// </summary>
    public class Conexao : IDisposable
    {
        /// <summary>
        /// Responsável por usar o ADO .NET para conexão com o Banco de Dados
        /// </summary>
        private static DbProviderFactory ProviderFactory;

        /// <summary>
        /// String de conexão com o banco de dados
        /// </summary>
        private static string stringCnn;

        /// <summary>
        /// ID do ultimo registro apurado
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// Total de linhas afetadas em instruções Update e Delete
        /// </summary>
        public long NumLinhasAfetadas { get; set; }

        /// <summary>
        /// Nome do Banco de Dados
        /// </summary>
        private string Database { get; set; } = "DevleanTest";

        /// <summary>
        /// Login do usuário no Banco de Dados
        /// </summary>
        private string User { get; set; } = "sa";

        /// <summary>
        /// Senha do usuário no Banco de Dados
        /// </summary>
        private string Senha { get; set; } = "masterkey";

        /// <summary>
        /// Nome do servidor do Banco de Dados
        /// </summary>
        private string Host { get; set; } = "MONSTRO";

        /// <summary>
        /// Caractere que representa os paramêtros no SQL Server
        /// </summary>
        public string CaracterParametro { get; set; } = "@";

        /// <summary>
        /// Construtor da classe responsável por capturar a string de conexão e o provedor de acesso ADO NET
        /// </summary>
        public Conexao()
        {
            stringCnn = string.Concat("Data Source=", Host, "; Initial Catalog=", Database, "; User Id=", User, "; Password=", Senha, ";");
            ProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        }

        /// <summary>
        /// Método para abrir a Conexão e a Transação com o banco de dados
        /// </summary>
        /// <returns>Retorna a transação a ser utilizada</returns>
        public DbTransaction AbreTransacao()
        {
            DbConnection conexao;

            try
            {
                if (!stringCnn.ToString().Equals(""))
                {
                    ProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                    conexao = ProviderFactory.CreateConnection();
                    conexao.ConnectionString = stringCnn;
                    if (conexao.State.Equals(ConnectionState.Closed)) { conexao.Open(); }

                    if (conexao.State == ConnectionState.Open) { return conexao.BeginTransaction(); }                  
                    else { throw new Exception("Houve um problema ao conectar-se ao banco de dados"); }
                }
                else { throw new Exception("String de conexão não localizada"); }

            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Método para finalizar a transaction com comit ou rolback e fecha a conexão com o banco de dados (Destroi Transação/Conexão)
        /// </summary>
        /// <param name="transaction">Transação a ser destruida</param>
        /// <param name="realizaCommit">Flag booleana que valida se transação deve ser comitada ou realizado roolback</param>
        public void FechaTransacao(DbTransaction transaction, bool realizaCommit)
        {
            try
            {
                if (transaction != null)
                {
                    DbConnection connection = transaction.Connection;

                    if (realizaCommit.Equals(true)) { transaction.Commit(); }
                    else { transaction.Rollback(); }

                    if (connection != null)
                    {
                        if (!connection.State.Equals(ConnectionState.Closed)) { connection.Close(); }
                    }

                    transaction.Dispose();
                    connection.Dispose();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Método para executar a instrução no banco de dados
        /// </summary>
        /// <param name="transaction">Transação que será utilizada</param>
        /// <param name="CommandText">Instrução que será executada (SQL)</param>
        /// <param name="Parametros">Filtros que será utilizado (default null)</param>
        public DataTable Executa(DbTransaction transaction, string CommandText, List<DbParameter> Parametros = null, bool tipoSelect = false)
        {
            try
            {
                DbCommand sqlComando;

                sqlComando = transaction.Connection.CreateCommand();

                sqlComando.Parameters.Clear();
                sqlComando.CommandText = CommandText;
                sqlComando.CommandType = CommandType.Text;
                sqlComando.Transaction = transaction; 

                if (null != Parametros)
                    sqlComando.Parameters.AddRange(Parametros.ToArray());

                if (tipoSelect)
                {
                    DataTable dtRetorno = new DataTable();
                    using (DbDataAdapter adapter = ProviderFactory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = sqlComando;
                        adapter.Fill(dtRetorno);
                    }

                    return dtRetorno;
                }
                else 
                {
                    NumLinhasAfetadas = sqlComando.ExecuteNonQuery(); 
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// Rotina resposável por executar consultas
        /// </summary>
        /// <param name="paramSQL"> Consulta SQL</param>
        /// <param name="Parametros">Lista de parâmetros DbParameter</param>
        /// <param name="paramTransaction">Transação Transaction</param>
        /// <returns>Em caso de consulta SELECT retorna um DataTable com os dados encontrados</returns>
        public DataTable RodaSql(string paramSQL, List<DbParameter> Parametros = null, DbTransaction paramTransaction = null)
        {         
            OperacaoSql Acao;
            bool realizarCommit = true; 
            bool cnn_new = false;                   
            string r_SQL = ""; 
            string r_Tabela = string.Empty;

            try
            {
                string a = paramSQL.Substring(0, 7).ToUpper().Trim();

                switch (paramSQL.Substring(0, 7).ToUpper().Trim())
                {
                    case "SELECT":
                        Acao = OperacaoSql.SELECT;
                        break;
                    case "INSERT":
                        Acao = OperacaoSql.INSERT;
                        r_Tabela = paramSQL.Substring(12, paramSQL.IndexOf('(') - 13);
                        break;
                    case "UPDATE":
                        Acao = OperacaoSql.UPDATE;
                        r_Tabela = paramSQL.Substring(8, paramSQL.IndexOf("SET", 0) - 9);
                        break;
                    case "DELETE":
                        Acao = OperacaoSql.DELETE;
                        r_Tabela = paramSQL.Substring(8, paramSQL.IndexOf("WHERE", 0) - 9);
                        break;
                    default:
                        Acao = OperacaoSql.INDEFINIDO;
                        break;
                }

                string prefixo = "USE [" + Database + "] ";
                paramSQL = prefixo + paramSQL;
                r_SQL = prefixo + r_SQL;
                paramSQL = paramSQL.Trim();

                if (paramTransaction == null)
                {
                    paramTransaction = AbreTransacao(); 
                    cnn_new = true;
                }
                else 
                    cnn_new = false;


                if (!Acao.Equals(OperacaoSql.SELECT))
                {
                    if (Acao.Equals(OperacaoSql.INSERT))
                    {
                        prefixo = "USE [" + Database + "] ";
                        r_SQL = prefixo;
                        r_SQL += string.Concat($" SELECT IDENT_CURRENT('{r_Tabela}') + 1 AS ProximoID");

                        var ret = Executa(paramTransaction, r_SQL, null, true);

                        ID = Convert.ToInt64(ret.Rows[0]["ProximoID"]);
                    }
                    else
                    {
                        paramSQL = ReplaceCaracterToParameter(paramSQL);
                    }
                }

                r_SQL = paramSQL;
                DataTable retRodaSql = Executa(paramTransaction, paramSQL, Parametros, Acao.Equals(OperacaoSql.SELECT) ? true : false);

                return retRodaSql;
            }
            catch (Exception ex)
            {
                realizarCommit = false;

                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (cnn_new == true)
                    FechaTransacao(paramTransaction, realizarCommit);
            }
        }

        /// <summary>
        /// Converte o caracter de parametro conforme o banco de dados
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ReplaceCaracterToParameter(string str)
        {
            return str.Replace("@", CaracterParametro);
        }

        /// <summary>
        /// Remove o caracter de parâmetro do campo
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ReplaceCaracterParametro(string str)
        {
            return str.Replace(CaracterParametro, "");
        }

        /// <summary>
        /// Este método ao receber um list de parametros DbParemeter e devolve uma string para ser utilizada de acordo com o parametro do Enum SQL, Insert, Update, Delete, Select
        /// </summary>
        /// <param name="Parametros">Lista com os parametros para consulta</param>
        /// <param name="typeSql">Tipo da operação SQL do tipo Conexao.OpSql(Insert,Select,Update,Delete)</param>
        /// <returns></returns>
        public string CamposParametro(List<DbParameter> Parametros, OperacaoSql typeSql)
        {
            try
            {
                StringBuilder campos = new StringBuilder();

                foreach (DbParameter item in Parametros)
                {
                    switch (typeSql)
                    {
                        case OperacaoSql.INSERT:
                            if (campos.Length > 0) campos.Append(", ");
                            campos.Append(string.Format("{0}", item.ParameterName.Trim().Replace("@", CaracterParametro)));
                            break;

                        case OperacaoSql.UPDATE:
                            if (!item.ParameterName.ToUpper().Equals(CaracterParametro + "ID")) 
                            {
                                if (campos.Length > 0) campos.Append(", ");
                                campos.Append(string.Concat(item.ParameterName.Trim().Replace(CaracterParametro, ""), "=", item.ParameterName.Trim().Replace("@", CaracterParametro)));
                            }
                            break;

                        case OperacaoSql.SELECT:
                            if (campos.Length > 0) campos.Append(" AND ");
                            campos.Append(string.Concat(item.ParameterName.Replace(CaracterParametro, ""), "=", item.ParameterName.Trim().Replace("@", CaracterParametro)));
                            break;

                        default:
                            throw new Exception(string.Concat("Ação ", typeSql.ToString().ToUpper(), " inválida."));
                    } 
                }

                return campos.ToString();

            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message,ex); 
            }
        }

        /// <summary>
        /// Cria os parametros para consulta para DbParameter de acordo com o banco de dados utilizado
        /// </summary>
        /// <param name="nomeParametro">Nome do Parâmetro</param>
        /// <param name="tipoParametro">Tipo de dados (Dbtype.String,DbType.Double....)</param>
        /// <param name="valorParametro">Dado a ser enviado ao banco</param>
        /// <returns></returns>
        public DbParameter CriarParametro(string nomeParametro, DbType tipoParametro, object valorParametro)
        {
            try
            {
                DbParameter Parametro = ProviderFactory.CreateParameter();

                if (Parametro != null)
                {
                    Parametro.ParameterName = nomeParametro;
                    Parametro.DbType = tipoParametro;
                    Parametro.Value = valorParametro;
                }

                return Parametro;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message,ex);
            }
        }

        /// <summary>
        /// Método da interface IDisposable
        /// </summary>
        public void Dispose()
        {

        }
    }

    /// <summary>
    /// Enumerador para operação
    /// </summary>
    public enum OperacaoSql
    {
        SELECT,
        INSERT,
        UPDATE,
        DELETE,
        INDEFINIDO
    }
}
