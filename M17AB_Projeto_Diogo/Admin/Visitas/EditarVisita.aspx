<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarVisita.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Visitas.EditarVisita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h1>Editar Utilizador</h1>

    <div class="from-group">
        <label for="ContentPlaceHolder1_tbData">Data da Visita:</label>
        <asp:TextBox CssClass="form-control" ID="tbData" runat="server" MaxLength="100" TextMode="Date" /><br />
    </div>
    <br />
    <!--<div class="from-group">
        <label for="ContentPlaceHolder1_dd_Idoso">Idoso:</label>
        <a href="#">content</a>sp:DropDownList CssClass="form-select" ID="dd_Idoso" runat="server">
        </asp:DropDownList>
        
    </div>
        -->
    <br />
    <asp:Button ID="btAtualizar" runat="server" CssClass="btn btn-lg btn-success" Text="Atualizar" OnClick="btAtualizar_Click"/>
    <asp:Button runat="server" ID="btVoltar" CssClass="btn btn-lg btn-info" Text="Voltar" PostBackUrl="~/Admin/Visitas/Visitas.aspx"/>
    <br />
    <asp:Label ID="lbErro" runat="server"></asp:Label>
</asp:Content>
