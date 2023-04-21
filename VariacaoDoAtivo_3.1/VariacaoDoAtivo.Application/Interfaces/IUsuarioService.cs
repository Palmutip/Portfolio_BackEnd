using System;
using System.Collections.Generic;
using System.Text;
using VariacaoDoAtivo.Domain;

namespace VariacaoDoAtivo.Application
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> Get();
        UsuarioViewModel GetById(string id);
        bool Post(UsuarioViewModel usuarioViewModel);
        bool Put(UsuarioViewModel usuarioViewModel);
        bool Delete(string id);
        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user);
    }
}
