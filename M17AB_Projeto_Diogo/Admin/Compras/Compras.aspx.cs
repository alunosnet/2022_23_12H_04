using M17AB_Projeto_Diogo.Classes;
using M17AB_Projeto_Diogo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.Admin.Compras
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();
            if (IsPostBack) return;

            AtualizarGrid();
            AtualizaDDProdutos();
            AtualizarDDUtilizadores();
        }
        private void ConfigurarGrid()
        {
            //Paginação
            gv_compras.AllowPaging = true;
            gv_compras.PageSize = 5;
            gv_compras.PageIndexChanging += Gv_compras_PageIndexChanging;
            //Botões de comando
            gv_compras.RowCommand += Gv_compras_RowCommand;
        }
        private void Gv_compras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // mudar de página
            if (e.CommandName == "Page") return;

            //linha
            int linha = int.Parse(e.CommandArgument.ToString());

            //id da compra
            int idcompra = int.Parse(gv_compras.Rows[linha].Cells[1].Text);
            Compras comp = new Compras();
            if (e.CommandName == "eliminar")
            {
                Response.Redirect("ApagarCompras.aspx?id=" + idcompra);
            }

        }

        private void Gv_compras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_compras.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            Models.Compras comp = new Models.Compras();

            DataTable dados;
                dados=comp.listaTodosComprasComNomes();
            gv_compras.Columns.Clear();
            gv_compras.DataSource = null;
            gv_compras.DataBind();
            if (dados == null || dados.Rows.Count == 0) return;
            //botões de comando
            //receber
            ButtonField bfEliminar = new ButtonField();
            bfEliminar.HeaderText = "eliminar produto";
            bfEliminar.Text = "Eliminar";
            bfEliminar.ButtonType = ButtonType.Button;
            bfEliminar.ControlStyle.CssClass = "btn btn-info";
            bfEliminar.CommandName = "eliminar";
            gv_compras.Columns.Add(bfEliminar);


            gv_compras.DataSource = dados;
            gv_compras.AutoGenerateColumns = true;
            gv_compras.DataBind();
        }

        private void AtualizaDDProdutos()
        {
            Models.Produtos pd = new Models.Produtos();
            dd_produto.Items.Clear();
            DataTable dados = pd.listaProdutosDisponiveis();
            foreach (DataRow linha in dados.Rows)
                dd_produto.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id_produto"].ToString())
                    );
        }

        private void AtualizarDDUtilizadores()
        {
            Utilizador user = new Utilizador();
            dd_user.Items.Clear();
            DataTable dados = user.ListaTodosUtilizadores();
            foreach (DataRow linha in dados.Rows)
                dd_user.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                    );
        }

        protected void bt_registar_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Compras comp = new Models.Compras();
                int id_produto = int.Parse(dd_produto.SelectedValue);
                int id = int.Parse(dd_user.SelectedValue);
                DateTime data = DateTime.Parse(tb_data.Text);
                comp.adicionarCompra(id_produto, id, data);

                lb_erro.Text = "A compra foi registada com sucesso.";
                lb_erro.CssClass = "";

            }
            catch (Exception erro)
            {
                lb_erro.Text = "Ocorreu um erro:" + erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
            AtualizarDDUtilizadores();
            AtualizaDDProdutos();
            AtualizarGrid();
        }
    }
}