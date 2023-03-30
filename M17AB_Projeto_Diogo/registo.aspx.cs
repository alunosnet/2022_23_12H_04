using M17AB_Projeto_Diogo.Classes;
using M17AB_Projeto_Diogo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo
{
    public partial class registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizarCCIdosos();
        }
        private void AtualizarCCIdosos()
        {
            Models.Idosos i = new Models.Idosos();
            dd_idoso.Items.Clear();
            DataTable dados = i.ListaTodosIdosos();
            foreach (DataRow linha in dados.Rows)
            {
                dd_idoso.Items.Add(
                    new ListItem(linha["nome_idoso"].ToString(), linha["ID_Idoso"].ToString()));

            }
        }
        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                // validar os dados do form
                string nome = tb_nome.Text;
                string email = tb_email.Text;
                string morada = tb_morada.Text;
                string nif = tb_nif.Text;
                string palavra_pass = tb_password.Text;
                int perfil = 1;
                string relacao = tb_relacao.Text;

                //validar o recaptcha
                var respostaRecaptcha = Request.Form["g-Recaptcha-Response"];
                var valido = ReCaptcha.Validate(respostaRecaptcha);
                if (valido == false)
                {
                    throw new Exception("Tem de provar que não é um robot");
                }

                //inserir o utilizador na bd
                Models.Utilizador utilizador = new Models.Utilizador();
                utilizador.nif = nif;
                utilizador.email = email;
                utilizador.nome = nome;
                utilizador.morada = morada;
                utilizador.password = palavra_pass;
                utilizador.perfil = perfil;
                utilizador.RelacaoFamiliar = relacao;
                utilizador.ID_Idoso = int.Parse(dd_idoso.SelectedValue);
                Random rnd = new Random();
                utilizador.sal = rnd.Next(9999); //Isto devia estar na função adicionar
                utilizador.Adicionar();
                lb_erro.Text = "Registo com sucesso";

                //redirecionar para index
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/index.aspx')", true);
            }
            catch(Exception erro)
            {
                lb_erro.Text = erro.Message;  
            }
        }
    }
}