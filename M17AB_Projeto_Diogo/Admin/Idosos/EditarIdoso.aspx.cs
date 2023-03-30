using M17AB_Projeto_Diogo.Admin.Utilizadores;
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
    public partial class EditarIdoso : System.Web.UI.Page
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
                int id = int.Parse(Request["ID_Idoso"].ToString());

                Models.Idosos idosos = new Models.Idosos();
                DataTable dados = idosos.devolveDadosIdoso(id);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o id não existe na tabela dos idosos
                    throw new Exception("O Idoso não existe");
                }
                tbNome.Text = dados.Rows[0]["Nome_Idoso"].ToString();
                tbDoencas.Text = dados.Rows[0]["doencas"].ToString();
                tbNif.Text = dados.Rows[0]["nif_idoso"].ToString();
                tbNUtenteSaude.Text = dados.Rows[0]["NUtenteSaude"].ToString();
                tbData.Text = DateTime.Parse(dados.Rows[0]["Data_Nasc"].ToString()).ToString("yyyy-MM-dd");

            }
            catch
            {
                //Ver aqui
                Response.Redirect("~/Admin/Idosos/Idosos.aspx");
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
                    throw new Exception("NIF Inválido.");
                }
                string nutente = tbNUtenteSaude.Text;
                if (nutente.Trim().Length != 9)
                {
                    throw new Exception("Número de Utente de Saúde Inválido.");
                }
                DateTime data = DateTime.Parse(tbData.Text);
                if (data > DateTime.Now)
                {
                    throw new Exception("A data tem de ser inferior à data atual");
                }
                string doencas = tbDoencas.Text;
                if (doencas.Trim().Length < 3)
                {
                    throw new Exception("Doenças Inválidas");
                }

                Models.Idosos idoso = new Models.Idosos();
                idoso.Nome_Idoso = nome;
                idoso.NIF_Idoso = nif;
                idoso.NUtenteSaude = nutente;
                idoso.Data_Nasc = data;
                idoso.Doencas = doencas;
                idoso.estado = 1;
                idoso.ID_Idoso = int.Parse(Request["ID_Idoso"].ToString());
                idoso.atualizaIdoso();

                lbErro.Text = "O Idoso foi atualizado com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('Idosos.aspx')", true);
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
        }           
    }
}