using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOD15_Projeto.Medicamentos
{
    public partial class F_Medicamento : Form
    {
        string fotografia;
        BaseDados bd;
        int id_medicamento_escolhido;
        public F_Medicamento(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizarDGV();
        }

         void AtualizarDGV()
        {
            dgvMedicamentos.DataSource = Medicamento.ListarTodos(bd);
            dgvMedicamentos.AllowUserToAddRows = false;
            dgvMedicamentos.AllowUserToDeleteRows = false;
            dgvMedicamentos.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.InitialDirectory = "c:\\";
            ficheiro.Filter = "Imagens |*.jpg;*.png | Todos os ficheiros |*.*";
            ficheiro.Multiselect = false;
            if (ficheiro.ShowDialog() == DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    pbFotografia.Image = Image.FromFile(temp);
                    fotografia = temp;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nome = tbNome.Text;
            if (nome == "" || nome.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNome.Focus();
                return;
            }
            string contra = tbContra.Text;
            if (contra == "" || contra.Length < 5)
            {
                MessageBox.Show("As contra indicações têm de ter mais de 3 caracteres");
                tbContra.Focus();
                return;
            }
            if (String.IsNullOrEmpty(fotografia))
            {
                MessageBox.Show("Tem de selecionar uma fotografia!");
                return;
            }
            Medicamento medicamento = new Medicamento(0, tbNome.Text, Utils.ImagemParaVetor(fotografia), tbContra.Text);

            medicamento.ID_Medicamento = id_medicamento_escolhido;
            medicamento.Nome = tbNome.Text;
            medicamento.Contra = tbContra.Text;
            medicamento.Guardar(bd);

            LimparForm();
            AtualizarDGV();

        }

        private void LimparForm()
        {
            tbNome.Text = "";
            tbContra.Text = "";
            pbFotografia.Image = null;
            fotografia = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparForm();

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            Medicamento.Apagar(bd, id_medicamento_escolhido);
            AtualizarDGV();
            btnLimpar_Click(sender, e);
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string nome = tbNome.Text;
            if (nome == "" || nome.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNome.Focus();
                return;
            }
            string contra = tbContra.Text;
            if (contra == "" || contra.Length < 5)
            {
                MessageBox.Show("As contra indicações têm de ter mais de 3 caracteres");
                tbContra.Focus();
                return;
            }
            //if (String.IsNullOrEmpty(fotografia))
            //{
            //    MessageBox.Show("Tem de selecionar uma fotografia!");
            //    return;
            //}

            Medicamento medicamento = new Medicamento();
            medicamento.ID_Medicamento = id_medicamento_escolhido;
            medicamento.Nome = tbNome.Text;
            medicamento.Contra = tbContra.Text;
            if (fotografia != null && fotografia != "")
            {
                //verificar se o ficheiro existe
                medicamento.Fotografia = Utils.ImagemParaVetor(fotografia);
            }
            medicamento.Atualizar(bd);
            btnLimpar_Click(sender, e);
            AtualizarDGV();
        }

        private void pbFotografia_Click(object sender, EventArgs e)
        {

        }

        private void dgvMedicamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selecionar e mostrar os dados do leitor
            int linha = dgvMedicamentos.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int id_medicamento = int.Parse(dgvMedicamentos.Rows[linha].Cells[0].Value.ToString());
            Medicamento medicamento = new Medicamento();
            medicamento.ProcurarPorMedicamento(bd, id_medicamento);
            tbNome.Text = medicamento.Nome;
            tbContra.Text = medicamento.Contra;

            string ficheiro = System.IO.Path.GetTempPath() + @"\imagem.jpg";
            Utils.VetorParaImagem(medicamento.Fotografia, ficheiro);
            Image img;
            using (var bitmap = new Bitmap(ficheiro))
            {
                img = new Bitmap(bitmap);
                pbFotografia.Image = img;
            }
            //Guardar o nleitor
            id_medicamento_escolhido = id_medicamento;
        }
    }
}
