<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalhesUsuario.aspx.cs" Inherits="WebFormsApp.DetalhesUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <div class="row">
        <h2>Usuário</h2>
        <asp:Label ID="LblID" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="LblNome" runat="server" Text="Nome" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:Label ID="LblValorNome" runat="server" Text="" CssClass="control-label"></asp:Label>
        <br />
        <asp:Label ID="LblEmail" runat="server" Text="E-mail" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:Label ID="LblValorEmail" runat="server" Text="Label" CssClass="control-label"></asp:Label>
        <br />
        <asp:Label ID="LblSenha" runat="server" Text="Label" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:Label ID="LblValorSenha" runat="server" Text="Label" CssClass="control-label"></asp:Label>
        <br /><br />
        <asp:LinkButton ID="BtnVoltar" runat="server" CssClass="btn btn-default margem-botao" OnClick="BtnVoltar_Click">
            <i class="bi bi-arrow-left-circle" style="margin-right: 4px"></i>Voltar
        </asp:LinkButton>
        <asp:LinkButton ID="BtnEditar" runat="server" CssClass="btn btn-primary" OnClick="BtnEditar_Click">
            <i class="bi bi-pencil" style="margin-right: 4px"></i>
            Editar</asp:LinkButton>
    </div>
</asp:Content>
