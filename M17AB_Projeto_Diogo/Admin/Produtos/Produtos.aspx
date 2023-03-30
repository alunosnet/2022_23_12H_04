<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="M17AB_Projeto_Diogo.Admin.Produtos.Produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2>Gerir Produtos</h2>
    <asp:GridView ID="gvProdutos" runat="server" CssClass="table" />
    <h2>Adicionar Produto</h2>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="tbNome" runat="server" MaxLength="100" Required placeholder="Nome do produto" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbEan">EAN:</label>
        <asp:TextBox CssClass="form-control" ID="tbEan" runat="server" MaxLength="12" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbPreco">Preço:</label>
        <asp:TextBox ID="tbPreco" CssClass="form-control" runat="server" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_dpTipo">Categoria:</label>
        <asp:DropDownList CssClass="form-select" ID="dpTipo" runat="server">
            <asp:ListItem Text="Acessórios" Value="Acessórios" />
            <asp:ListItem Text="Andarilho" Value="Andarilho" />
            <asp:ListItem Text="Acessórios WC" Value="Acessórios WC" />
         </asp:DropDownList>
    </div><br />
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbstock">Stock:</label>
        <asp:TextBox ID="tbstock" CssClass="form-control" runat="server" /><br />
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_fuCapa">Capa:</label>
        <asp:FileUpload ID="fuCapa" runat="server" CssClass="form-control" />
    </div> 
    <br />
    <asp:Button CssClass="btn btn-lg btn-success" runat="server" ID="bt" Text="Adicionar" Onclick="bt_Click"/>
    
    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
