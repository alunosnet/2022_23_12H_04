using M17AB_Projeto_Diogo.Classes;
using M17AB_Projeto_Diogo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.Admin.Visitas
{
    public partial class ApagarVisita : System.Web.UI.Page
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
                int id_visita = int.Parse(Request["id_visita"].ToString());

                Models.Visitas vs = new Models.Visitas();
                DataTable dados = vs.devolveDadosVisita(id_visita);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o nlivro não existe na tabela dos livros
                    throw new Exception("A Visita não existe");
                }
                //Mostrar os dados do livro
                lbIDUtilizador.Text = dados.Rows[0]["id_visita"].ToString();
                lbNome.Text = dados.Rows[0]["id_idoso"].ToString();


            }
            catch
            {
                Response.Redirect("~/Admin/Visitas/Visitas.aspx");
            }
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int id_visita = int.Parse(Request["id_visita"].ToString());
                Models.Visitas vs = new Models.Visitas();
                vs.removerVisita(id_visita);

                lbErro.Text = "A visita foi removido com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Visitas.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/Visitas/Visitas.aspx");
            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Visitas/Visitas.aspx");

        }
    }
}