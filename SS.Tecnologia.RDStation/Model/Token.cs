using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.RDStation.Model
{
    /// <summary>
    /// Classe padrão que representa o token de acesso, o refresh token e o periodo até expirar o acesso
    /// </summary>
    public class Token
    {
        public Token() 
        {
            AccessToken = string.Empty;
            ExpiresIn = string.Empty;
            RefreshToken = string.Empty;
        }
        /// <summary>
        /// Token de acesso a ser utilizado na primeira chamada
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// Periodo em milisegundos até o token expirar
        /// </summary>
        public string ExpiresIn { get; set; }
        /// <summary>
        /// Token para atualizar o acesso e conceder acesso nas proximas chamadas
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
