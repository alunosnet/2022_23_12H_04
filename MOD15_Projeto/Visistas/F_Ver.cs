using MOD15_Projeto.Idosos;
using MOD15_Projeto.Visistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MOD15_Projeto
{
    public partial class F_Ver : Form
    {
        BaseDados bd;
        int id_visita_escolhida;
        public F_Ver(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            Juntar();
            AtualizarDGV();
        }

        void AtualizarDGV()
        {
            dgvVer.DataSource = Visita.ListarTodos(bd);
            dgvVer.AllowUserToAddRows = false;
            dgvVer.AllowUserToDeleteRows = false;
            dgvVer.ReadOnly = true;


        }



        private void Juntar()
        {

            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void F_Ver_Load(object sender, EventArgs e)
        {

        }

        private void btnVisitas_Click(object sender, EventArgs e)
        {
            dgvNrVisitas.Visible = true;
            dgvVer.Visible = false;
            string sql = @"SELECT Nome_Idoso,count(*) as [Nr de Visitas] FROM Visitas 
                           INNER JOIN Familiar ON 
                           Visitas.ID_Familiar = Familiar.ID_Familiar
                           INNER JOIN Idoso ON
                           Visitas.ID_Idoso = Idoso.ID_Idoso
                           GROUP By Idoso.Nome_Idoso
                           ORDER BY count(*) DESC";

            dgvNrVisitas.DataSource = bd.DevolveSQL(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvNrVisitas.Visible = false;
            dgvVer.Visible = true;
            string sql = @"SELECT* FROM Visitas";

            dgvVer.DataSource = bd.DevolveSQL(sql);
            
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM VISITAS WHERE ID_Visita=" + id_visita_escolhida;
            bd.ExecutaSQL(sql);
            AtualizarDGV();

        }

        private void dgvVer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVer.RowCount == 0)
            {

            }
            else
            {
                int linha = dgvVer.CurrentCell.RowIndex;
                if (linha == -1)
                {
                    return;
                }
                int idvisita = int.Parse(dgvVer.Rows[linha].Cells[0].Value.ToString());

                Visita vis = new Visita();
                vis.ProcurarPorIdVisita(bd, idvisita);

                label1.Text = vis.ID_Idoso.ToString();
                label2.Text = vis.ID_Familiar.ToString();
                dateTimePicker1.Value = vis.DataVisita;

                id_visita_escolhida = vis.ID_Visita;

                btnAtualizar.Visible = true;
                dateTimePicker1.Visible = true;
                btnCancela.Visible = true;

            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value <= DateTime.Now.Date)
            {
                MessageBox.Show("Data tem de ser superior ao dia de hoje");
                return;
            }

            int linha = dgvVer.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int idvisita = int.Parse(dgvVer.Rows[linha].Cells[0].Value.ToString());
            id_visita_escolhida = idvisita;

            Visita vis = new Visita();
            vis.ProcurarPorIdVisita(bd, idvisita);

            vis.ID_Idoso = int.Parse(label1.Text);
            vis.ID_Familiar = int.Parse(label2.Text);
            vis.DataVisita = dateTimePicker1.Value;

            vis.Atualizar(bd);
            AtualizarDGV();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}


