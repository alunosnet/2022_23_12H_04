using MOD15_Projeto.DarMedicamento;
using MOD15_Projeto.Familiares;
using MOD15_Projeto.Idosos;
using MOD15_Projeto.Medicamentos;
using MOD15_Projeto.Visistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOD15_Projeto
{
    public partial class Form1 : Form
    {
        BaseDados bd = new BaseDados("M15_BD_Recuperacao");
        public Form1()
        {
            InitializeComponent();
        }

        private void familiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Familiar familiar = new F_Familiar(bd);
            familiar.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void idosoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Idoso idoso = new F_Idoso(bd);
            idoso.Show();
        }

        private void visitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Visita visita = new F_Visita(bd);
            visita.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void visitaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            F_Ver ver = new F_Ver(bd);
            ver.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void númeroDeVisitasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void adicionarMedicamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Medicamento medicamento = new F_Medicamento(bd);
            medicamento.Show();
        }

        private void darMedicamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_MedicaIdoso medicaidoso = new F_MedicaIdoso(bd);
            medicaidoso.Show();
        }
    }
}
