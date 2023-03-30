using M17AB_Projeto_Diogo.Models;
using M17AB_Projeto_Diogo.Classes;
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
    public partial class Utilizadores : System.Web.UI.Page
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
            AtualizarCCIdosos();
            AtualizarGrid();
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
                string nome = tb_nome.Text;
                if (nome.Trim().Length < 3)
                {
                    throw new Exception("O nome é muito pequeno.");
                }
                string nif = tb_nif.Text;
                if (nif.Trim().Length != 9)
                {
                    throw new Exception("O NIF tem de conter somente 9 caracteres");
                }
                string morada = tb_morada.Text;
                if (morada.Trim().Length < 4)
                {
                    throw new Exception("A morada tem de conter pelo menos 4 caracteres");

                }
                string email = tb_email.Text;
                if (email.Contains("@") == false || email.Contains(".") == false)
                {
                    throw new Exception("Falta o @ ou o '.' ");
                }

                string password = tb_password.Text;
                if (!Regex.IsMatch(password, @"[0-9]+"))
                {
                    throw new Exception("A senha deve conter pelo menos um número.");
                }

                int perfil = int.Parse(dd_perfil.SelectedValue);
                if (perfil == -1)
                {
                    throw new Exception("Deve selecionar um perfil");
                }
                string relacao = tb_relacao.Text;
                if(relacao.Trim().Length < 2 )
                {
                    throw new Exception("A Relação do Familiar deve conter 3 caracteres ou mais");

                }

                Random rnd = new Random();
                int sal = rnd.Next(1000);
                Utilizador utilizador = new Utilizador();   
                utilizador.nome = nome;
                utilizador.email = email;
                utilizador.sal = sal;
                utilizador.morada = morada;
                utilizador.nif = nif;
                utilizador.password = password;
                utilizador.perfil = perfil;
                utilizador.RelacaoFamiliar = relacao;
                utilizador.ID_Idoso = int.Parse(dd_idoso.SelectedValue);
                utilizador.Adicionar();
            }
            catch (Exception ex)
            {
                lb_erro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
            tb_email.Text = "";
            tb_morada.Text = "";
            tb_nif.Text = "";
            tb_nome.Text = "";
            tb_relacao.Text = "";

            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvUtilizador.Columns.Clear();
            Utilizador uz = new Utilizador();
            DataTable dados = uz.ListaTodosUtilizadores();

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            DataColumn dcApagar = new DataColumn();
            dcApagar.ColumnName = "Apagar";
            dcApagar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcApagar);

            //colunas da gridview
            gvUtilizador.DataSource = dados;
            gvUtilizador.AutoGenerateColumns = false;

            //Editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarUtilizador.aspx?id={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id" };
            gvUtilizador.Columns.Add(hlEditar);
            //Apagar
            HyperLinkField hlApagar = new HyperLinkField();
            hlApagar.HeaderText = "Apagar";
            hlApagar.DataTextField = "Apagar";
            hlApagar.Text = "Apagar...";
            hlApagar.DataNavigateUrlFormatString = "ApagarUtilizador.aspx?id={0}";
            hlApagar.DataNavigateUrlFields = new string[] { "id" };
            gvUtilizador.Columns.Add(hlApagar);
            //nlivro
            BoundField bfid = new BoundField();
            bfid.HeaderText = "ID";
            bfid.DataField = "ID";
            gvUtilizador.Columns.Add(bfid);
            //nome
            BoundField bfnome = new BoundField();
            bfnome.HeaderText = "Nome";
            bfnome.DataField = "nome";
            gvUtilizador.Columns.Add(bfnome);
            //Email
            BoundField bfemail = new BoundField();
            bfemail.HeaderText = "Email";
            bfemail.DataField = "email";
            gvUtilizador.Columns.Add(bfemail);

            //Morada
            BoundField bfmorada = new BoundField();
            bfmorada.HeaderText = "Morada";
            bfmorada.DataField = "Morada";
            gvUtilizador.Columns.Add(bfmorada); 
            //Autor
            BoundField bfnif = new BoundField();
            bfnif.HeaderText = "Nif";
            bfnif.DataField = "Nif";
            gvUtilizador.Columns.Add(bfnif);
            //=
            BoundField bfrelacao = new BoundField();
            bfrelacao.HeaderText = "RelacaoFamiliar";
            bfrelacao.DataField = "RelacaoFamiliar";
            gvUtilizador.Columns.Add(bfrelacao);
            //ID_Idoso
            BoundField bfid_idoso = new BoundField();
            bfid_idoso.HeaderText = "ID_Idoso";
            bfid_idoso.DataField = "ID_Idoso";
            gvUtilizador.Columns.Add(bfid_idoso);


            gvUtilizador.DataBind();
        }
    }
}