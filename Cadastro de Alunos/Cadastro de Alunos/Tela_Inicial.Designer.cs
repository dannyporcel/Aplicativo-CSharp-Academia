namespace Cadastro_de_Alunos
{
    partial class frmTelaInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTelaInicial));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeFuncináriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeModalidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaDeAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaDeFuncionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaDeProfessoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaDePlanosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaDeModalidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradeHoráriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(41, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(454, 353);
            this.pictureBox1.TabIndex = 152;
            this.pictureBox1.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(433, 425);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 153;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.pesquisaToolStripMenuItem,
            this.gradeHoráriaToolStripMenuItem,
            this.pagamentosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(538, 24);
            this.menuStrip1.TabIndex = 155;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeAlunosToolStripMenuItem,
            this.cadastroDeFuncináriosToolStripMenuItem,
            this.cadastroDeToolStripMenuItem,
            this.cadastroDeToolStripMenuItem1,
            this.cadastroDeModalidadesToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // cadastroDeAlunosToolStripMenuItem
            // 
            this.cadastroDeAlunosToolStripMenuItem.Name = "cadastroDeAlunosToolStripMenuItem";
            this.cadastroDeAlunosToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.cadastroDeAlunosToolStripMenuItem.Text = "Cadastro de Alunos";
            this.cadastroDeAlunosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeAlunosToolStripMenuItem_Click);
            // 
            // cadastroDeFuncináriosToolStripMenuItem
            // 
            this.cadastroDeFuncináriosToolStripMenuItem.Name = "cadastroDeFuncináriosToolStripMenuItem";
            this.cadastroDeFuncináriosToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.cadastroDeFuncináriosToolStripMenuItem.Text = "Cadastro de Funcionários";
            this.cadastroDeFuncináriosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeFuncináriosToolStripMenuItem_Click);
            // 
            // cadastroDeToolStripMenuItem
            // 
            this.cadastroDeToolStripMenuItem.Name = "cadastroDeToolStripMenuItem";
            this.cadastroDeToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.cadastroDeToolStripMenuItem.Text = "Cadastro de Professores";
            this.cadastroDeToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeToolStripMenuItem_Click);
            // 
            // cadastroDeToolStripMenuItem1
            // 
            this.cadastroDeToolStripMenuItem1.Name = "cadastroDeToolStripMenuItem1";
            this.cadastroDeToolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            this.cadastroDeToolStripMenuItem1.Text = "Cadastro de Planos";
            this.cadastroDeToolStripMenuItem1.Click += new System.EventHandler(this.cadastroDeToolStripMenuItem1_Click);
            // 
            // cadastroDeModalidadesToolStripMenuItem
            // 
            this.cadastroDeModalidadesToolStripMenuItem.Name = "cadastroDeModalidadesToolStripMenuItem";
            this.cadastroDeModalidadesToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.cadastroDeModalidadesToolStripMenuItem.Text = "Cadastro de Modalidades";
            this.cadastroDeModalidadesToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeModalidadesToolStripMenuItem_Click);
            // 
            // pesquisaToolStripMenuItem
            // 
            this.pesquisaToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pesquisaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesquisaDeAlunosToolStripMenuItem,
            this.pesquisaDeFuncionáriosToolStripMenuItem,
            this.pesquisaDeProfessoresToolStripMenuItem,
            this.pesquisaDePlanosToolStripMenuItem,
            this.pesquisaDeModalidadesToolStripMenuItem});
            this.pesquisaToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.pesquisaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.pesquisaToolStripMenuItem.Name = "pesquisaToolStripMenuItem";
            this.pesquisaToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.pesquisaToolStripMenuItem.Text = "Pesquisa";
            // 
            // pesquisaDeAlunosToolStripMenuItem
            // 
            this.pesquisaDeAlunosToolStripMenuItem.Name = "pesquisaDeAlunosToolStripMenuItem";
            this.pesquisaDeAlunosToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.pesquisaDeAlunosToolStripMenuItem.Text = "Pesquisa de Alunos";
            // 
            // pesquisaDeFuncionáriosToolStripMenuItem
            // 
            this.pesquisaDeFuncionáriosToolStripMenuItem.Name = "pesquisaDeFuncionáriosToolStripMenuItem";
            this.pesquisaDeFuncionáriosToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.pesquisaDeFuncionáriosToolStripMenuItem.Text = "Pesquisa de Funcionários";
            // 
            // pesquisaDeProfessoresToolStripMenuItem
            // 
            this.pesquisaDeProfessoresToolStripMenuItem.Name = "pesquisaDeProfessoresToolStripMenuItem";
            this.pesquisaDeProfessoresToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.pesquisaDeProfessoresToolStripMenuItem.Text = "Pesquisa de Professores";
            // 
            // pesquisaDePlanosToolStripMenuItem
            // 
            this.pesquisaDePlanosToolStripMenuItem.Name = "pesquisaDePlanosToolStripMenuItem";
            this.pesquisaDePlanosToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.pesquisaDePlanosToolStripMenuItem.Text = "Pesquisa de Planos";
            // 
            // pesquisaDeModalidadesToolStripMenuItem
            // 
            this.pesquisaDeModalidadesToolStripMenuItem.Name = "pesquisaDeModalidadesToolStripMenuItem";
            this.pesquisaDeModalidadesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.pesquisaDeModalidadesToolStripMenuItem.Text = "Pesquisa de Modalidades";
            // 
            // gradeHoráriaToolStripMenuItem
            // 
            this.gradeHoráriaToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.gradeHoráriaToolStripMenuItem.Name = "gradeHoráriaToolStripMenuItem";
            this.gradeHoráriaToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.gradeHoráriaToolStripMenuItem.Text = "Grade Horária";
            // 
            // pagamentosToolStripMenuItem
            // 
            this.pagamentosToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pagamentosToolStripMenuItem.Name = "pagamentosToolStripMenuItem";
            this.pagamentosToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.pagamentosToolStripMenuItem.Text = "Pagamentos";
            // 
            // frmTelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(538, 460);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmTelaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Inicial";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnSair;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cadastroDeAlunosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cadastroDeFuncináriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cadastroDeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cadastroDeToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem cadastroDeModalidadesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaDeAlunosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaDeFuncionáriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaDeProfessoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaDePlanosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaDeModalidadesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gradeHoráriaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pagamentosToolStripMenuItem;
	}
}