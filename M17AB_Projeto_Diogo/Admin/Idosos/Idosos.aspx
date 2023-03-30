<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Idosos.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Idosos.Idosos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Idosos</h1>
    <asp:GridView ID="gvIdosos" runat="server" CssClass="table" />
    <h2>Adicionar Idoso</h2>
    <div class="form-group">
        <label for="ContentPlaceHolder1_tbNomeIdoso">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="tbNomeIdoso" runat="server" MaxLength="100" Required placeholder="Nome do Idoso" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNif">Nif:</label>
        <asp:TextBox CssClass="form-control" MaxLength="9" ID="tbNif" runat="server" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbData">Data de Nascimento:</label>
        <asp:TextBox CssClass="form-control" ID="tbData" runat="server" TextMode="Date" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbDoencas">Doenças:</label>
        <asp:TextBox ID="tbDoencas" CssClass="form-control" runat="server" MaxLength="100"/><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNUtenteSaude">Nº Utente de Saúde:</label>
        <asp:TextBox  MaxLength="9" ID="tbNUtenteSaude" CssClass="form-control" runat="server"/><br />
    </div>

    <asp:Button CssClass="btn btn-lg btn-success" runat="server" ID="bt" Text="Adicionar" Onclick="bt_Click" />
     
    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
