using System;
using MOD15_Projeto.Familiares;
using MOD15_Projeto.Idosos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace MOD15_Projeto.Visistas
{
    public partial class F_Visita : Form
    {
        BaseDados bd;
        int id_visita_escolhido, id_idoso_escolhido;

        int nrlinhas, nrpagina;

        public F_Visita(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizarCBIdosos();
            AtualizarCBFamiliares();
        }

        private void AtualizarCBFamiliares()
        {
            cbFamiliar.Items.Clear();

            DataTable dados = Familiar.ListarFamiliar(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Familiar familiar = new Familiar();
                familiar.ID_Familiar = int.Parse(dr["ID_Familiar"].ToString());
                familiar.Nome = dr["Nome"].ToString();
                cbFamiliar.Items.Add(familiar);
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


        private void F_Visita_Load(object sender, EventArgs e)
        {   
            /*dtpHora.Format = DateTimePickerFormat.Custom; // Hora com apenas hora e minutos
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.ShowUpDown = true;*/

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime datavisita = dtVisita.Value;
            if (datavisita <= DateTime.Now)
            {
                MessageBox.Show("A Data da Visita tem de ser igual ou superior há Data Atual");
                dtVisita.Focus();
                return;
            }
            /*DateTime hora = dtpHora.Value;
            if (hora <= DateTime.Now)
            {
                MessageBox.Show("A Hora tem de ser igual ou superior há Hora Atual");
                dtpHora.Focus();
                return;
            }*/

            if (cbIdoso.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um idoso");
                return;
            }
            if (cbFamiliar.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um familiar");
                return;
            }
            Familiar familiar = cbFamiliar.SelectedItem as Familiar;
            Idoso idoso = cbIdoso.SelectedItem as Idoso;
            Visita visita = new Visita(familiar.ID_Familiar, idoso.ID_Idoso, dtVisita.Value/*,dtpHora.Value*/);
            visita.Guardar(bd);
            AtualizarCBIdosos();
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
            impressora.DrawString("Lista Marcações " + nrpagina.ToString(), tipoLetra, cor, mesquerda, minferior);
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

        private void dtVisita_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvVisita_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void btnVisitas_Click(object sender, EventArgs e)
        {

        }

        
        

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
        }
    }
}
