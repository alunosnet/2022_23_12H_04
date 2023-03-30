<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarIdoso.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Idosos.EditarIdoso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Editar Idoso</h1>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="tbNome" runat="server" MaxLength="100" Required placeholder="Nome do Utilizador" /><br />
    </div>
    <br />
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNif">Nif:</label>
        <asp:TextBox CssClass="form-control" ID="tbNif" runat="server" TextMode="Number"  /><br />
    </div>
    <br />
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbData">Data de Nascimento:</label>
        <asp:TextBox CssClass="form-control" ID="tbData" runat="server" MaxLength="100" TextMode="Date" /><br />
    </div>
    <br />
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbDoencas">Doenças:</label>
        <asp:TextBox CssClass="form-control" ID="tbDoencas" runat="server" MaxLength="3000" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNUtenteSaude">Nº Utente de Saúde:</label>
        <asp:TextBox CssClass="form-control" ID="tbNUtenteSaude" runat="server" TextMode="Number" /><br />
    </div>

    <asp:Button ID="btAtualizar" runat="server" CssClass="btn btn-lg btn-success" Text="Atualizar" Onclick="btAtualizar_Click" />
    <asp:Button runat="server" ID="btVoltar" CssClass="btn btn-lg btn-info" Text="Voltar" PostBackUrl="~/Admin/Idosos/Idosos.aspx"/>
    <br />
    <asp:Label ID="lbErro" runat="server"></asp:Label>
</asp:Content>
