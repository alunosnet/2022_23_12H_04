using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.Admin.Visitas
{
    public partial class EditarVisita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar Sessão

            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");

            }
            if (IsPostBack)
                return;

            try
            {
                //querystring id
                int id = int.Parse(Request["ID_Visita"].ToString());

                Models.Visitas vs = new Models.Visitas();
                DataTable dados = vs.devolveDadosVisita(id);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o id não existe na tabela dos idosos
                    throw new Exception("A Visita não existe");
                }
                tbData.Text = DateTime.Parse(dados.Rows[0]["DataVisita"].ToString()).ToString("yyyy-MM-dd");

            }
            catch
            {
                //Ver aqui
                Response.Redirect("~/Admin/Visitas/Visitas.aspx");
            }
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
            
                DateTime data = DateTime.Parse(tbData.Text);
                if (data > DateTime.Now)
                {
                    throw new Exception("A data tem de ser maior ou igual à data atual");
                }

                Models.Visitas visita = new Models.Visitas();
                visita.DataVisita = data;

                visita.ID_Visita = int.Parse(Request["ID_Visita"].ToString());
                visita.atualizaVisita();

                lbErro.Text = "A visita foi atualizado com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Visitas.aspx')", true);
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
        }
    }
}