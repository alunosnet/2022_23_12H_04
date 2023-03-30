using M17AB_Projeto_Diogo.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_Projeto_Diogo.Admin.Idosos
{
    public partial class Idosos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar Sessão

            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");

            }
            if (!IsPostBack)
            {
                AtualizarGrid();
            }
        }

        private void AtualizarGrid()
        {
            gvIdosos.Columns.Clear();
            Models.Idosos idosos = new Models.Idosos();
            DataTable dados = idosos.ListaTodosIdosos();

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            DataColumn dcApagar = new DataColumn();
            dcApagar.ColumnName = "Apagar";
            dcApagar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcApagar);

            //colunas da gridview
            gvIdosos.DataSource = dados;
            gvIdosos.AutoGenerateColumns = false;

            //Editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarIdoso.aspx?id_idoso={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "id_idoso" };
            gvIdosos.Columns.Add(hlEditar);
            //Apagar
            HyperLinkField hlApagar = new HyperLinkField();
            hlApagar.HeaderText = "Apagar";
            hlApagar.DataTextField = "Apagar";
            hlApagar.Text = "Apagar...";
            hlApagar.DataNavigateUrlFormatString = "ApagarIdoso.aspx?id_idoso={0}";
            hlApagar.DataNavigateUrlFields = new string[] { "id_idoso" };
            gvIdosos.Columns.Add(hlApagar);
            //nlivro
            BoundField bfnlivro = new BoundField();
            bfnlivro.HeaderText = "Nº do Idoso";
            bfnlivro.DataField = "id_idoso";
            gvIdosos.Columns.Add(bfnlivro);
            //nome
            BoundField bfnome = new BoundField();
            bfnome.HeaderText = "Nome_Idoso";
            bfnome.DataField = "nome_idoso";
            gvIdosos.Columns.Add(bfnome);
            //ano
            BoundField bfnif = new BoundField();
            bfnif.HeaderText = "Nif_Idoso";
            bfnif.DataField = "Nif_Idoso";
            gvIdosos.Columns.Add(bfnif);
            //data aquisição
            BoundField bfdata = new BoundField();
            bfdata.HeaderText = "Data_Nasc";
            bfdata.DataField = "data_Nasc";
            bfdata.DataFormatString = "{0:dd-MM-yyyy}";
            gvIdosos.Columns.Add(bfdata);
            //Doenças
            BoundField bfdoencas = new BoundField();
            bfdoencas.HeaderText = "Doencas";
            bfdoencas.DataField = "doencas";
            gvIdosos.Columns.Add(bfdoencas);
            //Autor
            BoundField bfutente = new BoundField();
            bfutente.HeaderText = "NUtenteSaude";
            bfutente.DataField = "NUtenteSaude";
            gvIdosos.Columns.Add(bfutente);
            //Estado
            BoundField bfestado = new BoundField();
            bfestado.HeaderText = "Estado";
            bfestado.DataField = "estado";
            gvIdosos.Columns.Add(bfestado);

            gvIdosos.DataBind();
        }

        protected void bt_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNomeIdoso.Text;
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
                int id_idoso = idoso.Adicionar();

            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
            //limpar form

            tbNomeIdoso.Text = "";
            tbNUtenteSaude.Text = "";
            tbDoencas.Text = "";
            tbNif.Text = "";
            tbData.Text = DateTime.Now.ToShortDateString();
            //atualizar grid
            AtualizarGrid();
        }
    }
}