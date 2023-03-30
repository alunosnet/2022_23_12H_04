using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["perfil"] != null)
                divLogin.Visible = false;

            //ordenar os produtos?
            int? ordenar = 0;
            try
            {
                ordenar = int.Parse(Request["ordena"].ToString());
            }
            catch
            {
                ordenar = null;
            }
            //atualizar grelha produtos
            atualizaListaProdutos(null, ordenar);
            
        }

        private void atualizaListaProdutos(string pesquisa = null, int? ordena = null)
        {
            Models.Produtos produto = new Models.Produtos();
            DataTable dados = null;
            if (pesquisa == null)
            {
                if (Request["categoria"] == null)
                {
                    //se existir o cookie ultimo produto listar os produtos do mesmo comprador
                    HttpCookie httpCookie = Request.Cookies["ultimoproduto"];
                    if (httpCookie == null)
                        dados = produto.listaProdutosDisponiveis(ordena);
                }
                else
                {
                    pesquisa = Request["categoria"].ToString();
                    dados = produto.listaProdutosDisponiveisTipo(pesquisa, ordena);
                }
            }
            else
            {
                dados = produto.listaProdutosDisponiveis(pesquisa, ordena);
            }
            gerarIndex(dados);
        }

        private void gerarIndex(DataTable dados)
        {
            if (dados == null || dados.Rows.Count == 0)
            {
                divProdutos.InnerHtml = "";
                return;
            }
            string grelha = "<div class='container-fluid'>";
            grelha += "<div class='row'>";
            foreach (DataRow produtos in dados.Rows)
            {
                grelha += "<div class='col'>";
                grelha += "<img src='/Public/Imagens/" + produtos[0].ToString() +
                    ".jpg' class='img-fluid'/>";
                grelha += "<p/><span class='stat-title'>" + produtos[1].ToString()
                    + "</span>";
                grelha += "<span class='stat-title'>" +
                    String.Format(" | {0:C}", Decimal.Parse(produtos["preco"].ToString()))
                    + "</span>";
                grelha += "<br/><a href='detalhesproduto.aspx?id=" + produtos[0].ToString()
                    + "'>Detalhes</a>";
                grelha += "</div>";
            }
            grelha += "</div></div>";
            divProdutos.InnerHtml = grelha;
        }


        protected void btPesquisar_Click(object sender, EventArgs e)
        {
            atualizaListaProdutos(tbPesquisa.Text);

        }

        protected void bt_recuperar_Click(object sender, EventArgs e)
        {
            //Fazer
        }

        protected void bt_login_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tb_Email.Text;
                string password = tb_Password.Text;
                UserLogin user = new UserLogin();
                DataTable dados = user.VerificaLogin(email, password);
                if (dados == null)
                    throw new Exception("Login falhou");
                //iniciar sessão
                Session["nome"] = dados.Rows[0]["nome"].ToString();
                Session["id"] = dados.Rows[0]["id"].ToString();
                //autorização
                Session["perfil"] = dados.Rows[0]["perfil"].ToString();
                Session["ip"] = Request.UserHostAddress;
                Session["useragent"] = Request.UserAgent;
                //Redirecionar
                if (Session["perfil"].ToString() == "0")
                    Response.Redirect("~/Admin/Admin.aspx");
                if (Session["perfil"].ToString() == "1")
                    Response.Redirect("~/User/User.aspx");
            }
            catch
            {
                lb_erro.Text = "Login falhou.Tente novamente";
            }
        }
    }
}