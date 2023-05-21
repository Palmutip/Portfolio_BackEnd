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
    public partial class FormularioCliente : System.Web.UI.Page
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
                    CmdTipo.SelectedIndex = Request.QueryString["tipo"] == "CNPJ" ? 0 : 1;
                    TxtDataNascimento.Text = Convert.ToDateTime(Request.QueryString["data_nascimento"]).ToString("dd/MM/yyyy");
                    TxtDataCadastro.Text = Request.QueryString["data_cadastro"];
                }
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (LblID.Text != "")
            {
                ClienteDTO _cliente = new ClienteDTO()
                {
                    ID = Convert.ToInt32(LblID.Text),
                    Nome = TxtNome.Text,
                    Tipo = CmdTipo.SelectedIndex == 0 ? TipoOpcoes.CNPJ : TipoOpcoes.CPF,
                    Data_Nascimento = Convert.ToDateTime(TxtDataNascimento.Text),
                };
                new ClienteBLL().Save(_cliente);
            }
            else
            {
                ClienteDTO _cliente = new ClienteDTO()
                {
                    Nome = TxtNome.Text,
                    Tipo = CmdTipo.SelectedIndex == 0 ? TipoOpcoes.CNPJ : TipoOpcoes.CPF,
                    Data_Nascimento = Convert.ToDateTime(TxtDataNascimento.Text),
                };
                new ClienteBLL().Save(_cliente);
            }

            LblID.Text = "";

            Response.Redirect("~/Paginas/Clientes/ListaClientes");
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Paginas/Clientes/ListaClientes");
        }
    }
}