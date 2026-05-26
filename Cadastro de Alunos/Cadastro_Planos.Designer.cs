namespace Cadastro_de_Alunos
{
    partial class Cadastro_Planos
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cadastro_Planos));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbDescricao = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.txtPMI = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnCadastrar = new System.Windows.Forms.Button();
			this.btnLimpar = new System.Windows.Forms.Button();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtValor = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.btnVoltar = new System.Windows.Forms.Button();
			this.beMightyDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.beMightyDataSet = new Cadastro_de_Alunos.BeMightyDataSet();
			this.lbModalidades = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.beMightyDataSetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.beMightyDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbDescricao);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtNome);
			this.groupBox1.Controls.Add(this.txtPMI);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(12, 49);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(402, 268);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dados do Plano";
			// 
			// lbDescricao
			// 
			this.lbDescricao.FormattingEnabled = true;
			this.lbDescricao.Location = new System.Drawing.Point(70, 107);
			this.lbDescricao.Name = "lbDescricao";
			this.lbDescricao.Size = new System.Drawing.Size(290, 108);
			this.lbDescricao.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Descrição:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(132, 50);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(156, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "Período Máximo Inadimplência*";
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(70, 19);
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(290, 20);
			this.txtNome.TabIndex = 17;
			// 
			// txtPMI
			// 
			this.txtPMI.Location = new System.Drawing.Point(151, 66);
			this.txtPMI.Name = "txtPMI";
			this.txtPMI.Size = new System.Drawing.Size(105, 20);
			this.txtPMI.TabIndex = 20;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "Nome*:";
			// 
			// btnCadastrar
			// 
			this.btnCadastrar.Location = new System.Drawing.Point(27, 334);
			this.btnCadastrar.Name = "btnCadastrar";
			this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
			this.btnCadastrar.TabIndex = 1;
			this.btnCadastrar.Text = "Cadastrar";
			this.btnCadastrar.UseVisualStyleBackColor = true;
			this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
			// 
			// btnLimpar
			// 
			this.btnLimpar.Location = new System.Drawing.Point(163, 333);
			this.btnLimpar.Name = "btnLimpar";
			this.btnLimpar.Size = new System.Drawing.Size(75, 23);
			this.btnLimpar.TabIndex = 2;
			this.btnLimpar.Text = "Limpar";
			this.btnLimpar.UseVisualStyleBackColor = true;
			this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel1.ForeColor = System.Drawing.SystemColors.Control;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(759, 29);
			this.panel1.TabIndex = 114;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(4, 3);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(30, 24);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(40, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(127, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Cadastro de Planos";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(454, 343);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 116;
			this.label2.Text = "Valor Mensal*:";
			// 
			// txtValor
			// 
			this.txtValor.Location = new System.Drawing.Point(531, 340);
			this.txtValor.Name = "txtValor";
			this.txtValor.Size = new System.Drawing.Size(43, 20);
			this.txtValor.TabIndex = 115;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(630, 90);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 13);
			this.label6.TabIndex = 121;
			this.label6.Text = "Modalidades*:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(639, 388);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(108, 13);
			this.label7.TabIndex = 122;
			this.label7.Text = "*Campos Obrigatórios";
			// 
			// btnVoltar
			// 
			this.btnVoltar.Location = new System.Drawing.Point(297, 333);
			this.btnVoltar.Name = "btnVoltar";
			this.btnVoltar.Size = new System.Drawing.Size(75, 23);
			this.btnVoltar.TabIndex = 123;
			this.btnVoltar.Text = "Voltar ";
			this.btnVoltar.UseVisualStyleBackColor = true;
			this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
			// 
			// beMightyDataSetBindingSource
			// 
			this.beMightyDataSetBindingSource.DataSource = this.beMightyDataSet;
			this.beMightyDataSetBindingSource.Position = 0;
			// 
			// beMightyDataSet
			// 
			this.beMightyDataSet.DataSetName = "BeMightyDataSet";
			this.beMightyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// lbModalidades
			// 
			this.lbModalidades.FormattingEnabled = true;
			this.lbModalidades.Location = new System.Drawing.Point(611, 115);
			this.lbModalidades.Name = "lbModalidades";
			this.lbModalidades.Size = new System.Drawing.Size(109, 173);
			this.lbModalidades.TabIndex = 124;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(455, 175);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(119, 23);
			this.button1.TabIndex = 125;
			this.button1.Text = "Adicionar Modalidade";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(455, 217);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(119, 23);
			this.button2.TabIndex = 126;
			this.button2.Text = "Retirar Modalidade";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Cadastro_Planos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(759, 410);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lbModalidades);
			this.Controls.Add(this.btnVoltar);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtValor);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnLimpar);
			this.Controls.Add(this.btnCadastrar);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Cadastro_Planos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cadastro_Planos";
			this.Load += new System.EventHandler(this.Cadastro_Planos_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.beMightyDataSetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.beMightyDataSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtPMI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.BindingSource beMightyDataSetBindingSource;
        private BeMightyDataSet beMightyDataSet;
		private System.Windows.Forms.ListBox lbDescricao;
		private System.Windows.Forms.ListBox lbModalidades;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}