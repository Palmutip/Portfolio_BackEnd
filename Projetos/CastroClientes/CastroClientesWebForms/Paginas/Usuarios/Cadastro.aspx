<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="WebFormsApp.Cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Cadastro</h2>

        <asp:Label runat="server" CssClass="control-label"><b>Nome:</b></asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="TxtNome"></asp:TextBox>
        <asp:Label runat="server" CssClass="control-label"><b>E-mail:</b></asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="TxtEmail"></asp:TextBox>
        <asp:Label runat="server" CssClass="control-label"><b>Senha:</b></asp:Label>
        <asp:TextBox runat="server" CssClass="form-control" ID="TxtSenha"></asp:TextBox>
        <br />
        <asp:Button ID="BtnCadastrar" runat="server" Text="Criar Conta" CssClass="btn btn-primary" OnClick="BtnCadastrar_Click" />
    </div>
</asp:Content>
