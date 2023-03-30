<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApagarIdoso.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Idosos.ApagarIdoso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<h1>Apagar Idosos</h1>
    ID Idoso:<asp:Label runat="server" ID="lbIDIdoso" CssClass="form-control"></asp:Label>
    <br />Nome:<asp:Label runat="server" ID="lbNome" CssClass="form-control"></asp:Label>
    
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btRemover" Text="Remover" OnClick="btRemover_Click"  />
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btVoltar" Text="Voltar" Onclick="btVoltar_Click" />
    <br /><asp:Label runat ="server" ID="lbErro"></asp:Label>

</asp:Content>
