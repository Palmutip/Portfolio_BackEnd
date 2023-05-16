using CadastroClientes.Objetos;
using CadastroClientes.Regras;
using Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"].IsNullOrEmpty() || Session["senha"].IsNullOrEmpty())
                Response.Redirect("~/Default.aspx");

            if (!IsPostBack)
            {
                if (null != Request.QueryString["id"])
                {
                    LblID.Text = Request.QueryString["id"].ToString();
                    TxtNome.Text = Request.QueryString["nome"];
                    TxtEmail.Text = Request.QueryString["email"];
                    TxtSenha.Text = Request.QueryString["senha"];
                }
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (LblID.Text != "")
            {
                UsuarioDTO _usuario = new UsuarioDTO()
                {
                    ID = Convert.ToInt32(LblID.Text),
                    Nome = TxtNome.Text,
                    Email = TxtEmail.Text,
                    Senha = TxtSenha.Text
                };
                new UsuarioBLL().Save(_usuario);
            }
            else
            {
                UsuarioDTO _usuario = new UsuarioDTO()
                {
                    Nome = TxtNome.Text,
                    Email = TxtEmail.Text,
                    Senha = TxtSenha.Text
                };
                new UsuarioBLL().Save(_usuario);
            }

            LblID.Text = "";

            Response.Redirect("~/Paginas/Usuarios/ListaUsuarios");
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Usuarios/ListaUsuarios");
        }
    }
}