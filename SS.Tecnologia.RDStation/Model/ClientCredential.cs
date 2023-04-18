using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Tecnologia.RDStation.Model
{
    /// <summary>
    /// Objeto referente aos dados obrigatórios para acesso à API da RD Station
    /// </summary>
    public class ClientCredential
    {
        public ClientCredential()
        {
            ClientId = string.Empty;
            ClientSecret= string.Empty;
            RefreshToken= string.Empty;
        }

        /// <summary>
        /// ID do cliente
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Segredo do cliente
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Refresh token fornecido no painel da RD Station
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
