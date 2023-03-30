using MOD15_Projeto.Familiares;
using MOD15_Projeto.Idosos;
using MOD15_Projeto.Medicamentos;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MOD15_Projeto.DarMedicamento
{
    
    public partial class F_MedicaIdoso : Form
    {
        int id_idosomedica_escolhido;
        BaseDados bd;
        int nrlinhas, nrpagina;
        public F_MedicaIdoso(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizarCBIdosos();
            AtualizarCBMedicamentos();
            AtualizarDGV();
        }

        void AtualizarDGV()
        {
            dgvMedicaIdoso.DataSource = MedicaIdoso.ListarTodos(bd);
            dgvMedicaIdoso.AllowUserToAddRows = false;
            dgvMedicaIdoso.AllowUserToDeleteRows = false;
            dgvMedicaIdoso.ReadOnly = true;
        }

        private void AtualizarCBMedicamentos()
        {
            cbMedicamento.Items.Clear();
            DataTable dados = Medicamento.ListarMedicamentos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Medicamento medicamento = new Medicamento();
                medicamento.ID_Medicamento = int.Parse(dr["ID_Medicamento"].ToString());
                medicamento.Nome = dr["Nome"].ToString();
                cbMedicamento.Items.Add(medicamento);
            }
        }


        private void AtualizarCBIdosos()
        {
            cbIdoso.Items.Clear();
            DataTable dados = Idoso.ListarIdosos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Idoso idoso = new Idoso();
                idoso.ID_Idoso = int.Parse(dr["ID_Idoso"].ToString());
                idoso.Nome_Idoso = dr["Nome_Idoso"].ToString();
                cbIdoso.Items.Add(idoso);
            }
        }



        private void F_MedicaIdoso_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string dose = tbDose.Text;
            if (dose == "" || dose.Length > 2 )
            {
                MessageBox.Show("O número de doses por dia tem de conter apenas 2 caracteres");
                tbDose.Focus();
                return;
            }


            if (cbIdoso.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um idoso");
                return;
            }
            if (cbMedicamento.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um medicamento");
                return;
            }
            Medicamento medicamento = cbMedicamento.SelectedItem as Medicamento;
            Idoso idoso = cbIdoso.SelectedItem as Idoso;
            MedicaIdoso medicaIdoso = new MedicaIdoso(medicamento.ID_Medicamento,idoso.ID_Idoso, tbDose.Text);
            medicaIdoso.Guardar(bd);
            AtualizarCBIdosos();
            AtualizarCBMedicamentos();
            AtualizarDGV();
            LimparForm();
        }

        private void dgvMedicaIdoso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgvMedicaIdoso.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            id_idosomedica_escolhido = int.Parse(dgvMedicaIdoso.Rows[linha].Cells[0].Value.ToString());
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            ApagarMedicaIdoso();
            AtualizarDGV();
        }

        private void ApagarMedicaIdoso()
        {
            string sql = "DELETE FROM IdosoMedica WHERE ID_IdosoMedica=" + id_idosomedica_escolhido;
            bd.ExecutaSQL(sql);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparForm();
        }

        private void LimparForm()
        {
            tbDose.Text = "";
        }

        private void dgvMedicaIdoso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }
        private void imprimeGrelha(System.Drawing.Printing.PrintPageEventArgs e, DataGridView grelha)
        {
            Graphics impressora = e.Graphics;
            Font tipoLetra = new Font("Arial", 10);
            Font tipoLetraMaior = new Font("Arial", 12, FontStyle.Bold);
            Brush cor = Brushes.Black;
            float mesquerda, mdireita, msuperior, minferior, linha, largura;
            Pen caneta = new Pen(cor, 2);

            //margens
            mesquerda = printDocument1.DefaultPageSettings.Margins.Left;
            mdireita = printDocument1.DefaultPageSettings.Bounds.Right - mesquerda;
            msuperior = printDocument1.DefaultPageSettings.Margins.Top;
            minferior = printDocument1.DefaultPageSettings.Bounds.Height - msuperior;
            largura = mdireita - mesquerda;
            //calcular as colunas da grelha
            float[] colunas = new float[grelha.Columns.Count];
            float lgrelha = 0;
            for (int i = 0; i < grelha.Columns.Count; i++)
                lgrelha += grelha.Columns[i].Width;
            colunas[0] = mesquerda;
            float total = mesquerda, larguraColuna;
            for (int i = 0; i < grelha.Columns.Count - 1; i++)
            {
                larguraColuna = grelha.Columns[i].Width / lgrelha;
                colunas[i + 1] = larguraColuna * largura + total;
                total = colunas[i + 1];
            }
            //cabeçalhos
            for (int i = 0; i < grelha.Columns.Count; i++)
            {
                impressora.DrawString(grelha.Columns[i].HeaderText, tipoLetraMaior, cor, colunas[i], msuperior);
            }
            linha = msuperior + tipoLetraMaior.Height;
            //ciclo para percorrer a grelha
            int l;
            for (l = nrlinhas; l < grelha.Rows.Count; l++)
            {
                //desenhar linha
                impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
                //escrever uma linha
                for (int c = 0; c < grelha.Columns.Count; c++)
                {
                    impressora.DrawString(grelha.Rows[l].Cells[c].Value.ToString(),
                        tipoLetra, cor, colunas[c], linha);
                }
                //avançar para linha seguinte
                linha = linha + tipoLetra.Height;
                //verificar se o papel acabou
                if (linha + tipoLetra.Height > minferior)
                    break;
            }
            //tem mais páginas?
            if (l < grelha.Rows.Count)
            {
                nrlinhas = l + 1;
                e.HasMorePages = true;
            }
            //rodapé
            impressora.DrawString("12ºH - Página " + nrpagina.ToString(), tipoLetra, cor, mesquerda, minferior);
            //nr página
            nrpagina++;
            //linhas
            //linha superior
            impressora.DrawLine(caneta, mesquerda, msuperior, mdireita, msuperior);
            //linha inferior
            impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
            //colunas
            for (int c = 0; c < colunas.Length; c++)
            {
                impressora.DrawLine(caneta, colunas[c], msuperior, colunas[c], linha);
            }
            //linha lado direito
            impressora.DrawLine(caneta, mdireita, msuperior, mdireita, linha);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MedicaIdoso medica = new MedicaIdoso();

            medica.ID_IdosoMedica = id_idosomedica_escolhido;

            Medicamento medicamento = (Medicamento)cbMedicamento.SelectedItem;
            medica.ID_Medicamento = medicamento.ID_Medicamento;
            medica.ID_IdosoMedica = id_idosomedica_escolhido;
            Idoso idoso = (Idoso)cbIdoso.SelectedItem;
            medica.ID_Idoso = idoso.ID_Idoso;
            medica.Dose = tbDose.Text;

            medica.Atualizar(bd);
            AtualizarDGV();

        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            imprimeGrelha(e, dgvMedicaIdoso);

        }


    }
}   
