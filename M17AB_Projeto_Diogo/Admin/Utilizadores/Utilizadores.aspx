<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Utilizadores.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Utilizadores.Utilizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <h1>Utilizador</h1> 
    <asp:GridView ID="gvUtilizador" runat="server" CssClass="table" />
    <h2>Adicionar Utilizador</h2>
    Nome:<asp:TextBox  runat="server" ID="tb_nome"></asp:TextBox><br />
    Email:<asp:TextBox  runat="server" ID="tb_email"></asp:TextBox><br />
    Morada:<asp:TextBox  runat="server" ID="tb_morada"></asp:TextBox><br />
    Nif:<asp:TextBox  runat="server" ID="tb_nif"></asp:TextBox><br />
    Password:<asp:TextBox  runat="server" ID="tb_password" TextMode="Password"></asp:TextBox><br />
    Relação Familiar<asp:TextBox runat="server" ID="tb_relacao"></asp:TextBox> <br />
    Perfil<asp:DropDownList  runat="server" ID="dd_perfil">
            <asp:ListItem Value="0">Admin</asp:ListItem>
            <asp:ListItem Value="1">Leitor</asp:ListItem>
          </asp:DropDownList><br />
    <br />
    Idoso:<asp:DropdownList runat="server" ID="dd_idoso"></asp:DropdownList>
    <br />

    <asp:Button ID="bt_guardar" runat="server" Text="Adicionar" OnClick="bt_guardar_Click" />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>