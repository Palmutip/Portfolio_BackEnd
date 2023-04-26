using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.Commom
{
    public static class ExtensoesSS
    {

        /// <summary>
        /// Método para validar o Email
        /// </summary>
        /// <param name="email">string referente ao email</param>
        /// <returns></returns>
        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Método de extensão de string para validar se ela é vazia ou nula
        /// </summary>
        /// <param name="dado"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string dado)
        {
            if (null == dado || string.Empty == dado || "" == dado)
                return true;

            return false;
        }

        /// <summary>
        /// Método para converter uma informação em Long
        /// </summary>
        /// <typeparam name="value">Dado que será convertido</typeparam>
        /// <returns>Retorna o valor convertido em long</returns>                
        public static long ToLong(this object value)
        {
            if (value != null) { return Convert.ToInt64(value); }
            else { return default(long); }
        }

        /// <summary>
        /// Método para converter uma informação em double
        /// </summary>
        /// <typeparam name="value">Dado que será convertido</typeparam>
        /// <returns>Retorna o valor convertido em double</returns>  
        public static Double ToDouble(this object value)
        {
            if (value != null) { return Convert.ToDouble(value); }
            else { return default(Double); }
        }

        /// <summary>
        /// Método para converter uma informação em DateTime
        /// </summary>
        /// <typeparam name="value">Dado que será convertido</typeparam>
        /// <returns>Retorna o valor convertido em DateTime</returns>  
        public static DateTime ToDateTime(this object value)
        {
            if (value != null) { return Convert.ToDateTime(value); }
            else { return default(DateTime); }
        }

        /// <summary>
        ///  Método para apurar se objeto está nulo
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Retorna true ou false</returns>
        public static bool IsNullObject(this object value)
        {
            return value == null ? true : false;
        }
    }
}
