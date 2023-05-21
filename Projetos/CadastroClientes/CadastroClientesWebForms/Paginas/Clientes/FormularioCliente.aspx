<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="WebFormsApp.FormularioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.9.1/font/bootstrap-icons.css">
    <div class="row">
        <h2>Cliente</h2>
        <asp:Label ID="LblID" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="LblNome" runat="server" Text="Nome:" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="TxtNome" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="LblTipo" runat="server" Text="Tipo:" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="CmdTipo" runat="server" CssClass="form-control">
            <asp:ListItem Value="0" Text="CNPJ"></asp:ListItem>
            <asp:ListItem Value="1" Text="CPF"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="LblDataNascimento" runat="server" Text="Data de Nascimento:" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="TxtDataNascimento" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label ID="LblDataCadastro" runat="server" Text="Data de Cadastro" CssClass="control-label" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="TxtDataCadastro" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
        <br />
        <asp:LinkButton ID="BtnVoltar" runat="server" CssClass="btn btn-default margem-botao" OnClick="BtnVoltar_Click">
            <i class="bi bi-arrow-left-circle" style="margin-right: 4px"></i>
            Voltar</asp:LinkButton>
        <asp:LinkButton ID="BtnSalvar" runat="server" CssClass="btn btn-primary" OnClick="BtnSalvar_Click">
            <i class="bi bi-check" style="margin-right: 4px"></i>
            Salvar</asp:LinkButton>   
    </div>
</asp:Content>
