using M17AB_Projeto_Diogo.Classes;
using M17AB_Projeto_Diogo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.Admin.Idosos
{
    public partial class ApagarIdoso : System.Web.UI.Page
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
                int id = int.Parse(Request["ID_Idoso"].ToString());

                Models.Idosos idosos = new Models.Idosos();
                DataTable dados = idosos.devolveDadosIdoso(id);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o id_idoso não existe na tabela dos livros
                    throw new Exception("O Idoso não existe");
                }
                //Mostrar os dados do livro
                lbIDIdoso.Text = dados.Rows[0]["ID_Idoso"].ToString();
                lbNome.Text = dados.Rows[0]["Nome_Idoso"].ToString();


            }
            catch
            {
                Response.Redirect("~/Admin/Idosos/Idosos.aspx");
            }
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["ID_Idoso"].ToString());
                Models.Idosos idosos = new Models.Idosos();
                idosos.removerIdoso(id);
                //apagar a capa

                lbErro.Text = "O Idoso foi removido com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Idosos.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/Idosos/Idosos.aspx");
            }
        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Idosos/Idosos.aspx");

        }
    }
}