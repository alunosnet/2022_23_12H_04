using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.User.Produtos
{
    public partial class produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
                Response.Redirect("~/index.aspx");
            ConfigurarGrid();
            AtualizarGrid();
        }

        private void ConfigurarGrid()
        {
            gvprodutos.RowCommand += Gvprodutos_RowCommand;
        }

        private void Gvprodutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = int.Parse(e.CommandArgument.ToString());
            int id_produto = int.Parse(gvprodutos.Rows[linha].Cells[1].Text);
            int id = int.Parse(Session["id"].ToString());
            if (e.CommandName == "Comprar")
            {
                Models.Compras comp = new Models.Compras();
                comp.adicionarCompra(id_produto, id, DateTime.Now);
                AtualizarGrid();
            }
        }

        private void AtualizarGrid()
        {
            gvprodutos.Columns.Clear();
            gvprodutos.DataSource = null;
            gvprodutos.DataBind();

            Models.Produtos produto = new Models.Produtos();
            gvprodutos.DataSource = produto.listaProdutosDisponiveis();

            //botão Comprar
            ButtonField bt = new ButtonField();
            bt.HeaderText = "Comprar";
            bt.Text = "Comprar";
            bt.ButtonType = ButtonType.Button;
            bt.CommandName = "Comprar";
            bt.ControlStyle.CssClass = "btn btn-danger";
            gvprodutos.Columns.Add(bt);

            gvprodutos.DataBind();
        }
    }
}