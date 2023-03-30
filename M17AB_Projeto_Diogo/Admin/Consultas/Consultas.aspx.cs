using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.Admin.Consultas
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
                Response.Redirect("~/index.aspx");

            AtualizaGrelhaConsulta();
        }

        protected void ddConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrelhaConsulta();

        }

        private void AtualizaGrelhaConsulta()
        {
            gvConsultas.Columns.Clear();
            int iconsulta = int.Parse(ddConsultas.SelectedValue);
            DataTable dados;
            string sql = "";
            switch (iconsulta)
            {
                //TOP DE IDOSOS MAIS VISITADOS
                case 0:
                    sql = @"SELECT Nome_Idoso,count(Visitas.id_idoso) as [Nº de Visitas] FROM Idosos 
                            INNER JOIN Visitas ON Idosos.ID_Idoso=Visitas.id_idoso 
                            GROUP BY Visitas.id_idoso,Nome_Idoso
                            ORDER BY count(Visitas.id_idoso) DESC";
                    break;
                //TOP DE Utilizadores   
                case 1:
                    sql = @"SELECT count(id) as [Nº de Pessoas Registadas] FROM Utilizadores";
                    break;
                //Top de livros mais requisitados do último mês
                case 2:
                    sql = @"SELECT MONTH(DataVisita) as [Mês],Count(ID_Visita) as [Nº de Visitas] 
                            FROM Visitas
                            GROUP BY MONTH(DataVisita)";
                    break;
            }
            BaseDados bd = new BaseDados();
            dados = bd.devolveSQL(sql);
            gvConsultas.DataSource = dados;
            gvConsultas.DataBind();
        }
    }
}