using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.User.Visitas
{
    public partial class visitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            ConfigurarGrid();
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvidosos.Columns.Clear();
            gvidosos.DataSource = null;
            gvidosos.DataBind();

            Models.Idosos idosos = new Models.Idosos();
            gvidosos.DataSource = idosos.listaIdososDisponiveis();

            //botão reservar
            ButtonField bt = new ButtonField();
            bt.HeaderText = "Reservar";
            bt.Text = "Reservar";
            bt.ButtonType = ButtonType.Button;
            bt.CommandName = "Reservar";
            bt.ControlStyle.CssClass = "btn btn-danger";
            gvidosos.Columns.Add(bt);

            gvidosos.DataBind();
        }


        private void ConfigurarGrid()
        {
            gvidosos.RowCommand += Gvidosos_RowCommand;
        }

        private void Gvidosos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = int.Parse(e.CommandArgument.ToString());
            int id_idoso = int.Parse(gvidosos.Rows[linha].Cells[1].Text);
            int id_utilizador = int.Parse(Session["ID"].ToString());
            if (e.CommandName == "Reservar")
            {
                Models.Visitas vis = new Models.Visitas();
                vis.adicionarReserva(id_idoso, id_utilizador, DateTime.Now);
                AtualizarGrid();
            }
        }
    }


}