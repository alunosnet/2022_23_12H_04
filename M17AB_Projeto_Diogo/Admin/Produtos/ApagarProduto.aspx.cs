using M17AB_Projeto_Diogo.Classes;
using M17AB_Projeto_Diogo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.Admin.Produtos
{
    public partial class ApagarProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            try
            {
                //querystring nproduto
                int id_produto = int.Parse(Request["id_produto"].ToString());

                Models.Produtos pd = new Models.Produtos();
                DataTable dados = pd.devolveDadosProdutos(id_produto);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o nproduto não existe na tabela dos produtos
                    throw new Exception("O produto não existe.");
                }
                //mostrar os dados produto
                lbIDProduto.Text = dados.Rows[0]["id_produto"].ToString();
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                imgCapa.ImageUrl = @"~\Public\Imagens\" + id_produto + ".jpg";
                imgCapa.Width = 300;
            }
            catch
            {
                Response.Redirect("~/Admin/Produtos/Produtos.aspx");
            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Produtos/Produtos.aspx");

        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int id_produto = int.Parse(Request["id_produto"].ToString());
                Models.Produtos lv = new Models.Produtos();
                lv.removerProduto(id_produto);

                //apagar a capa
                string ficheiro = Server.MapPath(@"~\Public\Imagens\") + id_produto + ".jpg";
                if (File.Exists(ficheiro))
                    File.Delete(ficheiro);

                lbErro.Text = "O produto foi removido com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Produtos.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/Produtos/Produtos.aspx");

            }
        }
    }
}