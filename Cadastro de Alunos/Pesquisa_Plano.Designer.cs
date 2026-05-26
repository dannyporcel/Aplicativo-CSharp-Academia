namespace Cadastro_de_Alunos
{
    partial class Pesquisa_Plano
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pesquisa_Plano));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSair = new System.Windows.Forms.Button();
			this.dgPesquisaPlano = new System.Windows.Forms.DataGridView();
			this.pnlEditar = new System.Windows.Forms.Panel();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnLimpar = new System.Windows.Forms.Button();
			this.btnAtualizar = new System.Windows.Forms.Button();
			this.btnEditar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtValor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNomeEditar = new System.Windows.Forms.TextBox();
			this.txtPMI = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPesquisaPlano)).BeginInit();
			this.pnlEditar.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.ForeColor = System.Drawing.SystemColors.Control;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 29);
			this.panel1.TabIndex = 114;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(3, 3);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(30, 24);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 5;
			this.pictureBox2.TabStop = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(39, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(129, 16);
			this.label7.TabIndex = 4;
			this.label7.Text = "Pesquisa de Planos";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtNome);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 35);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(224, 127);
			this.groupBox1.TabIndex = 115;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pesquisar";
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(81, 60);
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(100, 20);
			this.txtNome.TabIndex = 6;
			this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome:";
			// 
			// btnSair
			// 
			this.btnSair.Location = new System.Drawing.Point(93, 222);
			this.btnSair.Name = "btnSair";
			this.btnSair.Size = new System.Drawing.Size(75, 23);
			this.btnSair.TabIndex = 122;
			this.btnSair.Text = "Voltar";
			this.btnSair.UseVisualStyleBackColor = true;
			this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
			// 
			// dgPesquisaPlano
			// 
			this.dgPesquisaPlano.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgPesquisaPlano.Location = new System.Drawing.Point(242, 45);
			this.dgPesquisaPlano.Name = "dgPesquisaPlano";
			this.dgPesquisaPlano.Size = new System.Drawing.Size(546, 117);
			this.dgPesquisaPlano.TabIndex = 123;
			this.dgPesquisaPlano.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgPesquisaPlano_MouseClick);
			// 
			// pnlEditar
			// 
			this.pnlEditar.Controls.Add(this.btnCancelar);
			this.pnlEditar.Controls.Add(this.btnLimpar);
			this.pnlEditar.Controls.Add(this.btnAtualizar);
			this.pnlEditar.Controls.Add(this.btnEditar);
			this.pnlEditar.Controls.Add(this.label2);
			this.pnlEditar.Controls.Add(this.txtValor);
			this.pnlEditar.Controls.Add(this.label5);
			this.pnlEditar.Controls.Add(this.txtNomeEditar);
			this.pnlEditar.Controls.Add(this.txtPMI);
			this.pnlEditar.Controls.Add(this.label4);
			this.pnlEditar.Location = new System.Drawing.Point(242, 168);
			this.pnlEditar.Name = "pnlEditar";
			this.pnlEditar.Size = new System.Drawing.Size(546, 270);
			this.pnlEditar.TabIndex = 124;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Enabled = false;
			this.btnCancelar.Location = new System.Drawing.Point(290, 227);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 128;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnLimpar
			// 
			this.btnLimpar.Enabled = false;
			this.btnLimpar.Location = new System.Drawing.Point(189, 227);
			this.btnLimpar.Name = "btnLimpar";
			this.btnLimpar.Size = new System.Drawing.Size(75, 23);
			this.btnLimpar.TabIndex = 127;
			this.btnLimpar.Text = "Limpar";
			this.btnLimpar.UseVisualStyleBackColor = true;
			this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click_1);
			// 
			// btnAtualizar
			// 
			this.btnAtualizar.Enabled = false;
			this.btnAtualizar.Location = new System.Drawing.Point(90, 227);
			this.btnAtualizar.Name = "btnAtualizar";
			this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
			this.btnAtualizar.TabIndex = 126;
			this.btnAtualizar.Text = "Atualizar";
			this.btnAtualizar.UseVisualStyleBackColor = true;
			this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
			// 
			// btnEditar
			// 
			this.btnEditar.Location = new System.Drawing.Point(431, 22);
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(75, 23);
			this.btnEditar.TabIndex = 125;
			this.btnEditar.Text = "Editar";
			this.btnEditar.UseVisualStyleBackColor = true;
			this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 118;
			this.label2.Text = "Valor Mensal*:";
			// 
			// txtValor
			// 
			this.txtValor.Enabled = false;
			this.txtValor.Location = new System.Drawing.Point(109, 93);
			this.txtValor.Name = "txtValor";
			this.txtValor.Size = new System.Drawing.Size(74, 20);
			this.txtValor.TabIndex = 117;
			this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(27, 59);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(155, 13);
			this.label5.TabIndex = 26;
			this.label5.Text = "Período Máximo Inadimplência:";
			// 
			// txtNomeEditar
			// 
			this.txtNomeEditar.Enabled = false;
			this.txtNomeEditar.Location = new System.Drawing.Point(75, 22);
			this.txtNomeEditar.Name = "txtNomeEditar";
			this.txtNomeEditar.Size = new System.Drawing.Size(290, 20);
			this.txtNomeEditar.TabIndex = 23;
			// 
			// txtPMI
			// 
			this.txtPMI.Enabled = false;
			this.txtPMI.Location = new System.Drawing.Point(189, 59);
			this.txtPMI.Name = "txtPMI";
			this.txtPMI.Size = new System.Drawing.Size(105, 20);
			this.txtPMI.TabIndex = 25;
			this.txtPMI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPMI_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(27, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 24;
			this.label4.Text = "Nome*:";
			// 
			// txtID
			// 
			this.txtID.Enabled = false;
			this.txtID.Location = new System.Drawing.Point(109, 298);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(43, 20);
			this.txtID.TabIndex = 129;
			this.txtID.Visible = false;
			// 
			// Pesquisa_Plano
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 480);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.pnlEditar);
			this.Controls.Add(this.dgPesquisaPlano);
			this.Controls.Add(this.btnSair);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Pesquisa_Plano";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pesquisa_Plano";
			this.Load += new System.EventHandler(this.Pesquisa_Plano_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPesquisaPlano)).EndInit();
			this.pnlEditar.ResumeLayout(false);
			this.pnlEditar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView dgPesquisaPlano;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Panel pnlEditar;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNomeEditar;
		private System.Windows.Forms.TextBox txtPMI;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnLimpar;
		private System.Windows.Forms.Button btnAtualizar;
		private System.Windows.Forms.Button btnEditar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtValor;
		private System.Windows.Forms.TextBox txtID;
	}
}