using M17AB_Projeto_Diogo.Classes;
using M17AB_Projeto_Diogo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.User
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (!IsPostBack)
            {
                divEditar.Visible = false;
                MostrarPerfil();
            }
        }
        void MostrarPerfil()
        {
            int id = int.Parse(Session["id"].ToString());
            Utilizador utilizador = new Utilizador();
            DataTable dados = utilizador.devolveDadosUtilizador(id);
            if (divPerfil.Visible == true)
            {
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbMorada.Text = dados.Rows[0]["morada"].ToString();
                lbnif.Text = dados.Rows[0]["nif"].ToString();
                lbEmail.Text = dados.Rows[0]["email"].ToString();
                lbrelacao.Text = dados.Rows[0]["RelacaoFamiliar"].ToString();
            }
            else
            {
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbMorada.Text = dados.Rows[0]["morada"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
                tbEmail.Text = dados.Rows[0]["email"].ToString();
                tbRelacao.Text = dados.Rows[0]["RelacaoFamiliar"].ToString();

            }
        }
        protected void btEditar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = false;
            divEditar.Visible = true;
            MostrarPerfil();
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["id"].ToString());
            string nome = tbNome.Text;
            string morada = tbMorada.Text;
            string nif = tbNif.Text;
            string email = tbEmail.Text;
            string relacao = tbRelacao.Text;
            //TODO: validar os dados
            Utilizador utilizador = new Utilizador();
            utilizador.nome = nome;
            utilizador.morada = morada;
            utilizador.nif = nif;
            utilizador.email = email;
            utilizador.RelacaoFamiliar = relacao;
            utilizador.id = id;
            utilizador.atualizarUtilizador();
            btCancelar_Click(sender, e);
        }
        protected void btCancelar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = true;
            divEditar.Visible = false;
            MostrarPerfil();
        }
    }
}