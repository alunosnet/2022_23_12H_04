<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="produtos.aspx.cs" Inherits="M17AB_Projeto_Diogo.User.Produtos.produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Comprar Produto</h2>
    <asp:GridView runat="server" ID="gvprodutos"></asp:GridView>
</asp:Content>
