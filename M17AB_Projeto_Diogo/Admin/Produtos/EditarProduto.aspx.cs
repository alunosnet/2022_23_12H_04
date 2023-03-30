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
    public partial class EditarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (IsPostBack) return;
            try
            {
                //querystring nproduto
                int id_produto = int.Parse(Request["id_produto"].ToString());

                Models.Produtos pd = new Models.Produtos();
                DataTable dados = pd.devolveDadosProdutos(id_produto);
                if (dados == null || dados.Rows.Count == 0)
                {
                    throw new Exception("O produto não existe.");
                }

                //mostrar os dados produto
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbEan.Text = dados.Rows[0]["ean"].ToString();
                tbPreco.Text = dados.Rows[0]["preco"].ToString();
                dpTipo.Text = dados.Rows[0]["categoria"].ToString();
                tbstock.Text = dados.Rows[0]["stock"].ToString();
                Random rnd = new Random();
            }
            catch
            {
                Response.Redirect("~/Admin/Produtos/Produtos.aspx");
            }
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
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
                if (preco < 0 || preco > 4000)
                {
                    throw new Exception("O preço deve estar entre 0 e 4000");
                }
                string categoria = dpTipo.SelectedValue;
                if (categoria == "")
                {
                    throw new Exception("A Categoria não é válida");
                }
                int stock = int.Parse(tbstock.Text);
                if (stock < 0)
                {
                    throw new Exception("O stock tem de ser maior que 0");
                }

                Models.Produtos produtos = new Models.Produtos();
                produtos.nome = nome;
                produtos.preco = preco;
                produtos.ean = ean;
                produtos.categoria = categoria;
                produtos.stock = stock;
                int id_produto = int.Parse(Request["id_produto"].ToString());
                produtos.ID_Produto = id_produto;
                produtos.atualizaProduto();

                lbErro.Text = "O produto foi editado com sucesso.";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                   "Redirecionar", "returnMain('Produtos.aspx')", true);

            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
        }
    }
}