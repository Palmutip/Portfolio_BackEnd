<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaClientes.aspx.cs" Inherits="WebFormsApp.ListaClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <link rel="stylesheet" type="text/css" href="../../Content/Site.css" />
    <div class="row">
        <h2>Lista de Clientes</h2>
        <p>
            <asp:LinkButton ID="BtnCadastrarNovoCliente" runat="server" CssClass="btn btn-primary" OnClick="BtnCadastrarNovoCliente_Click">
                <i class="bi bi-plus"></i>
                Criar Novo</asp:LinkButton>
        </p>
        <asp:Table ID="TblClientes" runat="server" CssClass="table">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Text="Ações"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Nome"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Tipo"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Data de Nascimento"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Data de Cadastro"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
</asp:Content>
