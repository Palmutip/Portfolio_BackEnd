using CadastroClientes.Objetos;
using Comuns;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class DetalhesCliente : System.Web.UI.Page
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
                    LblValorTipo.Text = Request.QueryString["tipo"];
                    LblValorDataNascimento.Text = Convert.ToDateTime(Request.QueryString["data_nascimento"]).ToString("dd/MM/yyyy");
                    LblValorDataCadastro.Text = Request.QueryString["data_cadastro"];
                }
            }
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Clientes/ListaClientes");
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            var _cliente = new ClienteDTO()
            {
                ID = Convert.ToInt32(LblID.Text),
                Nome= LblValorNome.Text,
                Tipo = LblValorTipo.Text == "CNPJ" ? TipoOpcoes.CNPJ : TipoOpcoes.CPF,
                Data_Nascimento = Convert.ToDateTime(LblValorDataNascimento.Text),
                Data_Cadastro = Convert.ToDateTime(LblValorDataCadastro.Text)
            };
            Response.Redirect(new ListaClientes().MontaURL("FormularioCliente.aspx", _cliente));
        }
    }
}