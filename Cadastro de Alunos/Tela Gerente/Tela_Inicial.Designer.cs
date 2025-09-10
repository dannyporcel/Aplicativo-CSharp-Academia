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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeFuncináriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDeModalidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDePlanosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaDeAlunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaDeFuncionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaDeProfessoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaDeModalidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisaDePlanosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.logoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.pesquisaToolStripMenuItem,
            this.sairToolStripMenuItem,
            this.logoffToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1173, 42);
            this.menuStrip1.TabIndex = 155;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDeAlunosToolStripMenuItem,
            this.cadastroDeFuncináriosToolStripMenuItem,
            this.cadastroDeToolStripMenuItem,
            this.cadastroDeModalidadesToolStripMenuItem,
            this.cadastroDePlanosToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(91, 38);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // cadastroDeAlunosToolStripMenuItem
            // 
            this.cadastroDeAlunosToolStripMenuItem.Name = "cadastroDeAlunosToolStripMenuItem";
            this.cadastroDeAlunosToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.cadastroDeAlunosToolStripMenuItem.Text = "Cadastro de Alunos";
            this.cadastroDeAlunosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeAlunosToolStripMenuItem_Click);
            // 
            // cadastroDeFuncináriosToolStripMenuItem
            // 
            this.cadastroDeFuncináriosToolStripMenuItem.Name = "cadastroDeFuncináriosToolStripMenuItem";
            this.cadastroDeFuncináriosToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.cadastroDeFuncináriosToolStripMenuItem.Text = "Cadastro de Funcionários";
            this.cadastroDeFuncináriosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeFuncináriosToolStripMenuItem_Click);
            // 
            // cadastroDeToolStripMenuItem
            // 
            this.cadastroDeToolStripMenuItem.Name = "cadastroDeToolStripMenuItem";
            this.cadastroDeToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.cadastroDeToolStripMenuItem.Text = "Cadastro de Professores";
            this.cadastroDeToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeToolStripMenuItem_Click);
            // 
            // cadastroDeModalidadesToolStripMenuItem
            // 
            this.cadastroDeModalidadesToolStripMenuItem.Name = "cadastroDeModalidadesToolStripMenuItem";
            this.cadastroDeModalidadesToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.cadastroDeModalidadesToolStripMenuItem.Text = "Cadastro de Modalidades";
            this.cadastroDeModalidadesToolStripMenuItem.Click += new System.EventHandler(this.cadastroDeModalidadesToolStripMenuItem_Click);
            // 
            // cadastroDePlanosToolStripMenuItem
            // 
            this.cadastroDePlanosToolStripMenuItem.Name = "cadastroDePlanosToolStripMenuItem";
            this.cadastroDePlanosToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.cadastroDePlanosToolStripMenuItem.Text = "Cadastro de Planos";
            this.cadastroDePlanosToolStripMenuItem.Click += new System.EventHandler(this.cadastroDePlanosToolStripMenuItem_Click);
            // 
            // pesquisaToolStripMenuItem
            // 
            this.pesquisaToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pesquisaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesquisaDeAlunosToolStripMenuItem,
            this.pesquisaDeFuncionáriosToolStripMenuItem,
            this.pesquisaDeProfessoresToolStripMenuItem,
            this.pesquisaDeModalidadesToolStripMenuItem,
            this.pesquisaDePlanosToolStripMenuItem});
            this.pesquisaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pesquisaToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.pesquisaToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.pesquisaToolStripMenuItem.Name = "pesquisaToolStripMenuItem";
            this.pesquisaToolStripMenuItem.Size = new System.Drawing.Size(93, 38);
            this.pesquisaToolStripMenuItem.Text = " Pesquisas";
            // 
            // pesquisaDeAlunosToolStripMenuItem
            // 
            this.pesquisaDeAlunosToolStripMenuItem.Name = "pesquisaDeAlunosToolStripMenuItem";
            this.pesquisaDeAlunosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.pesquisaDeAlunosToolStripMenuItem.Text = "Pesquisa de Alunos";
            this.pesquisaDeAlunosToolStripMenuItem.Click += new System.EventHandler(this.pesquisaDeAlunosToolStripMenuItem_Click);
            // 
            // pesquisaDeFuncionáriosToolStripMenuItem
            // 
            this.pesquisaDeFuncionáriosToolStripMenuItem.Name = "pesquisaDeFuncionáriosToolStripMenuItem";
            this.pesquisaDeFuncionáriosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.pesquisaDeFuncionáriosToolStripMenuItem.Text = "Pesquisa de Funcionários";
            this.pesquisaDeFuncionáriosToolStripMenuItem.Click += new System.EventHandler(this.pesquisaDeFuncionáriosToolStripMenuItem_Click);
            // 
            // pesquisaDeProfessoresToolStripMenuItem
            // 
            this.pesquisaDeProfessoresToolStripMenuItem.Name = "pesquisaDeProfessoresToolStripMenuItem";
            this.pesquisaDeProfessoresToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.pesquisaDeProfessoresToolStripMenuItem.Text = "Pesquisa de Professores";
            this.pesquisaDeProfessoresToolStripMenuItem.Click += new System.EventHandler(this.pesquisaDeProfessoresToolStripMenuItem_Click);
            // 
            // pesquisaDeModalidadesToolStripMenuItem
            // 
            this.pesquisaDeModalidadesToolStripMenuItem.Name = "pesquisaDeModalidadesToolStripMenuItem";
            this.pesquisaDeModalidadesToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.pesquisaDeModalidadesToolStripMenuItem.Text = "Pesquisa de Modalidades";
            this.pesquisaDeModalidadesToolStripMenuItem.Click += new System.EventHandler(this.pesquisaDeModalidadesToolStripMenuItem_Click);
            // 
            // pesquisaDePlanosToolStripMenuItem
            // 
            this.pesquisaDePlanosToolStripMenuItem.Name = "pesquisaDePlanosToolStripMenuItem";
            this.pesquisaDePlanosToolStripMenuItem.Size = new System.Drawing.Size(254, 26);
            this.pesquisaDePlanosToolStripMenuItem.Text = "Pesquisa de Planos";
            this.pesquisaDePlanosToolStripMenuItem.Click += new System.EventHandler(this.pesquisaDePlanosToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sairToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(130, 38);
            this.sairToolStripMenuItem.Text = "Tela Pagamento";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1173, 591);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 156;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 42);
            this.panel1.TabIndex = 157;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblUsuario.Location = new System.Drawing.Point(598, 11);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 24);
            this.lblUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(427, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seja Bem-Vindo(a):";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(39, 552);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(100, 20);
            this.txtCPF.TabIndex = 158;
            this.txtCPF.Visible = false;
            // 
            // logoffToolStripMenuItem
            // 
            this.logoffToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.logoffToolStripMenuItem.Name = "logoffToolStripMenuItem";
            this.logoffToolStripMenuItem.Size = new System.Drawing.Size(67, 38);
            this.logoffToolStripMenuItem.Text = "Logoff";
            this.logoffToolStripMenuItem.Click += new System.EventHandler(this.logoffToolStripMenuItem_Click);
            // 
            // frmTelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1173, 636);
            this.ControlBox = false;
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmTelaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Inicial";
            this.Load += new System.EventHandler(this.frmTelaInicial_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cadastroDeAlunosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cadastroDeFuncináriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cadastroDeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cadastroDeModalidadesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaDeAlunosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaDeFuncionáriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaDeProfessoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaDePlanosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pesquisaDeModalidadesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem cadastroDePlanosToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem logoffToolStripMenuItem;
    }
}