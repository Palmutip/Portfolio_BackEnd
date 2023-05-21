using CadastroClientes.Objetos;
using Comuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class DetalhesUsuario : System.Web.UI.Page
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
                    LblValorNome.Text = Request.QueryString["nome"];
                    LblValorEmail.Text = Request.QueryString["email"];
                    LblValorSenha.Text = Request.QueryString["senha"];
                }
            }
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Usuarios/ListaUsuarios");
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            var _usuario = new UsuarioDTO()
            {
                ID = Convert.ToInt32(LblID.Text),
                Nome = LblValorNome.Text,
                Email = LblValorEmail.Text,
                Senha = LblValorSenha.Text
            };
            Response.Redirect(new ListaUsuarios().MontaURL("FormularioUsuario.aspx", _usuario));
        }
    }
}