namespace MOD15_Projeto.DarMedicamento
{
    partial class F_MedicaIdoso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_MedicaIdoso));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbIdoso = new System.Windows.Forms.ComboBox();
            this.cbMedicamento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDose = new System.Windows.Forms.TextBox();
            this.dgvMedicaIdoso = new System.Windows.Forms.DataGridView();
            this.btnApagar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicaIdoso)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(61, 253);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(138, 28);
            this.btnGuardar.TabIndex = 139;
            this.btnGuardar.Text = "Iniciar Medicação";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbIdoso
            // 
            this.cbIdoso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdoso.FormattingEnabled = true;
            this.cbIdoso.Location = new System.Drawing.Point(199, 72);
            this.cbIdoso.Margin = new System.Windows.Forms.Padding(4);
            this.cbIdoso.Name = "cbIdoso";
            this.cbIdoso.Size = new System.Drawing.Size(271, 24);
            this.cbIdoso.TabIndex = 137;
            // 
            // cbMedicamento
            // 
            this.cbMedicamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMedicamento.FormattingEnabled = true;
            this.cbMedicamento.Location = new System.Drawing.Point(199, 32);
            this.cbMedicamento.Margin = new System.Windows.Forms.Padding(4);
            this.cbMedicamento.Name = "cbMedicamento";
            this.cbMedicamento.Size = new System.Drawing.Size(271, 24);
            this.cbMedicamento.TabIndex = 136;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 134;
            this.label2.Text = "Idoso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 133;
            this.label1.Text = "Medicamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 16);
            this.label3.TabIndex = 140;
            this.label3.Text = "Número de Vezes ao Dia";
            // 
            // tbDose
            // 
            this.tbDose.Location = new System.Drawing.Point(199, 128);
            this.tbDose.Name = "tbDose";
            this.tbDose.Size = new System.Drawing.Size(271, 22);
            this.tbDose.TabIndex = 141;
            // 
            // dgvMedicaIdoso
            // 
            this.dgvMedicaIdoso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicaIdoso.Location = new System.Drawing.Point(517, 12);
            this.dgvMedicaIdoso.Name = "dgvMedicaIdoso";
            this.dgvMedicaIdoso.RowHeadersWidth = 51;
            this.dgvMedicaIdoso.RowTemplate.Height = 24;
            this.dgvMedicaIdoso.Size = new System.Drawing.Size(466, 222);
            this.dgvMedicaIdoso.TabIndex = 142;
            this.dgvMedicaIdoso.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicaIdoso_CellClick);
            this.dgvMedicaIdoso.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicaIdoso_CellContentClick);
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(222, 253);
            this.btnApagar.Margin = new System.Windows.Forms.Padding(4);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(164, 28);
            this.btnApagar.TabIndex = 143;
            this.btnApagar.Text = "Terminar Medicação";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(899, 270);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(76, 32);
            this.btnImprimir.TabIndex = 144;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(407, 251);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 32);
            this.button4.TabIndex = 145;
            this.button4.Text = "Alterar Medicação";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // F_MedicaIdoso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 315);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.dgvMedicaIdoso);
            this.Controls.Add(this.tbDose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cbIdoso);
            this.Controls.Add(this.cbMedicamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "F_MedicaIdoso";
            this.Text = "F_MedicaIdoso";
            this.Load += new System.EventHandler(this.F_MedicaIdoso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicaIdoso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cbIdoso;
        private System.Windows.Forms.ComboBox cbMedicamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDose;
        private System.Windows.Forms.DataGridView dgvMedicaIdoso;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button button4;
    }
}