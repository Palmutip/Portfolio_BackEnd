<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="WebFormsApp.FormularioUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <div class="row">
        <h2>Usuário</h2>
        <asp:Label ID="LblID" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="LblNome" runat="server" Text="Nome" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="TxtNome" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="LblEmail" runat="server" Text="E-mail" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="LblSenha" runat="server" Text="Senha" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="TxtSenha" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:LinkButton ID="BtnVoltar" runat="server" CssClass="btn btn-default margem-botao" OnClick="BtnVoltar_Click">
            <i class="bi bi-arrow-left-circle" style="margin-right: 4px"></i>
            Voltar</asp:LinkButton>
        <asp:LinkButton ID="BtnSalvar" runat="server" CssClass="btn btn-primary" OnClick="BtnSalvar_Click">
            <i class="bi bi-check" style="margin-right: 4px"></i>
            Salvar</asp:LinkButton>  
    </div>
</asp:Content>
