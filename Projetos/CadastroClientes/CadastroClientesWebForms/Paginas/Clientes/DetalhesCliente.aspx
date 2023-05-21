<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalhesCliente.aspx.cs" Inherits="WebFormsApp.DetalhesCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <div class="row">
        <h2>Cliente</h2>
        <asp:Label ID="LblID" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="LblNome" runat="server" Text="Nome:" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:Label ID="LblValorNome" runat="server" Text="" CssClass="control-label"></asp:Label>
        <br />
        <asp:Label ID="LblTipo" runat="server" Text="Tipo:" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:Label ID="LblValorTipo" runat="server" Text="" CssClass="control-label"></asp:Label>
        <br />
        <asp:Label ID="LblDataNascimento" runat="server" Text="Data de Nascimento:" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:Label ID="LblValorDataNascimento" runat="server" Text="" CssClass="control-label"></asp:Label>
        <br />
        <asp:Label ID="LblDataCadastro" runat="server" Text="Data de Cadastro" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:Label ID="LblValorDataCadastro" runat="server" Text="" CssClass="control-label"></asp:Label>
        <br /><br />
        <asp:LinkButton ID="BtnVoltar" runat="server" CssClass="btn btn-default margem-botao" OnClick="BtnVoltar_Click">
            <i class="bi bi-arrow-left-circle" style="margin-right: 4px"></i>Voltar
        </asp:LinkButton>
        <asp:LinkButton ID="BtnEditar" runat="server" CssClass="btn btn-primary" OnClick="BtnEditar_Click">
            <i class="bi bi-pencil" style="margin-right: 4px"></i>
            Editar</asp:LinkButton>
    </div>
</asp:Content>
