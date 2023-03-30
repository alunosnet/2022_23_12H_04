<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="historico.aspx.cs" Inherits="M17AB_Projeto_Diogo.User.Visitas.historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<h2>Histórico Reservas</h2>
    <asp:GridView runat="server" ID="gvhistorico"></asp:GridView>
<h2>Histórico Compras </h2>
        <asp:GridView runat="server" ID="gvcompras"></asp:GridView>

</asp:Content>
