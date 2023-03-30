using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace MOD15_Projeto.Familiares
{
    public partial class F_Familiar : Form
    {
        BaseDados bd;
        int id_familiar_escolhido;
        public F_Familiar(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizarDGV();
        }
        void AtualizarDGV()
        {
            dgvFamiliar.DataSource = Familiar.ListarTodos(bd);
            dgvFamiliar.AllowUserToAddRows = false;
            dgvFamiliar.AllowUserToDeleteRows = false;
            dgvFamiliar.ReadOnly = true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validar os dados
            string nome = tbNome.Text;
            if (nome == "" || nome.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNome.Focus();
                return;
            }
            string nif = tbNIF.Text;
            if (nif == "" || nif.Length != 9)
            {
                MessageBox.Show("O NIF tem de 9 caracteres");
                tbNIF.Focus();
                return;
            }
            
            DateTime data_nasc = dtData_Nasc.Value;
            if (data_nasc > DateTime.Now)
            {
                MessageBox.Show("A data de nascimento tem de ser inferior à Data Atual");
                dtData_Nasc.Focus();
                return;
            }

            string email = tbEmail.Text;
            if (email == "" )//Fazer expressão 
            {
                MessageBox.Show("O email está incorreto");
                tbEmail.Focus();
                return;
            }

            string morada = tbMorada.Text;
            if (morada == "" || morada.Length < 5)
            {
                MessageBox.Show("A morada tem de conter mais de 5 caracteres");
                tbMorada.Focus();
                return;
            }
            string telemovel = tbTelemovel.Text;
            if (telemovel == "" || telemovel.Length != 9)
            {
                MessageBox.Show("O telemóvel tem de ter 9 caracteres");
                tbTelemovel.Focus();
                return;
            }

            string relacaofamiliar = tbRelacao.Text;
            if (relacaofamiliar == "" || relacaofamiliar.Length <= 3 )
            {
                MessageBox.Show("A Relação Familiar tem de conter mais de 3 caracteres");
                tbRelacao.Focus();
                return;
            }

            //Criar obj
            Familiar familiar = new Familiar();
            //Preencher as propriedades
            familiar.Nome = nome;
            familiar.NIF = nif;
            familiar.Email = email;
            familiar.Morada = morada;
            familiar.RelacaoFamiliar = relacaofamiliar;
            familiar.Telemovel = telemovel;
            familiar.Data_Nasc = data_nasc;

            //Guardar na BD
            familiar.Guardar(bd);
            //Limpar o form
            LimparForm();
            AtualizarDGV();
        
        }

        private void LimparForm()
        {
            tbNome.Text = "";
            tbNIF.Text = "";
            tbEmail.Text = "";
            tbMorada.Text = "";
            tbTelemovel.Text = "";
            tbRelacao.Text = "";
            dtData_Nasc.Value = DateTime.Now;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            ApagarDados();
            Familiar.ApagarFamiliar(bd, id_familiar_escolhido);

        
        }   

        private void ApagarDados()
        {
            if (id_familiar_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar um Visitante");
                return;
            }
            if (MessageBox.Show("Tem a certeza que pretende eliminar o Familiar selecionado?",
                "Confirmar",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Familiar.ApagarFamiliar(bd,id_familiar_escolhido);
            }

            LimparForm();
            AtualizarDGV();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparForm();
        }

        private void dgvFamiliar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button2.Visible = false;
            */

            int linha = dgvFamiliar.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int id_familiar = int.Parse(dgvFamiliar.Rows[linha].Cells[0].Value.ToString());
            Familiar escolhido = new Familiar();
            escolhido.Procurar(id_familiar, bd);
            tbNome.Text = escolhido.Nome;
            tbNIF.Text = escolhido.NIF;
            tbEmail.Text = escolhido.Email;
            tbMorada.Text = escolhido.Morada;
            tbTelemovel.Text = escolhido.Telemovel;
            tbRelacao.Text = escolhido.RelacaoFamiliar;
            dtData_Nasc.Value = escolhido.Data_Nasc;
            id_familiar_escolhido = escolhido.ID_Familiar;
 
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            //Validar os dados
            string nome = tbNome.Text;
            if (nome == "" || nome.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNome.Focus();
                return;
            }
            string nif = tbNIF.Text;
            if (nif == "" || nif.Length != 9)
            {
                MessageBox.Show("O NIF tem de 9 caracteres");
                tbNIF.Focus();
                return;
            }

            DateTime data_nasc = dtData_Nasc.Value;
            if (data_nasc > DateTime.Now)
            {
                MessageBox.Show("A data de nascimento tem de ser inferior à Data Atual");
                dtData_Nasc.Focus();
                return;
            }

            string email = tbEmail.Text;
            if (email == "") //Fazer Expressão
            {
                MessageBox.Show("O email está incorreto");
                tbEmail.Focus();
                return;
            }

            string morada = tbMorada.Text;
            if (morada == "" || morada.Length < 5)
            {
                MessageBox.Show("A morada tem de conter mais de 5 caracteres");
                tbMorada.Focus();
                return;
            }
            string telemovel = tbTelemovel.Text;
            if (telemovel == "" || telemovel.Length != 9)
            {
                MessageBox.Show("O telemóvel tem de ter 9 caracteres");
                tbTelemovel.Focus();
                return;
            }

            string relacaofamiliar = tbRelacao.Text;
            if (relacaofamiliar == "" || relacaofamiliar.Length <= 3)
            {
                MessageBox.Show("A Relação Familiar tem de conter mais de 3 caracteres");
                tbRelacao.Focus();
                return;
            }
            //validar o form

            Familiar familiar = new Familiar();
            familiar.ID_Familiar = id_familiar_escolhido;
            familiar.Nome = tbNome.Text;
            familiar.Data_Nasc = dtData_Nasc.Value;
            familiar.Email = tbEmail.Text;
            familiar.NIF = tbNIF.Text;
            familiar.Morada = tbMorada.Text;
            familiar.RelacaoFamiliar = tbRelacao.Text;
            familiar.Telemovel = tbTelemovel.Text;

           
            familiar.Atualizar(bd);
            
            AtualizarDGV();
        }

        private void dgvFamiliar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
