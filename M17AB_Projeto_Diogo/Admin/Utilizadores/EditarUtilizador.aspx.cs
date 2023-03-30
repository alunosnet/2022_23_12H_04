using M17AB_Projeto_Diogo.Classes;
using M17AB_Projeto_Diogo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M17AB_Projeto_Diogo.Admin.Utilizadores
{
    public partial class EditarUtilizador : System.Web.UI.Page
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
            //AtualizarCCIdosos();
            try
            {
                //querystring id
                int id = int.Parse(Request["id"].ToString());

                Utilizador uz = new Utilizador();
                DataTable dados = uz.devolveDadosUtilizador(id);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o id não existe na tabela dos utilizadores
                    throw new Exception("O Utilizador não existe");
                }
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbMorada.Text = dados.Rows[0]["morada"].ToString();
                tbNif.Text = dados.Rows[0]["nif"].ToString();
                tbEmail.Text = dados.Rows[0]["email"].ToString();
                tbRelacao.Text = dados.Rows[0]["RelacaoFamiliar"].ToString();

            }
            catch
            {
                Response.Redirect("~/Admin/Utilizadores.Utilizadores.aspx");
            }
        }



        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text;
                if (nome.Trim().Length < 3)
                {
                    throw new Exception("O nome é muito pequeno.");
                }
                string nif = tbNif.Text;
                if (nif.Trim().Length != 9)
                {
                    throw new Exception("O NIF tem de conter somente 9 caracteres");
                }
                string morada = tbMorada.Text;
                if (morada.Trim().Length < 4)
                {
                    throw new Exception("A morada tem de conter pelo menos 4 caracteres");

                }
                string email = tbEmail.Text;
                if (email.Contains("@") == false || email.Contains(".") == false)
                {
                    throw new Exception("Falta o @ ou o '.' ");
                }
                string relacao = tbRelacao.Text;
                if (relacao.Trim().Length < 3)
                {
                    throw new Exception("A Relação do Familiar deve conter 3 caracteres ou mais");

                }

                Utilizador utilizador = new Utilizador();

                utilizador.nome = nome;
                utilizador.morada = morada;
                utilizador.nif = nif;
                utilizador.email = email;
                utilizador.RelacaoFamiliar = relacao;
                utilizador.id = int.Parse(Request["ID"].ToString());
                utilizador.atualizarUtilizador();

                lbErro.Text = "O Utilizador foi atualizado com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Utilizadores.aspx')", true);
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
            }
        }




        //private void AtualizarCCIdosos()
        //{
        //    Models.Idosos i = new Models.Idosos();
        //    dd_Idoso.Items.Clear();
        //    DataTable dados = i.ListaTodosIdosos();
        //    foreach (DataRow linha in dados.Rows)
        //    {
        //        dd_Idoso.Items.Add(
        //            new ListItem(linha["nome_idoso"].ToString(), linha["ID_Idoso"].ToString()));

        //    }
        //}
    }
}