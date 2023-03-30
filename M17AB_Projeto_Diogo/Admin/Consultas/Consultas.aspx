<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Consultas.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Consultas</h2>
    <asp:DropDownList ID="ddConsultas" CssClass="form-control" AutoPostBack="true" 
        OnSelectedIndexChanged="ddConsultas_SelectedIndexChanged" runat="server">

        <asp:ListItem Value="0">Top de Idosos mais Visitados</asp:ListItem>
        <asp:ListItem Value="1">Nº de Utilizadores</asp:ListItem>
        <asp:ListItem Value="2">Nº de visitas por mês</asp:ListItem>

        </asp:DropDownList>
    <asp:GridView CssClass="table" ID="gvConsultas" runat="server"></asp:GridView>
</asp:Content>
