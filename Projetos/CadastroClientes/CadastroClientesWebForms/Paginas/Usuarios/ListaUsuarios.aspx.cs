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
    public partial class ListaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"].IsNullOrEmpty() || Session["senha"].IsNullOrEmpty())
                Response.Redirect("~/Default.aspx");

            var _usuarios = new UsuarioBLL().Get();

            foreach (var user in _usuarios)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell cell4 = new TableCell();

                Panel panel = new Panel();

                Button button1 = new Button
                {
                    Text = "Editar",
                    ID = "BtnEditar" + user.ID.ToString(),
                    CssClass = "btn btn-primary margem-botao"
                };
                button1.Click += BtnEditarUsuario_Click;

                Button button2 = new Button
                {
                    Text = "Detalhes",
                    ID = "BtnDetalhes" + user.ID.ToString(),
                    CssClass = "btn btn-info margem-botao"
                };
                button2.Click += BtnDetalhesUsuario_Click;

                Button button3 = new Button
                {
                    Text = "Deletar",
                    ID = "BtnDeletar" + user.ID.ToString(),
                    CssClass = "btn btn-danger margem-botao"
                };
                button3.Click += BtnDeletarUsuario_Click;

                panel.Controls.Add(button1);
                panel.Controls.Add(button2);
                panel.Controls.Add(button3);

                cell1.Controls.Add(panel);
                cell2.Text = user.Nome;
                cell3.Text = user.Email;
                cell4.Text = user.Senha;

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);

                TblUsuarios.Rows.Add(row);
            }
        }
        protected void BtnCadastrarNovoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect(MontaURL("FormularioUsuario.aspx"));
        }

        protected void BtnDetalhesUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect(MontaURL("DetalhesUsuario.aspx", UsuarioAtual(sender)));
        }

        protected void BtnEditarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect(MontaURL("FormularioUsuario.aspx", UsuarioAtual(sender)));
        }

        protected void BtnDeletarUsuario_Click(object sender, EventArgs e)
        {
            new UsuarioBLL().Delete(UsuarioAtual(sender));

            Response.Redirect(Request.RawUrl);
        }

        private UsuarioDTO UsuarioAtual(object sender)
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

            return new UsuarioBLL().Get(dadosFiltro).FirstOrDefault();
        }

        public string MontaURL(string pagina, UsuarioDTO usuario = null)
        {
            string url = pagina;

            if (usuario != null)
            {
                url = string.Concat(url, "?");

                if (!usuario.ID.IsNullOrEmpty())
                    url = string.Concat(url, "id=" + usuario.ID);

                if (!usuario.Nome.IsNullOrEmpty())
                    url = string.Concat(url, "&nome=" + HttpUtility.UrlEncode(usuario.Nome));

                if (!usuario.Email.IsNullOrEmpty())
                    url = string.Concat(url, "&email=" + usuario.Email);

                if (!usuario.Senha.IsNullOrEmpty())
                    url = string.Concat(url, "&senha=" + HttpUtility.UrlEncode(usuario.Senha));
            }

            return url;
        }
    }
}