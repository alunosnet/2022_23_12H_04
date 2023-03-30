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
    public partial class Visitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar Sessão

            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");

            }
            ConfigurarGrid();
            if (IsPostBack) return;

            AtualizarGrid();
            AtualizarDDFamiliares();
            AtualizarDDIdosos();

        }

        

        private void AtualizarDDFamiliares()
        {
            Utilizador u = new Utilizador();
            dd_familiar.Items.Clear();
            DataTable dados = u.ListaTodosUtilizadores();
            foreach (DataRow linha in dados.Rows)
            {
                dd_familiar.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString()));

            }
        }

        private void AtualizarDDIdosos()
        {
            Models.Idosos lv = new Models.Idosos();
            dd_idoso.Items.Clear();
            DataTable dados = lv.listaIdososDisponiveis();
            foreach (DataRow linha in dados.Rows)
            {
                dd_idoso.Items.Add(
                    new ListItem(linha["nome_idoso"].ToString(), linha["id_idoso"].ToString()));

            }
        }

        private void AtualizarGrid()
        {
            Models.Visitas visitas = new Models.Visitas();

            DataTable dados;
            if (cb_idosos_reservados.Checked)
                dados = visitas.listaTodasVisitasPorConcluirComNomes();
            else
                dados = visitas.listaTodasVisitasComNomes();
            gv_visitas.Columns.Clear();
            gv_visitas.DataSource = null;
            gv_visitas.DataBind();
            if (dados == null || dados.Rows.Count == 0) return;
            //botoes de comando
            //receber
            ButtonField bfReceber = new ButtonField();
            bfReceber.HeaderText = "Terminar";
            bfReceber.Text = "Terminar";
            bfReceber.ButtonType = ButtonType.Button;
            bfReceber.ControlStyle.CssClass = "btn btn-info";
            bfReceber.CommandName = "Terminar";
            gv_visitas.Columns.Add(bfReceber);

            ButtonField bfApagar = new ButtonField();
            bfApagar.HeaderText = "Cancelar";
            bfApagar.Text = "Cancelar";
            bfApagar.ButtonType = ButtonType.Button;
            bfApagar.ControlStyle.CssClass = "btn btn-danger";
            bfApagar.CommandName = "Cancelar";
            gv_visitas.Columns.Add(bfApagar);

            ButtonField bfEditar = new ButtonField();
            bfEditar.HeaderText = "Editar";
            bfEditar.Text = "Editar";
            bfEditar.ButtonType = ButtonType.Button;
            bfEditar.ControlStyle.CssClass = "btn btn-success";
            bfEditar.CommandName = "Editar";
            gv_visitas.Columns.Add(bfEditar);


            //enviar email

            //ButtonField bfEmail = new ButtonField();
            //bfEmail.HeaderText = "Enviar Email";
            //bfEmail.Text = "Email";
            //bfEmail.ButtonType = ButtonType.Button;
            //bfEmail.ControlStyle.CssClass = "btn btn-danger";
            //bfEmail.CommandName = "email";
            //gv_visitas.Columns.Add(bfEmail);

            gv_visitas.DataSource = dados;
            gv_visitas.AutoGenerateColumns = true;
            gv_visitas.DataBind();

        }

        private void ConfigurarGrid()
        {
            gv_visitas.AllowPaging = true;
            gv_visitas.PageSize = 5;
            gv_visitas.PageIndexChanging += Gv_visitas_PageIndexChanging;

            gv_visitas.RowCommand += Gv_visitas_RowCommand;
            //gv_visitas.RowDataBound += Gv_visitas_RowDataBound;
        }

        //private void Gv_visitas_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void Gv_visitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page") return;


            //Linha
            int linha = int.Parse(e.CommandArgument.ToString());

            //id da visita

            //Alterar isto quando adicionar um botão à grid view

            int id_visita = int.Parse(gv_visitas.Rows[linha].Cells[3].Text);

            Models.Visitas visitas = new Models.Visitas();

            if (e.CommandName == "Terminar")
            {
                //TODO: não permite receber idosos já recebidos
                visitas.alterarEstadoVisita(id_visita);
                AtualizarDDFamiliares();
                AtualizarDDIdosos();
                AtualizarGrid();
            }
            if(e.CommandName == "Cancelar")
            {
                Response.Redirect("ApagarVisita.aspx?id_visita="+ id_visita);
            }
            if( e.CommandName == "Editar")
            {
                Response.Redirect("EditarVisita.aspx?id_visita=" + id_visita);
            }
        }

        private void Gv_visitas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_visitas.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        protected void cb_idosos_reservados_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        protected void bt_registar_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Visitas emp = new Models.Visitas();
                int id_idoso = int.Parse(dd_idoso.SelectedValue);
                int id = int.Parse(dd_familiar.SelectedValue);
                DateTime data = DateTime.Parse(tb_data.Text);
                emp.adicionarVisita(id_idoso, id, data);
                lb_erro.Text = "A visita foi registado com sucesso";
                lb_erro.CssClass = "";

            }
            catch (Exception erro)
            {
                lb_erro.Text = "Ocorreu o seguinte erro:" + erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }

            AtualizarDDFamiliares();
            AtualizarDDIdosos();
            AtualizarGrid();
        }
    }
}