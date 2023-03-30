<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="M17AB_Projeto_Diogo.User.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Área de Utilizador</h1>
    <div runat="server" id="divPerfil">
        Nome:<asp:Label runat="server" ID="lbNome"></asp:Label>
        <br />Morada<asp:Label runat="server" ID="lbMorada"></asp:Label>
        <br />Nif<asp:Label runat="server" ID="lbnif"></asp:Label>
        <br />Email<asp:Label runat="server" ID="lbEmail"></asp:Label>
        
        <br />
        <br />Relação Familiar: <asp:Label runat="server" ID="lbrelacao"></asp:Label>
        <br />
        <br /><asp:Button runat="server" ID="btEditar" Text="Editar Perfil" OnClick="btEditar_Click"/>
    </div>
    <div runat="server" id="divEditar">
        Nome:<asp:TextBox runat="server" ID="tbNome"></asp:TextBox>
        <br />Morada<asp:TextBox runat="server" ID="tbMorada"></asp:TextBox>
        <br />Nif<asp:TextBox runat="server" ID="tbNif" MaxLength="9    "></asp:TextBox>
        <br />Email:<asp:TextBox runat="server" ID="tbEmail"></asp:TextBox>

        <br />
        <br />Relação Familiar: <asp:TextBox runat="server" ID="tbRelacao"></asp:TextBox>

        <asp:Button runat="server" ID="btAtualizar" Text="Atualizar Perfil" OnClick="btAtualizar_Click"/>
        <asp:Button runat="server" ID="btCancelar" Text="Cancelar" OnClick="btCancelar_Click" />
    </div>
</asp:Content>
