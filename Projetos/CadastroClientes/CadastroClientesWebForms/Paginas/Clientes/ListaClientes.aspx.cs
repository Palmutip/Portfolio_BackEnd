using CadastroClientes.Objetos;
using CadastroClientes.Regras;
using Comuns;
using DataAccessADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class ListaClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"].IsNullOrEmpty() || Session["senha"].IsNullOrEmpty())
                Response.Redirect("~/Default.aspx");

            var _clientes = new ClienteBLL().Get();

            foreach(var cli in _clientes)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();
                TableCell cell5 = new TableCell();

                Panel panel = new Panel();

                Button button1 = new Button
                {
                    Text = "Editar",
                    ID = "BtnEditar" + cli.ID.ToString(),
                    CssClass = "btn btn-primary margem-botao"
                };
                button1.Click += BtnEditarCliente_Click;

                Button button2 = new Button
                {
                    Text = "Detalhes",
                    ID = "BtnDetalhes" + cli.ID.ToString(),
                    CssClass = "btn btn-info margem-botao"
                };
                button2.Click += BtnDetalhesCliente_Click;

                Button button3 = new Button
                {
                    Text = "Deletar",
                    ID = "BtnDeletar" + cli.ID.ToString(),
                    CssClass = "btn btn-danger margem-botao"
                };
                button3.Click += BtnDeletarCliente_Click;

                panel.Controls.Add(button1);
                panel.Controls.Add(button2);
                panel.Controls.Add(button3);

                cell1.Controls.Add(panel);
                cell2.Text = cli.Nome;
                cell3.Text = cli.Tipo == TipoOpcoes.CNPJ ? "CNPJ" : "CPF";
                cell4.Text = cli.Data_Nascimento.ToString("dd/MM/yyyy");
                cell5.Text = cli.Data_Cadastro.ToString("dd/MM/yyyy hh:mm:ss");

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);

                TblClientes.Rows.Add(row);
            }
        }

        protected void BtnCadastrarNovoCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect(MontaURL("FormularioCliente.aspx"));
        }

        protected void BtnDetalhesCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect(MontaURL("DetalhesCliente.aspx", ClienteAtual(sender)));
        }

        protected void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect(MontaURL("FormularioCliente.aspx", ClienteAtual(sender)));
        }

        protected void BtnDeletarCliente_Click(object sender, EventArgs e)
        {
            new ClienteBLL().Delete(ClienteAtual(sender));

            Response.Redirect(Request.RawUrl);
        }

        private ClienteDTO ClienteAtual(object sender)
        {
            Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>> dadosFiltro = new Dictionary<Tuple<string, string, Type>, KeyValuePair<string, string>>();

            string idButton = ((Button)sender).ID.Remove(9);
            string ID;

            switch (idButton)
            {
                case "BtnEditar":
                    ID = ((Button)sender).ID.Replace("BtnEditar", "");
                    break;
                case "BtnDeleta":
                    ID = ((Button)sender).ID.Replace("BtnDeletar", "");
                    break;
                case "BtnDetalh":
                    ID = ((Button)sender).ID.Replace("BtnDetalhes", "");
                    break;
                default:
                    return null;
            }

            string dadosEnvio = "ID=" + ID;
            if (!dadosEnvio.Equals(""))
            {
                dadosFiltro = Filtro.ParamFiltroBusca(dadosEnvio);
            }
            
            return new ClienteBLL().Get(dadosFiltro).FirstOrDefault();
        }

        public string MontaURL(string pagina, ClienteDTO cliente = null)
        {
            string url = pagina;

            if(cliente != null)
            {
                url = string.Concat(url,"?");

                if (!cliente.ID.IsNullOrEmpty())
                    url = string.Concat(url, "id=" + cliente.ID);

                if (!cliente.Nome.IsNullOrEmpty())
                    url = string.Concat(url, "&nome=" + HttpUtility.UrlEncode(cliente.Nome));

                if (!cliente.Tipo.IsNullOrEmpty())
                    url = string.Concat(url, "&tipo=" + cliente.Tipo);

                if (!cliente.Data_Nascimento.IsNullOrEmpty())
                    url = string.Concat(url, "&data_nascimento=" + HttpUtility.UrlEncode(cliente.Data_Nascimento.ToString()));

                if (!cliente.Data_Cadastro.IsNullOrEmpty())
                    url = string.Concat(url, "&data_cadastro=" + HttpUtility.UrlEncode(cliente.Data_Cadastro.ToString()));
            }

            return url;
        }
    }
}