<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApagarProduto.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Produtos.ApagarProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Confirmar apagar produto</h1>
    ID do Produto:<asp:Label runat="server" ID="lbIDProduto" CssClass="form-control"></asp:Label>
    <br />Nome:<asp:Label runat="server" ID="lbNome" CssClass="form-control"></asp:Label>
    <br />Capa<asp:Image CssClass="figure-img" runat="server" ID="imgCapa" />
    <br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btRemover" Text="Remover" OnClick="btRemover_Click" />
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btVoltar" Text="Voltar" OnClick="btVoltar_Click"/>
    <br /><asp:Label runat="server" ID="lbErro"></asp:Label>
</asp:Content>
