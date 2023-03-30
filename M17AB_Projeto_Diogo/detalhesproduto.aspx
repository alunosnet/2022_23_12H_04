<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detalhesproduto.aspx.cs" Inherits="M17AB_Projeto_Diogo.detalhesproduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Image CssClass="img-fluid" ID="imgCapa" runat="server" /><br />
    <asp:Label ID="lbNome" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lbPreco" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="lbean" runat="server" Text=""></asp:Label><br />

    <%if (Session["perfil"] != null && Session["perfil"].Equals("1")){ %>
    <asp:Button CssClass="btn btn-danger" ID="btReservar" runat="server" Text="Comprar" Onclick="btReservar_Click" />
    <asp:Label runat="server" ID="lbErro" />
    <% } %>
    <br /><a href="/index.aspx">Voltar</a>
</asp:Content>
