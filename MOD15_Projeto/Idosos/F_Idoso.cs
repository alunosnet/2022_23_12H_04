using MOD15_Projeto.Familiares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOD15_Projeto.Idosos
{
    public partial class F_Idoso : Form
    {
        BaseDados bd;
        int id_idoso_escolhido;
        public F_Idoso(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizarDGV();
            tbIdade.Visible = false;
            label4.Visible = false;
        }

        void AtualizarDGV()
        {
            dgvIdoso.DataSource = Idoso.ListarTodos(bd);
            dgvIdoso.AllowUserToAddRows = false;
            dgvIdoso.AllowUserToDeleteRows = false;
            dgvIdoso.ReadOnly = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nome_idoso = tbNomeIdoso.Text;
            if (nome_idoso == "" || nome_idoso.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNomeIdoso.Focus();
                return;
            }
            string nif_idoso = tbNifIdoso.Text;
            if (nif_idoso == "" || nif_idoso.Length != 9)
            {
                MessageBox.Show("O NIF tem de 9 caracteres");
                tbNifIdoso.Focus();
                return;
            }

            DateTime data_nasc = dtData_Nasc.Value;
            if (data_nasc.Date.Year >= 1970)
            {
                MessageBox.Show("A data de nascimento tem maior ou igual a 1970");
                dtData_Nasc.Focus();
                return;
            }

            string doencas = tbDoencas.Text;
            if (doencas == "")
            {
                MessageBox.Show("O campo doenças tem de tar preenchido");
                tbDoencas.Focus();
                return;
            }
            string nutentesaude = tbUtenteSaude.Text;
            if (nutentesaude == "" || nutentesaude.Length != 9)
            {
                MessageBox.Show("O número de Utente de Saúde tem de ter 9 caracteres");
                tbUtenteSaude.Focus();
                return;
            }
            string idade = tbIdade.Text;





            Idoso idoso = new Idoso();
            idoso.Nome_Idoso = nome_idoso;
            idoso.NIF_Idoso = nif_idoso;
            idoso.Data_Nasc = data_nasc;
            idoso.Doencas = doencas;
            idoso.NUtenteSaude = nutentesaude;
            idoso.Idade = idade;


            idoso.Guardar(bd);
            LimparForm();
            AtualizarDGV();
            tbIdade.Visible = false;
            label4.Visible = false;
        }

        private void LimparForm()
        {
            tbNomeIdoso.Text = "";
            tbNifIdoso.Text = "";
            tbUtenteSaude.Text = "";
            tbDoencas.Text = "";
            dtData_Nasc.Value = DateTime.Now;
            tbIdade.Text = "";

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            ApagarIdoso();
        }

        private void ApagarIdoso()
        {
            if (id_idoso_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar um Idoso");
                return;
            }
            if (MessageBox.Show("Tem a certeza que pretende eliminar o Idoso selecionado?",
                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Idoso.ApagarIdoso(bd, id_idoso_escolhido);
            }

            LimparForm();
            AtualizarDGV();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparForm();
        }

        private void dgvIdoso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgvIdoso.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int id_idoso = int.Parse(dgvIdoso.Rows[linha].Cells[0].Value.ToString());
            Idoso selecionado = new Idoso();

            tbIdade.Visible = true;
            label4.Visible = true;
            tbIdade.Enabled = false;

            selecionado.Procurar(id_idoso, bd);
            tbNomeIdoso.Text = selecionado.Nome_Idoso;
            tbNifIdoso.Text = selecionado.NIF_Idoso;
            tbUtenteSaude.Text = selecionado.NUtenteSaude;
            tbDoencas.Text = selecionado.Doencas;
            dtData_Nasc.Value = selecionado.Data_Nasc;
            id_idoso_escolhido = selecionado.ID_Idoso;
            tbIdade.Text = selecionado.Idade;

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string nome_idoso = tbNomeIdoso.Text;
            if (nome_idoso == "" || nome_idoso.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNomeIdoso.Focus();
                return;
            }
            string nif_idoso = tbNifIdoso.Text;
            if (nif_idoso == "" || nif_idoso.Length != 9)
            {
                MessageBox.Show("O NIF tem de 9 caracteres");
                tbNifIdoso.Focus();
                return;
            }

            DateTime data_nasc = dtData_Nasc.Value;
            if (data_nasc > DateTime.Now)
            {
                MessageBox.Show("A data de nascimento tem de ser inferior à Data Atual");
                dtData_Nasc.Focus();
                return;
            }

            string doencas = tbDoencas.Text;
            if (doencas == "")
            {
                MessageBox.Show("O campo doenças tem de tar preenchido");
                tbDoencas.Focus();
                return;
            }
            string nutentesaude = tbUtenteSaude.Text;
            if (nutentesaude == "" || nutentesaude.Length != 9)
            {
                MessageBox.Show("O número de Utente de Saúde tem de ter 9 caracteres");
                tbUtenteSaude.Focus();
                return;
            }

            string idade = tbIdade.Text;




            Idoso idoso = new Idoso();
            idoso.ID_Idoso = id_idoso_escolhido;
            idoso.Nome_Idoso = nome_idoso;
            idoso.NIF_Idoso = nif_idoso;
            idoso.Data_Nasc = data_nasc;
            idoso.Doencas = doencas;
            idoso.NUtenteSaude = nutentesaude;
            idoso.Idade = idade;

            idoso.Atualizar(bd);

            AtualizarDGV();
            tbIdade.Visible = true;
            label4.Visible = true;
            tbIdade.Enabled = false;
            label4.Enabled = false;
        }

        private void tbPesquisa_TextChanged(object sender, EventArgs e)
        {
            dgvIdoso.DataSource = Idoso.PesquisaIdoso(bd, tbPesquisa.Text);
        }

        private void F_Idoso_Load(object sender, EventArgs e)
        {

        }
    }
}
