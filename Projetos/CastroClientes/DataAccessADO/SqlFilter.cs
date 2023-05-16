using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessADO
{
    public class SqlFilter
    {

        private Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> fSql;

        /// <summary>
        /// Constrututor para inicializar o filtro
        /// </summary>
        public SqlFilter()
        {
            fSql = new Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Monta o filtro de acordo com o tipo enviado (Converte Type em DbType)
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static DbType GetDbType(Type type)
        {
            if (type == typeof(long)) 
                return DbType.Int64; 
            else if (type == typeof(int)) 
                return DbType.Int32; 
            else if (type == typeof(string)) 
                return DbType.String;
            else if (type == typeof(double)) 
                return DbType.Double;
            else if (type == typeof(char)) 
                return DbType.Single;
            else if (type == typeof(DateTime)) 
                return DbType.DateTime;
            else if (type == typeof(DateTime)) 
                return DbType.Date;
            else 
                return DbType.Object;
        } 

        /// <summary>
        /// Monta Lista de Parametros a partir de um filtro
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public static List<DbParameter> GetParameters(Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> filtro)
        {
            using (Conexao cn = new Conexao())
            {
                List<DbParameter> Parametros = new List<DbParameter>();
                if (filtro != null)
                {
                    foreach (KeyValuePair<Tuple<string, string, Type>, KeyValuePair<string, string>> item in filtro)
                    {
                        Parametros.Add(cn.CriarParametro(string.Concat("@", item.Key.Item2.ToUpper()), GetDbType(item.Key.Item3), item.Value.Value));
                    }
                }
                return Parametros;
            }
        }

        /// <summary>
        /// Monta campos sql a partir de uma lista de DbParameter
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public static string GetSqlFilter(Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> filtro)
        {
            using (Conexao cn = new Conexao())
            {
                List<DbParameter> Parametros = new List<DbParameter>();
                StringBuilder campos = new StringBuilder();
                if (filtro != null)
                {
                    foreach (KeyValuePair<Tuple<string, string, Type>, KeyValuePair<string, string>> item in filtro)
                    {
                        campos.Append(string.Concat(item.Key.Item1, item.Key.Item2, item.Value.Key, string.Concat(cn.CaracterParametro, item.Key.Item2)));
                    }
                }
                return campos.ToString();
            }
        }
    }

    public static class Filtro
    {
        public static Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> ParamFiltroBusca(string Filtro)
        {
            try
            {
                Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> dadosRetorno = new Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>>();

                if (Filtro != "")
                {
                    string[] camposFiltro = Filtro.Split(';'); 
                    string relacional = ""; 
                    string operador = ""; 
                    string campo = ""; 
                    string informacao = "";                 

                    foreach (string item in camposFiltro)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            relacional = (relacional == "" ? " WHERE " : " AND ");
 
                            if (item.ToLower().Contains("in(") || item.ToLower().Contains("in (")) { operador = "in"; }
                            else if (item.Contains(">=")) { operador = ">="; }
                            else if (item.Contains("<=")) { operador = "<="; }
                            else if (item.Contains("<>")) { operador = "<>"; }
                            else if (item.Contains(">")) { operador = ">"; }
                            else if (item.Contains("<")) { operador = "<"; }
                            else { operador = "="; }

                            int pOperador = item.IndexOf(operador); 
                            campo = item.Substring(0, pOperador).Trim();
                            informacao = item.Substring(pOperador + operador.Length).Trim();

                            if (!campo.Equals("") && !informacao.Equals(""))
                            {
                                if (operador.Trim().ToUpper().Equals("IN")) { dadosRetorno.Add(new Tuple<string, string, Type>(relacional, campo, DbType.Object.GetType()), new KeyValuePair<string, string>(string.Concat(" ", operador, " "), informacao)); }
                                else { dadosRetorno.Add(new Tuple<string, string, Type>(relacional, campo, campo.GetType()), new KeyValuePair<string, string>(operador, informacao)); }
                            }
                        }
                    } 
                } 

                return dadosRetorno;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
