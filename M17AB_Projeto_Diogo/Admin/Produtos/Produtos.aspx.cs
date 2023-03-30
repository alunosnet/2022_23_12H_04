using M17AB_Projeto_Diogo.Classes;
using M17AB_Projeto_Diogo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.Admin.Produtos
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();

            if (!IsPostBack)
            {
                AtualizarGrid();
            }
        }

        private void ConfigurarGrid()
        {
            gvProdutos.AllowPaging = true;
            gvProdutos.PageSize = 5;
            gvProdutos.PageIndexChanging += GvProdutos_PageIndexChanging;
        }

        private void GvProdutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProdutos.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvProdutos.Columns.Clear();
            Models.Produtos lv = new Models.Produtos();
            DataTable dados = lv.ListaTodosProdutos();

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            DataColumn dcApagar = new DataColumn();
            dcApagar.ColumnName = "Apagar";
            dcApagar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcApagar);

            //colunas da gridview
            gvProdutos.DataSource = dados;
            gvProdutos.AutoGenerateColumns = false;

            //Editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarProduto.aspx?id_produto={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id_produto" };
            gvProdutos.Columns.Add(hlEditar);

            //Apagar
            HyperLinkField hlApagar = new HyperLinkField();
            hlApagar.HeaderText = "Apagar";
            hlApagar.DataTextField = "Apagar";
            hlApagar.Text = "Apagar...";
            hlApagar.DataNavigateUrlFormatString = "ApagarProduto.aspx?id_produto={0}";
            hlApagar.DataNavigateUrlFields = new string[] { "id_produto" };
            gvProdutos.Columns.Add(hlApagar);

            //nproduto
            BoundField bfid_produto = new BoundField();
            bfid_produto.HeaderText = "ID Produto";
            bfid_produto.DataField = "id_produto";
            gvProdutos.Columns.Add(bfid_produto);

            //nome
            BoundField bfnome = new BoundField();
            bfnome.HeaderText = "Nome";
            bfnome.DataField = "nome";
            gvProdutos.Columns.Add(bfnome);

            //Preço
            BoundField bfpreco = new BoundField();
            bfpreco.HeaderText = "Preço";
            bfpreco.DataField = "preco";
            bfpreco.DataFormatString = "{0:C}";
            gvProdutos.Columns.Add(bfpreco);

            //Referencia
            BoundField bfreferencia = new BoundField();
            bfreferencia.HeaderText = "EAN";
            bfreferencia.DataField = "ean";
            gvProdutos.Columns.Add(bfreferencia);

            //Categoria
            BoundField bfcategoria = new BoundField();
            bfcategoria.HeaderText = "Categoria";
            bfcategoria.DataField = "categoria";
            gvProdutos.Columns.Add(bfcategoria);

            //Estado
            BoundField bfstock = new BoundField();
            bfstock.HeaderText = "Stock";
            bfstock.DataField = "stock";
            gvProdutos.Columns.Add(bfstock);

            //Capa
            ImageField ifcapa = new ImageField();
            ifcapa.HeaderText = "Capa";
            int aleatorio = new Random().Next(99999);
            ifcapa.DataImageUrlFormatString = "~/Public/Imagens/{0}.jpg?" + aleatorio;
            ifcapa.DataImageUrlField = "id_produto";
            ifcapa.ControlStyle.Width = 200;
            gvProdutos.Columns.Add(ifcapa);

            gvProdutos.DataBind();
        }

        protected void bt_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text;
                if (nome.Trim().Length < 3)
                {
                    throw new Exception("O nome é muito pequeno.");
                }
                string ean = tbEan.Text;
                if (ean.Trim().Length < 8)
                {
                    throw new Exception("A referência tem de ser maior que 8");
                }
                Decimal preco = Decimal.Parse(tbPreco.Text);
                if (preco < 0 || preco > 20000)
                {
                    throw new Exception("O preço deve estar entre 0 e 4000");
                }
                string categoria = dpTipo.SelectedValue;
                if (categoria == "")
                {
                    throw new Exception("A categoria não é válida");
                }
                int stock = int.Parse(tbstock.Text);
                if (stock == 0)
                {
                    throw new Exception("O Produto tem de ter pelo menos 1 artigo em stock");
                }

                Models.Produtos produtos = new Models.Produtos();
                produtos.nome = nome;
                produtos.preco = preco;
                produtos.ean = ean;
                produtos.categoria = categoria;
                produtos.stock = stock;
                int id_produto = produtos.Adicionar();

                if (fuCapa.HasFile)
                {
                    string ficheiro = Server.MapPath(@"~\Public\Imagens\");
                    ficheiro = ficheiro + id_produto + ".jpg";
                    fuCapa.SaveAs(ficheiro);
                }
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
            //limpar form
            tbNome.Text = "";
            tbPreco.Text = "";
            tbEan.Text = "";
            dpTipo.SelectedIndex = 0;

            //atualizar grid
            AtualizarGrid();
        }
    }
}