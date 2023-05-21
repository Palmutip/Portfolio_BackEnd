<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Site.css" />
    <h2>Login</h2>

    <div class="row">

        <%
            if (Session["mensagem"] != null && Session["mensagem"].ToString() != "")
            {
                %>
        <asp:Label ID="LblMensagemLogin" runat="server" Text="Usuario/Senha inválido!" Font-Bold="True" ForeColor="Red"></asp:Label>
        <br />
        <%
            } 
          %>

        <asp:Label runat="server" Text="Label" CssClass="control-label"><b>E-mail</b></asp:Label>
        <br />
        <asp:TextBox runat="server" CssClass="form-control" ID="TxtEmail"></asp:TextBox>
        <asp:Label runat="server" Text="Label" CssClass="control-label"><b>Senha:</b></asp:Label>
        <br />
        <asp:TextBox runat="server" CssClass="form-control" ID="TxtSenha"></asp:TextBox>
        <asp:HyperLink ID="LblCriarConta" runat="server" CssClass="form-text link-clicavel" Text="Ou crie sua conta" Font-Size="Small" NavigateUrl="~/Paginas/Usuarios/Cadastro"></asp:HyperLink>
        <br />
        <br />
        <asp:Button ID="BtnLogar" runat="server" Text="Entrar" CssClass="btn btn-primary" OnClick="BtnLogar_Click" />

    </div>

</asp:Content>
