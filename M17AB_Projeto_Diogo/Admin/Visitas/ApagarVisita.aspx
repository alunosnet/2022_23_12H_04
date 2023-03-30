<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApagarVisita.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Visitas.ApagarVisita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Cancelar Visita</h1>
    ID_Visita:<asp:Label runat="server" ID="lbIDUtilizador" CssClass="form-control"></asp:Label>
    <br />ID_Idoso:<asp:Label runat="server" ID="lbNome" CssClass="form-control"></asp:Label>
    
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btRemover" Text="Remover" Onclick="btRemover_Click"/>
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btVoltar" Text="Voltar" Onclick="btVoltar_Click"/>
    <br /><asp:Label runat ="server" ID="lbErro"></asp:Label>
</asp:Content>
