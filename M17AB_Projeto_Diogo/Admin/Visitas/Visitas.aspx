    <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Visitas.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Visitas.Visitas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>  
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Visitas</h2>
    <asp:CheckBox runat ="server" ID="cb_idosos_reservados" AutoPostBack="true" OnCheckedChanged="cb_idosos_reservados_CheckedChanged"/>Só Idosos com marcações Reservadas 
    <asp:GridView runat="server" ID="gv_visitas"></asp:GridView>
    <h2>Registar nova visita</h2>
    Idoso: <asp:DropDownList runat="server" ID="dd_idoso"></asp:DropDownList>
    <br />
    Familiar: <asp:DropDownList runat="server" ID="dd_familiar"></asp:DropDownList>
    <br />
    Data da Visita: <asp:TextBox runat="server" ID="tb_data" TextMode="Date"></asp:TextBox>
    <br />
    <asp:Button runat="server" ID="bt_registar" Text="Visitar" OnClick="bt_registar_Click" />
    <br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>
