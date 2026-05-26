namespace Cadastro_de_Alunos
{
    partial class Cadastro_Modalidades
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cadastro_Modalidades));
			this.btnLimpar = new System.Windows.Forms.Button();
			this.btnCadastrar = new System.Windows.Forms.Button();
			this.gbModalidadeDados = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtValor = new System.Windows.Forms.TextBox();
			this.txtTipo = new System.Windows.Forms.TextBox();
			this.txtDescricao = new System.Windows.Forms.TextBox();
			this.lblDescrição = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnVoltar = new System.Windows.Forms.Button();
			this.gbModalidadeDados.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// btnLimpar
			// 
			this.btnLimpar.Location = new System.Drawing.Point(513, 375);
			this.btnLimpar.Name = "btnLimpar";
			this.btnLimpar.Size = new System.Drawing.Size(75, 23);
			this.btnLimpar.TabIndex = 6;
			this.btnLimpar.Text = "Limpar ";
			this.btnLimpar.UseVisualStyleBackColor = true;
			this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
			// 
			// btnCadastrar
			// 
			this.btnCadastrar.Location = new System.Drawing.Point(108, 375);
			this.btnCadastrar.Name = "btnCadastrar";
			this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
			this.btnCadastrar.TabIndex = 4;
			this.btnCadastrar.Text = "Cadastrar";
			this.btnCadastrar.UseVisualStyleBackColor = true;
			this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
			// 
			// gbModalidadeDados
			// 
			this.gbModalidadeDados.Controls.Add(this.label3);
			this.gbModalidadeDados.Controls.Add(this.txtValor);
			this.gbModalidadeDados.Controls.Add(this.txtTipo);
			this.gbModalidadeDados.Controls.Add(this.txtDescricao);
			this.gbModalidadeDados.Controls.Add(this.lblDescrição);
			this.gbModalidadeDados.Controls.Add(this.label2);
			this.gbModalidadeDados.Controls.Add(this.label1);
			this.gbModalidadeDados.Controls.Add(this.txtNome);
			this.gbModalidadeDados.Location = new System.Drawing.Point(12, 50);
			this.gbModalidadeDados.Name = "gbModalidadeDados";
			this.gbModalidadeDados.Size = new System.Drawing.Size(735, 282);
			this.gbModalidadeDados.TabIndex = 8;
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
			this.txtValor.Location = new System.Drawing.Point(47, 82);
			this.txtValor.Name = "txtValor";
			this.txtValor.Size = new System.Drawing.Size(61, 20);
			this.txtValor.TabIndex = 2;
			this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
			// 
			// txtTipo
			// 
			this.txtTipo.Location = new System.Drawing.Point(47, 56);
			this.txtTipo.MaxLength = 50;
			this.txtTipo.Name = "txtTipo";
			this.txtTipo.Size = new System.Drawing.Size(682, 20);
			this.txtTipo.TabIndex = 1;
			// 
			// txtDescricao
			// 
			this.txtDescricao.Location = new System.Drawing.Point(9, 133);
			this.txtDescricao.Multiline = true;
			this.txtDescricao.Name = "txtDescricao";
			this.txtDescricao.Size = new System.Drawing.Size(720, 143);
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(-1, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Nome*:";
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(47, 30);
			this.txtNome.MaxLength = 150;
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(682, 20);
			this.txtNome.TabIndex = 0;
			this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
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
			this.panel1.Size = new System.Drawing.Size(759, 29);
			this.panel1.TabIndex = 113;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(3, 2);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(30, 24);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(39, 10);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(165, 16);
			this.label7.TabIndex = 3;
			this.label7.Text = "Cadastro de Modalidades";
			// 
			// btnVoltar
			// 
			this.btnVoltar.Location = new System.Drawing.Point(316, 374);
			this.btnVoltar.Name = "btnVoltar";
			this.btnVoltar.Size = new System.Drawing.Size(75, 23);
			this.btnVoltar.TabIndex = 5;
			this.btnVoltar.Text = "Voltar";
			this.btnVoltar.UseVisualStyleBackColor = true;
			this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
			// 
			// Cadastro_Modalidades
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(759, 410);
			this.Controls.Add(this.btnVoltar);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnLimpar);
			this.Controls.Add(this.btnCadastrar);
			this.Controls.Add(this.gbModalidadeDados);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Cadastro_Modalidades";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Planos_Modalidades";
			this.Load += new System.EventHandler(this.Cadastro_Modalidades_Load);
			this.gbModalidadeDados.ResumeLayout(false);
			this.gbModalidadeDados.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.GroupBox gbModalidadeDados;
        private System.Windows.Forms.Label lblDescrição;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValor;
    }
}