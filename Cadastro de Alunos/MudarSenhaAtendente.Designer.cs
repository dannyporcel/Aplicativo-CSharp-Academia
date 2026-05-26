namespace Cadastro_de_Alunos
{
    partial class MudarSenhaAtendente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MudarSenhaAtendente));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfirmarSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbMostrarSenha = new System.Windows.Forms.CheckBox();
            this.btnAtualizarSenha = new System.Windows.Forms.Button();
            this.mskCPF = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para a sua segurança por favor mude a sua senha.";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(120, 69);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(100, 20);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nova senha:";
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.Location = new System.Drawing.Point(120, 106);
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmarSenha.TabIndex = 3;
            this.txtConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirmar senha:";
            // 
            // ckbMostrarSenha
            // 
            this.ckbMostrarSenha.AutoSize = true;
            this.ckbMostrarSenha.Location = new System.Drawing.Point(127, 132);
            this.ckbMostrarSenha.Name = "ckbMostrarSenha";
            this.ckbMostrarSenha.Size = new System.Drawing.Size(93, 17);
            this.ckbMostrarSenha.TabIndex = 5;
            this.ckbMostrarSenha.Text = "Mostrar senha";
            this.ckbMostrarSenha.UseVisualStyleBackColor = true;
            this.ckbMostrarSenha.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnAtualizarSenha
            // 
            this.btnAtualizarSenha.Location = new System.Drawing.Point(129, 176);
            this.btnAtualizarSenha.Name = "btnAtualizarSenha";
            this.btnAtualizarSenha.Size = new System.Drawing.Size(91, 23);
            this.btnAtualizarSenha.TabIndex = 6;
            this.btnAtualizarSenha.Text = "Atualizar Senha";
            this.btnAtualizarSenha.UseVisualStyleBackColor = true;
            this.btnAtualizarSenha.Click += new System.EventHandler(this.btnAtualizarSenha_Click);
            // 
            // mskCPF
            // 
            this.mskCPF.Location = new System.Drawing.Point(255, 179);
            this.mskCPF.Name = "mskCPF";
            this.mskCPF.Size = new System.Drawing.Size(100, 20);
            this.mskCPF.TabIndex = 7;
            this.mskCPF.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(267, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 71);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // MudarSenhaAtendente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 211);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mskCPF);
            this.Controls.Add(this.btnAtualizarSenha);
            this.Controls.Add(this.ckbMostrarSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConfirmarSenha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MudarSenhaAtendente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mude sua senha!";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfirmarSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbMostrarSenha;
        private System.Windows.Forms.Button btnAtualizarSenha;
        private System.Windows.Forms.TextBox mskCPF;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}