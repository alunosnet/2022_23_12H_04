using M17AB_Projeto_Diogo.Classes;
using M17AB_Projeto_Diogo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.Admin.Utilizadores
{
    public partial class ApagarUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar Sessão

            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");

            }
            try
            {
                //querystring nlivro
                int id = int.Parse(Request["id"].ToString());

                Utilizador uz = new Utilizador();
                DataTable dados = uz.devolveDadosUtilizador(id);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o nlivro não existe na tabela dos livros
                    throw new Exception("O utilizador não existe");
                }
                //Mostrar os dados do livro
                lbIDUtilizador.Text = dados.Rows[0]["id"].ToString();
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                

            }
            catch
            {
                Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");
            }
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Utilizador uz = new Utilizador();
                uz.removerUtilizador(id);
                //apagar a capa
             
                //Response.Redirect("~/Admin/Livros/livros.aspx");
                lbErro.Text = "O utilizador foi removido com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Utilizadores.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/Utilizadores/utilizadores.aspx");
            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Utilizadores/Utilizadores.aspx");
        }
    }
}