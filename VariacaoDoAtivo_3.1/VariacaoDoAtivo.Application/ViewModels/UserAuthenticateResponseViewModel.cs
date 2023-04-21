using System;
using System.Collections.Generic;
using System.Text;

namespace VariacaoDoAtivo.Application
{
    public class UserAuthenticateResponseViewModel
    {
        public UserAuthenticateResponseViewModel(UsuarioViewModel usuario, string token)
        {
            this.Usuario = usuario;
            this.Token = token;
        }

        public UsuarioViewModel Usuario { get; set; }
        public string Token { get; set; }
    }
}
