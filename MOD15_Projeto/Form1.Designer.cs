namespace MOD15_Projeto
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ficheiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idosoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarMedicamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.darMedicamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ficheiroToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ficheiroToolStripMenuItem
            // 
            this.ficheiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
            this.ficheiroToolStripMenuItem.Name = "ficheiroToolStripMenuItem";
            this.ficheiroToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.ficheiroToolStripMenuItem.Text = "Encerrar";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.familiarToolStripMenuItem,
            this.idosoToolStripMenuItem,
            this.visitaToolStripMenuItem,
            this.visitaToolStripMenuItem1,
            this.adicionarMedicamentoToolStripMenuItem,
            this.darMedicamentoToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.editarToolStripMenuItem.Text = "Opções";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // familiarToolStripMenuItem
            // 
            this.familiarToolStripMenuItem.Name = "familiarToolStripMenuItem";
            this.familiarToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.familiarToolStripMenuItem.Text = " Adicionar Familiar";
            this.familiarToolStripMenuItem.Click += new System.EventHandler(this.familiarToolStripMenuItem_Click);
            // 
            // idosoToolStripMenuItem
            // 
            this.idosoToolStripMenuItem.Name = "idosoToolStripMenuItem";
            this.idosoToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.idosoToolStripMenuItem.Text = "Adicionar Idoso";
            this.idosoToolStripMenuItem.Click += new System.EventHandler(this.idosoToolStripMenuItem_Click);
            // 
            // visitaToolStripMenuItem
            // 
            this.visitaToolStripMenuItem.Name = "visitaToolStripMenuItem";
            this.visitaToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.visitaToolStripMenuItem.Text = "Efeturar Marcação";
            this.visitaToolStripMenuItem.Click += new System.EventHandler(this.visitaToolStripMenuItem_Click);
            // 
            // visitaToolStripMenuItem1
            // 
            this.visitaToolStripMenuItem1.Name = "visitaToolStripMenuItem1";
            this.visitaToolStripMenuItem1.Size = new System.Drawing.Size(252, 26);
            this.visitaToolStripMenuItem1.Text = "Listagem Visitas";
            this.visitaToolStripMenuItem1.Click += new System.EventHandler(this.visitaToolStripMenuItem1_Click);
            // 
            // adicionarMedicamentoToolStripMenuItem
            // 
            this.adicionarMedicamentoToolStripMenuItem.Name = "adicionarMedicamentoToolStripMenuItem";
            this.adicionarMedicamentoToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.adicionarMedicamentoToolStripMenuItem.Text = "Adicionar Medicamento";
            this.adicionarMedicamentoToolStripMenuItem.Click += new System.EventHandler(this.adicionarMedicamentoToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MOD15_Projeto.Properties.Resources.lar_para_idosos;
            this.pictureBox1.Location = new System.Drawing.Point(0, 33);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1067, 519);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // darMedicamentoToolStripMenuItem
            // 
            this.darMedicamentoToolStripMenuItem.Name = "darMedicamentoToolStripMenuItem";
            this.darMedicamentoToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.darMedicamentoToolStripMenuItem.Text = "Dar Medicamento";
            this.darMedicamentoToolStripMenuItem.Click += new System.EventHandler(this.darMedicamentoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ficheiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idosoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitaToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem adicionarMedicamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darMedicamentoToolStripMenuItem;
    }
}

