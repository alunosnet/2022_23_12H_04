using M17AB_Projeto_Diogo.Admin.Produtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo
{
    public partial class detalhesproduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    int id_produto = int.Parse(Request["id_produto"].ToString());
            //    Models.Produtos prod = new Models.Produtos();
            //    DataTable dados = prod.devolveDadosProdutos(id_produto);
            //    lbNome.Text = dados.Rows[0]["nome"].ToString();
            //    lbean.Text = dados.Rows[0]["ean"].ToString();
            //    lbPreco.Text = String.Format("{0:c}", Decimal.Parse(dados.Rows[0]["preco"].ToString()));
            //    string ficheiro = @"~\Public\Images\" + dados.Rows[0]["id_produto"].ToString() + ".jpg";
            //    imgCapa.ImageUrl = ficheiro;
            //    imgCapa.Width = 200;
            //}
            //catch
            //{
            //    Response.Redirect("~/index.aspx");
            //}
        }

        protected void btReservar_Click(object sender, EventArgs e)
        {

        }
    }
}