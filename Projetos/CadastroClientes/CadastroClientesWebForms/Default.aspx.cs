using CadastroClientes.Objetos;
using CadastroClientes.Regras;
using Comuns;
//using Comuns;
using DataAccessADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogar_Click(object sender, EventArgs e)
        {
            Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> dadosFiltro = new Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>>();
            string dadosEnvio = "Email=" + TxtEmail.Text + ";Senha=" + Criptografia.Cript(TxtSenha.Text);

            if (!dadosEnvio.Equals(""))
            {
                dadosFiltro = Filtro.ParamFiltroBusca(dadosEnvio);
            }

            var _usuario = new UsuarioBLL().Get(dadosFiltro).FirstOrDefault();

            if (null == _usuario)
                Session["mensagem"] = "Usuario/Senha inválido!";
            else
            {
                if (!Session["mensagem"].IsNullOrEmpty())
                    Session["mensagem"] = "";
                Session["email"] = TxtEmail.Text;
                Session["senha"] = TxtSenha.Text;
                Response.Redirect("~/Paginas/Clientes/ListaClientes.aspx");
            }
        }
    }
}