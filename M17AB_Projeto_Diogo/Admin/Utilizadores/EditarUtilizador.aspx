<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarUtilizador.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Utilizadores.EditarUtilizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Editar Utilizador</h1>

    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="tbNome" runat="server" MaxLength="100" Required placeholder="Nome do Utilizador" /><br />
    </div>   
        
    <div class="from-group">
        <label for="ContentPaceHolder1_tbMorada">Morada:</label>
        <asp:TextBox CssClass="form-control" ID="tbMorada" runat="server" MaxLength="200" placeholder="Morada"/> <br />
    </div>
    <div class="from-group">
        <label for="ContentPaceHolder1_tbNif">Nif:</label>
        <asp:TextBox CssClass="form-control" ID="tbNif" runat="server"/> <br />
    </div>
    <div class="from-group">
        <label for="ContentPaceHolder1_tbEmail">Email:</label>
        <asp:TextBox CssClass="form-control" ID="tbEmail" runat="server"/> <br />
    </div>
    <div class="from-group">
        <label for="ContentPaceHolder1_tbRelacao">Relação:</label>
        <asp:TextBox CssClass="form-control" ID="tbRelacao" runat="server"/> <br />
    </div>
    <!--<div class="from-group">
        <label for="ContentPlaceHolder1_dd_Idoso">Idoso:</label>
        <a href="#">content</a>sp:DropDownList CssClass="form-select" ID="dd_Idoso" runat="server">
        </asp:DropDownList>
        
    </div>
        -->
    <br />
    <asp:Button ID="btAtualizar" runat="server" CssClass="btn btn-lg btn-success" Text="Atualizar" OnClick="btAtualizar_Click" />
    <asp:Button runat="server" ID="btVoltar" CssClass="btn btn-lg btn-info" Text="Voltar" PostBackUrl="~/Admin/Utilizadores/Utilizadores.aspx"/>
    <br />
    <asp:Label ID="lbErro" runat="server"></asp:Label>
</asp:Content>
