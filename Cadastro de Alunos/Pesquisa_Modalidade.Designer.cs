namespace Cadastro_de_Alunos
{
    partial class Pesquisa_Modalidade
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pesquisa_Modalidade));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtTipo = new System.Windows.Forms.TextBox();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSair = new System.Windows.Forms.Button();
			this.dgPesquisaModal = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnEditar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnLimpar = new System.Windows.Forms.Button();
			this.btnAtualizar = new System.Windows.Forms.Button();
			this.gbModalidadeDados = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtValor = new System.Windows.Forms.TextBox();
			this.txtTipoEditar = new System.Windows.Forms.TextBox();
			this.txtDescricao = new System.Windows.Forms.TextBox();
			this.lblDescrição = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNomeEditar = new System.Windows.Forms.TextBox();
			this.txtID = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPesquisaModal)).BeginInit();
			this.panel2.SuspendLayout();
			this.gbModalidadeDados.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.OrangeRed;
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.ForeColor = System.Drawing.SystemColors.Control;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 29);
			this.panel1.TabIndex = 112;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(3, 2);
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
			this.label7.Location = new System.Drawing.Point(42, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(167, 16);
			this.label7.TabIndex = 4;
			this.label7.Text = "Pesquisa de Modalidades";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtTipo);
			this.groupBox1.Controls.Add(this.txtNome);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 35);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(298, 87);
			this.groupBox1.TabIndex = 113;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pesquisar";
			// 
			// txtTipo
			// 
			this.txtTipo.Location = new System.Drawing.Point(88, 48);
			this.txtTipo.Name = "txtTipo";
			this.txtTipo.Size = new System.Drawing.Size(193, 20);
			this.txtTipo.TabIndex = 7;
			this.txtTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTipo_KeyPress);
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(88, 22);
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(193, 20);
			this.txtNome.TabIndex = 6;
			this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(51, 51);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(31, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Tipo:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(44, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome:";
			// 
			// btnSair
			// 
			this.btnSair.Location = new System.Drawing.Point(19, 166);
			this.btnSair.Name = "btnSair";
			this.btnSair.Size = new System.Drawing.Size(75, 24);
			this.btnSair.TabIndex = 116;
			this.btnSair.Text = "Voltar";
			this.btnSair.UseVisualStyleBackColor = true;
			this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
			// 
			// dgPesquisaModal
			// 
			this.dgPesquisaModal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgPesquisaModal.Location = new System.Drawing.Point(316, 35);
			this.dgPesquisaModal.Name = "dgPesquisaModal";
			this.dgPesquisaModal.Size = new System.Drawing.Size(472, 87);
			this.dgPesquisaModal.TabIndex = 117;
			this.dgPesquisaModal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgPesquisaModal_MouseClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnEditar);
			this.panel2.Controls.Add(this.btnCancelar);
			this.panel2.Controls.Add(this.btnLimpar);
			this.panel2.Controls.Add(this.btnAtualizar);
			this.panel2.Controls.Add(this.gbModalidadeDados);
			this.panel2.Location = new System.Drawing.Point(141, 141);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(647, 368);
			this.panel2.TabIndex = 118;
			// 
			// btnEditar
			// 
			this.btnEditar.Location = new System.Drawing.Point(562, 88);
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(75, 23);
			this.btnEditar.TabIndex = 13;
			this.btnEditar.Text = "Editar";
			this.btnEditar.UseVisualStyleBackColor = true;
			this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Enabled = false;
			this.btnCancelar.Location = new System.Drawing.Point(415, 330);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 10;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnLimpar
			// 
			this.btnLimpar.Enabled = false;
			this.btnLimpar.Location = new System.Drawing.Point(245, 331);
			this.btnLimpar.Name = "btnLimpar";
			this.btnLimpar.Size = new System.Drawing.Size(75, 23);
			this.btnLimpar.TabIndex = 11;
			this.btnLimpar.Text = "Limpar ";
			this.btnLimpar.UseVisualStyleBackColor = true;
			this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
			// 
			// btnAtualizar
			// 
			this.btnAtualizar.Enabled = false;
			this.btnAtualizar.Location = new System.Drawing.Point(63, 331);
			this.btnAtualizar.Name = "btnAtualizar";
			this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
			this.btnAtualizar.TabIndex = 9;
			this.btnAtualizar.Text = "Atualizar";
			this.btnAtualizar.UseVisualStyleBackColor = true;
			this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
			// 
			// gbModalidadeDados
			// 
			this.gbModalidadeDados.Controls.Add(this.label3);
			this.gbModalidadeDados.Controls.Add(this.txtValor);
			this.gbModalidadeDados.Controls.Add(this.txtTipoEditar);
			this.gbModalidadeDados.Controls.Add(this.txtDescricao);
			this.gbModalidadeDados.Controls.Add(this.lblDescrição);
			this.gbModalidadeDados.Controls.Add(this.label2);
			this.gbModalidadeDados.Controls.Add(this.label4);
			this.gbModalidadeDados.Controls.Add(this.txtNomeEditar);
			this.gbModalidadeDados.Location = new System.Drawing.Point(12, 3);
			this.gbModalidadeDados.Name = "gbModalidadeDados";
			this.gbModalidadeDados.Size = new System.Drawing.Size(531, 321);
			this.gbModalidadeDados.TabIndex = 12;
			this.gbModalidadeDados.TabStop = false;
			this.gbModalidadeDados.Text = "Dados da Modalidade de Aula:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Valor:";
			// 
			// txtValor
			// 
			this.txtValor.Enabled = false;
			this.txtValor.Location = new System.Drawing.Point(47, 82);
			this.txtValor.Name = "txtValor";
			this.txtValor.Size = new System.Drawing.Size(61, 20);
			this.txtValor.TabIndex = 2;
			this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
			// 
			// txtTipoEditar
			// 
			this.txtTipoEditar.Enabled = false;
			this.txtTipoEditar.Location = new System.Drawing.Point(47, 56);
			this.txtTipoEditar.MaxLength = 50;
			this.txtTipoEditar.Name = "txtTipoEditar";
			this.txtTipoEditar.Size = new System.Drawing.Size(243, 20);
			this.txtTipoEditar.TabIndex = 1;
			// 
			// txtDescricao
			// 
			this.txtDescricao.Enabled = false;
			this.txtDescricao.Location = new System.Drawing.Point(9, 133);
			this.txtDescricao.Multiline = true;
			this.txtDescricao.Name = "txtDescricao";
			this.txtDescricao.Size = new System.Drawing.Size(480, 143);
			this.txtDescricao.TabIndex = 3;
			// 
			// lblDescrição
			// 
			this.lblDescrição.AutoSize = true;
			this.lblDescrição.Location = new System.Drawing.Point(10, 117);
			this.lblDescrição.Name = "lblDescrição";
			this.lblDescrição.Size = new System.Drawing.Size(58, 13);
			this.lblDescrição.TabIndex = 3;
			this.lblDescrição.Text = "Descrição:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tipo:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(-1, 33);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "Nome*:";
			// 
			// txtNomeEditar
			// 
			this.txtNomeEditar.Enabled = false;
			this.txtNomeEditar.Location = new System.Drawing.Point(47, 30);
			this.txtNomeEditar.MaxLength = 150;
			this.txtNomeEditar.Name = "txtNomeEditar";
			this.txtNomeEditar.Size = new System.Drawing.Size(243, 20);
			this.txtNomeEditar.TabIndex = 0;
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(19, 292);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(61, 20);
			this.txtID.TabIndex = 13;
			this.txtID.Visible = false;
			// 
			// Pesquisa_Modalidade
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 519);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.dgPesquisaModal);
			this.Controls.Add(this.btnSair);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Pesquisa_Modalidade";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pesquisa_Modalidade";
			this.Load += new System.EventHandler(this.Pesquisa_Modalidade_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPesquisaModal)).EndInit();
			this.panel2.ResumeLayout(false);
			this.gbModalidadeDados.ResumeLayout(false);
			this.gbModalidadeDados.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView dgPesquisaModal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtTipo;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnEditar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnLimpar;
		private System.Windows.Forms.Button btnAtualizar;
		private System.Windows.Forms.GroupBox gbModalidadeDados;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtValor;
		private System.Windows.Forms.TextBox txtTipoEditar;
		private System.Windows.Forms.TextBox txtDescricao;
		private System.Windows.Forms.Label lblDescrição;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtNomeEditar;
		private System.Windows.Forms.TextBox txtID;
	}
}