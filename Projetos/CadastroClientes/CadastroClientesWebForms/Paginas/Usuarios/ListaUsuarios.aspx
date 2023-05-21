<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="WebFormsApp.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Content/Site.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <div class="row">
        <h2>Lista de Usuários</h2>

        <p>
            <asp:LinkButton ID="BtnCadastrarNovoUsuario" runat="server" CssClass="btn btn-primary" OnClick="BtnCadastrarNovoUsuario_Click">
                <i class="bi bi-plus"></i>
                Criar Novo</asp:LinkButton>
        </p>
        <asp:Table ID="TblUsuarios" runat="server" CssClass="table">
            <asp:TableHeaderRow>
                    <asp:TableHeaderCell Text="Ações"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Nome"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="E-mail"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Senha"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

    <style>
        
    </style>
</asp:Content>
