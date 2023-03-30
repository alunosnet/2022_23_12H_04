<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="registo.aspx.cs" Inherits="M17AB_Projeto_Diogo.registo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src ="https://www.google.com/recaptcha/api.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<h2>Registo</h2>

    <div class="from-group">
        <label for="ContentPlaceHolder1_tb_nome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="tb_nome" runat="server"/><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tb_email">Email:</label>
        <asp:TextBox CssClass="form-control" ID="tb_email" runat="server" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tb_morada">Morada:</label>
        <asp:TextBox CssClass="form-control" ID="tb_morada" runat="server"/><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tb_nif">Nif:</label>
        <asp:TextBox ID="tb_nif" CssClass="form-control" runat="server" MaxLength="9"/><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tb_password">Password:</label>
        <asp:TextBox ID="tb_password" CssClass="form-control" runat="server"    TextMode="Password" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tb_relacao">Relaçao:</label>
        <asp:TextBox ID="tb_relacao" CssClass="form-control" runat="server"/><br />
    </div>
    Idoso:<asp:DropdownList runat="server" ID="dd_idoso"></asp:DropdownList>
    <asp:Button runat="server" ID="bt_guardar" Text="Registar" Onclick="bt_guardar_Click"/><br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
        <!--recaptcha-->
    <div class = "g-recaptcha" data-sitekey="6LczdM8jAAAAAMje4BXy1d-vly027TN18ZuO0YcK"></div>

</asp:Content>
