using CadastroClientes.Objetos;
using CadastroClientes.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCadastrar_Click(object sender, EventArgs e)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO()
            {
                Nome = TxtNome.Text,
                Email = TxtEmail.Text,
                Senha = TxtSenha.Text
            };

            new UsuarioBLL().Save(usuarioDTO);

            Session["email"] = usuarioDTO.Email;
            Session["senha"] = usuarioDTO.Senha;

            Response.Redirect("~/Paginas/Clientes/ListaClientes");
        }
    }
}