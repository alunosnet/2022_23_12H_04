using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.User.Visitas
{
    public partial class historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            AtualizarGrid();
            AtualizarGridCompras();
        }

        private void AtualizarGrid()
        {
            gvhistorico.Columns.Clear();
            gvhistorico.DataSource = null;
            gvhistorico.DataBind();

            int idutilizador = int.Parse(Session["ID"].ToString());
            Models.Visitas vis = new Models.Visitas();
            gvhistorico.DataSource = vis.listaTodosVisitasComNomes(idutilizador);
            gvhistorico.DataBind();

        }

        private void AtualizarGridCompras()
        {
            gvcompras.Columns.Clear();
            gvcompras.DataSource = null;
            gvcompras.DataBind();

            int id = int.Parse(Session["ID"].ToString());
            Models.Compras compras = new Models.Compras();
            gvcompras.DataSource = compras.listaTodosComprasComNomes(id);
            gvcompras.DataBind();

        }
    }
}