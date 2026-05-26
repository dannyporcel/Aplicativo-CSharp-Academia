namespace Cadastro_de_Alunos
{
    partial class Pesquisa_Alunos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pesquisa_Alunos));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.rdInativo = new System.Windows.Forms.RadioButton();
			this.rdAtivo = new System.Windows.Forms.RadioButton();
			this.txtCPF = new System.Windows.Forms.TextBox();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSair = new System.Windows.Forms.Button();
			this.dgPesquisaAluno = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label7 = new System.Windows.Forms.Label();
			this.pnlEditar = new System.Windows.Forms.Panel();
			this.btnEditar = new System.Windows.Forms.Button();
			this.btnLimpar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.mskCPF = new System.Windows.Forms.MaskedTextBox();
			this.mskDataNasc = new System.Windows.Forms.MaskedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cbxSexo = new System.Windows.Forms.ComboBox();
			this.txtRG = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtNomeEditar = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtCEP = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtCidade = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtLogradouro = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtComplemento = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.cbxUF = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtBairro = new System.Windows.Forms.TextBox();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtDDD2 = new System.Windows.Forms.TextBox();
			this.txtDDD1 = new System.Windows.Forms.TextBox();
			this.txtTelefone2 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.txtTelefone = new System.Windows.Forms.TextBox();
			this.gbSituacao = new System.Windows.Forms.GroupBox();
			this.rbtAtivo = new System.Windows.Forms.RadioButton();
			this.rbtInativo = new System.Windows.Forms.RadioButton();
			this.btnAtualizar = new System.Windows.Forms.Button();
			this.btnCadastroCasoInativoSelecionado = new System.Windows.Forms.Button();
			this.txtID = new System.Windows.Forms.TextBox();
			this.txtSenha = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPesquisaAluno)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.pnlEditar.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.gbSituacao.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.rdInativo);
			this.groupBox1.Controls.Add(this.rdAtivo);
			this.groupBox1.Controls.Add(this.txtCPF);
			this.groupBox1.Controls.Add(this.txtNome);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 35);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(287, 118);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pesquisar";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 23;
			this.label3.Text = "Situação:";
			// 
			// rdInativo
			// 
			this.rdInativo.AutoSize = true;
			this.rdInativo.Location = new System.Drawing.Point(124, 79);
			this.rdInativo.Name = "rdInativo";
			this.rdInativo.Size = new System.Drawing.Size(57, 17);
			this.rdInativo.TabIndex = 22;
			this.rdInativo.TabStop = true;
			this.rdInativo.Text = "Inativo";
			this.rdInativo.UseVisualStyleBackColor = true;
			this.rdInativo.CheckedChanged += new System.EventHandler(this.rdInativo_CheckedChanged);
			// 
			// rdAtivo
			// 
			this.rdAtivo.AutoSize = true;
			this.rdAtivo.Location = new System.Drawing.Point(69, 79);
			this.rdAtivo.Name = "rdAtivo";
			this.rdAtivo.Size = new System.Drawing.Size(49, 17);
			this.rdAtivo.TabIndex = 21;
			this.rdAtivo.TabStop = true;
			this.rdAtivo.Text = "Ativo";
			this.rdAtivo.UseVisualStyleBackColor = true;
			this.rdAtivo.CheckedChanged += new System.EventHandler(this.rdAtivo_CheckedChanged);
			// 
			// txtCPF
			// 
			this.txtCPF.Location = new System.Drawing.Point(51, 48);
			this.txtCPF.Name = "txtCPF";
			this.txtCPF.Size = new System.Drawing.Size(231, 20);
			this.txtCPF.TabIndex = 20;
			this.txtCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCPF_KeyPress);
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(51, 22);
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(231, 20);
			this.txtNome.TabIndex = 6;
			this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "CPF:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nome:";
			// 
			// btnSair
			// 
			this.btnSair.Location = new System.Drawing.Point(12, 205);
			this.btnSair.Name = "btnSair";
			this.btnSair.Size = new System.Drawing.Size(75, 23);
			this.btnSair.TabIndex = 22;
			this.btnSair.Text = "Voltar";
			this.btnSair.UseVisualStyleBackColor = true;
			this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
			// 
			// dgPesquisaAluno
			// 
			this.dgPesquisaAluno.AllowUserToAddRows = false;
			this.dgPesquisaAluno.AllowUserToDeleteRows = false;
			this.dgPesquisaAluno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgPesquisaAluno.Location = new System.Drawing.Point(305, 41);
			this.dgPesquisaAluno.Name = "dgPesquisaAluno";
			this.dgPesquisaAluno.ReadOnly = true;
			this.dgPesquisaAluno.Size = new System.Drawing.Size(538, 112);
			this.dgPesquisaAluno.TabIndex = 23;
			this.dgPesquisaAluno.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgPesquisaAluno_MouseClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Blue;
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.ForeColor = System.Drawing.SystemColors.Control;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(850, 29);
			this.panel1.TabIndex = 111;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(3, 3);
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
			this.label7.Location = new System.Drawing.Point(39, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 16);
			this.label7.TabIndex = 3;
			this.label7.Text = "Pesquisa de Alunos";
			// 
			// pnlEditar
			// 
			this.pnlEditar.Controls.Add(this.btnEditar);
			this.pnlEditar.Controls.Add(this.btnLimpar);
			this.pnlEditar.Controls.Add(this.btnCancelar);
			this.pnlEditar.Controls.Add(this.groupBox2);
			this.pnlEditar.Controls.Add(this.groupBox3);
			this.pnlEditar.Controls.Add(this.groupBox4);
			this.pnlEditar.Controls.Add(this.gbSituacao);
			this.pnlEditar.Controls.Add(this.btnAtualizar);
			this.pnlEditar.Controls.Add(this.btnCadastroCasoInativoSelecionado);
			this.pnlEditar.Location = new System.Drawing.Point(156, 159);
			this.pnlEditar.Name = "pnlEditar";
			this.pnlEditar.Size = new System.Drawing.Size(629, 344);
			this.pnlEditar.TabIndex = 164;
			// 
			// btnEditar
			// 
			this.btnEditar.Location = new System.Drawing.Point(527, 148);
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(75, 23);
			this.btnEditar.TabIndex = 173;
			this.btnEditar.Text = "Editar";
			this.btnEditar.UseVisualStyleBackColor = true;
			this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click_1);
			// 
			// btnLimpar
			// 
			this.btnLimpar.Enabled = false;
			this.btnLimpar.Location = new System.Drawing.Point(227, 315);
			this.btnLimpar.Name = "btnLimpar";
			this.btnLimpar.Size = new System.Drawing.Size(75, 23);
			this.btnLimpar.TabIndex = 171;
			this.btnLimpar.Text = "Limpar";
			this.btnLimpar.UseVisualStyleBackColor = true;
			this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click_1);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Enabled = false;
			this.btnCancelar.Location = new System.Drawing.Point(359, 315);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 172;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.mskCPF);
			this.groupBox2.Controls.Add(this.mskDataNasc);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.cbxSexo);
			this.groupBox2.Controls.Add(this.txtRG);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.txtNomeEditar);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(13, 11);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(473, 111);
			this.groupBox2.TabIndex = 165;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Dados Pessoais:";
			// 
			// mskCPF
			// 
			this.mskCPF.Enabled = false;
			this.mskCPF.Location = new System.Drawing.Point(52, 48);
			this.mskCPF.Mask = "000,000,000-00";
			this.mskCPF.Name = "mskCPF";
			this.mskCPF.Size = new System.Drawing.Size(85, 20);
			this.mskCPF.TabIndex = 18;
			this.mskCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mskCPF_KeyPress);
			// 
			// mskDataNasc
			// 
			this.mskDataNasc.Enabled = false;
			this.mskDataNasc.Location = new System.Drawing.Point(143, 77);
			this.mskDataNasc.Mask = "00/00/0000";
			this.mskDataNasc.Name = "mskDataNasc";
			this.mskDataNasc.Size = new System.Drawing.Size(68, 20);
			this.mskDataNasc.TabIndex = 23;
			this.mskDataNasc.ValidatingType = typeof(System.DateTime);
			this.mskDataNasc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mskDataNasc_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(141, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "*RG:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(304, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "*Gênero:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(10, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(131, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "*Data de Nascimento:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(5, 25);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 13);
			this.label8.TabIndex = 7;
			this.label8.Text = "*Nome:";
			// 
			// cbxSexo
			// 
			this.cbxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSexo.Enabled = false;
			this.cbxSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxSexo.FormattingEnabled = true;
			this.cbxSexo.Items.AddRange(new object[] {
            "",
            "Masculino",
            "Feminino",
            "Outro"});
			this.cbxSexo.Location = new System.Drawing.Point(362, 22);
			this.cbxSexo.Name = "cbxSexo";
			this.cbxSexo.Size = new System.Drawing.Size(103, 21);
			this.cbxSexo.TabIndex = 12;
			// 
			// txtRG
			// 
			this.txtRG.Enabled = false;
			this.txtRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRG.Location = new System.Drawing.Point(177, 48);
			this.txtRG.MaxLength = 9;
			this.txtRG.Name = "txtRG";
			this.txtRG.Size = new System.Drawing.Size(116, 20);
			this.txtRG.TabIndex = 20;
			this.txtRG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRG_KeyPress);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(12, 51);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(39, 13);
			this.label9.TabIndex = 13;
			this.label9.Text = "*CPF:";
			// 
			// txtNomeEditar
			// 
			this.txtNomeEditar.Enabled = false;
			this.txtNomeEditar.Location = new System.Drawing.Point(53, 22);
			this.txtNomeEditar.Name = "txtNomeEditar";
			this.txtNomeEditar.Size = new System.Drawing.Size(241, 20);
			this.txtNomeEditar.TabIndex = 2;
			this.txtNomeEditar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomeEditar_KeyPress);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtCEP);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.txtCidade);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.txtLogradouro);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.txtComplemento);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.cbxUF);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.txtBairro);
			this.groupBox3.Controls.Add(this.txtNumero);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(13, 128);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(473, 101);
			this.groupBox3.TabIndex = 166;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Endreço:";
			// 
			// txtCEP
			// 
			this.txtCEP.Enabled = false;
			this.txtCEP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCEP.Location = new System.Drawing.Point(52, 17);
			this.txtCEP.MaxLength = 8;
			this.txtCEP.Name = "txtCEP";
			this.txtCEP.Size = new System.Drawing.Size(126, 20);
			this.txtCEP.TabIndex = 26;
			this.txtCEP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCEP_KeyPress);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(2, 24);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(48, 13);
			this.label10.TabIndex = 29;
			this.label10.Text = "*C.E.P:";
			// 
			// txtCidade
			// 
			this.txtCidade.Enabled = false;
			this.txtCidade.Location = new System.Drawing.Point(299, 69);
			this.txtCidade.Name = "txtCidade";
			this.txtCidade.Size = new System.Drawing.Size(159, 20);
			this.txtCidade.TabIndex = 45;
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(5, 50);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(36, 14);
			this.label11.TabIndex = 31;
			this.label11.Text = "*Nº:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(0, 72);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(49, 13);
			this.label12.TabIndex = 30;
			this.label12.Text = "*Bairro:";
			// 
			// txtLogradouro
			// 
			this.txtLogradouro.Enabled = false;
			this.txtLogradouro.Location = new System.Drawing.Point(300, 17);
			this.txtLogradouro.Name = "txtLogradouro";
			this.txtLogradouro.Size = new System.Drawing.Size(158, 20);
			this.txtLogradouro.TabIndex = 28;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(219, 20);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(80, 13);
			this.label14.TabIndex = 34;
			this.label14.Text = "*Logradouro:";
			// 
			// txtComplemento
			// 
			this.txtComplemento.Enabled = false;
			this.txtComplemento.Location = new System.Drawing.Point(300, 43);
			this.txtComplemento.Name = "txtComplemento";
			this.txtComplemento.Size = new System.Drawing.Size(158, 20);
			this.txtComplemento.TabIndex = 38;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(220, 46);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(74, 13);
			this.label13.TabIndex = 33;
			this.label13.Text = "Complemento:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(238, 72);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(55, 13);
			this.label15.TabIndex = 32;
			this.label15.Text = "*Cidade:";
			// 
			// cbxUF
			// 
			this.cbxUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxUF.Enabled = false;
			this.cbxUF.FormattingEnabled = true;
			this.cbxUF.Items.AddRange(new object[] {
            "",
            "AC",
            "AL",
            "AP",
            "AM",
            "BA  ",
            "CE  ",
            "DF ",
            "ES ",
            "GO",
            "MA ",
            "MT",
            "MS",
            "MG",
            "PA",
            "PB",
            "PR",
            "PE",
            "PI",
            "RJ",
            "RN",
            "RS",
            "RO",
            "RR",
            "SC",
            "SP",
            "SE",
            "TO"});
			this.cbxUF.Location = new System.Drawing.Point(130, 43);
			this.cbxUF.Name = "cbxUF";
			this.cbxUF.Size = new System.Drawing.Size(48, 21);
			this.cbxUF.TabIndex = 36;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(96, 47);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 13);
			this.label16.TabIndex = 35;
			this.label16.Text = "*UF:";
			// 
			// txtBairro
			// 
			this.txtBairro.Enabled = false;
			this.txtBairro.Location = new System.Drawing.Point(52, 70);
			this.txtBairro.Name = "txtBairro";
			this.txtBairro.Size = new System.Drawing.Size(126, 20);
			this.txtBairro.TabIndex = 43;
			// 
			// txtNumero
			// 
			this.txtNumero.Enabled = false;
			this.txtNumero.Location = new System.Drawing.Point(52, 44);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(38, 20);
			this.txtNumero.TabIndex = 31;
			this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtDDD2);
			this.groupBox4.Controls.Add(this.txtDDD1);
			this.groupBox4.Controls.Add(this.txtTelefone2);
			this.groupBox4.Controls.Add(this.label17);
			this.groupBox4.Controls.Add(this.txtEmail);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.label19);
			this.groupBox4.Controls.Add(this.txtTelefone);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.Location = new System.Drawing.Point(13, 235);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(473, 69);
			this.groupBox4.TabIndex = 167;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Contatos:";
			// 
			// txtDDD2
			// 
			this.txtDDD2.Enabled = false;
			this.txtDDD2.Location = new System.Drawing.Point(275, 13);
			this.txtDDD2.MaxLength = 2;
			this.txtDDD2.Name = "txtDDD2";
			this.txtDDD2.Size = new System.Drawing.Size(30, 20);
			this.txtDDD2.TabIndex = 53;
			this.txtDDD2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDDD2_KeyPress);
			// 
			// txtDDD1
			// 
			this.txtDDD1.Enabled = false;
			this.txtDDD1.Location = new System.Drawing.Point(69, 13);
			this.txtDDD1.MaxLength = 2;
			this.txtDDD1.Name = "txtDDD1";
			this.txtDDD1.Size = new System.Drawing.Size(30, 20);
			this.txtDDD1.TabIndex = 48;
			this.txtDDD1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDDD1_KeyPress);
			// 
			// txtTelefone2
			// 
			this.txtTelefone2.Enabled = false;
			this.txtTelefone2.Location = new System.Drawing.Point(311, 13);
			this.txtTelefone2.MaxLength = 9;
			this.txtTelefone2.Name = "txtTelefone2";
			this.txtTelefone2.Size = new System.Drawing.Size(92, 20);
			this.txtTelefone2.TabIndex = 56;
			this.txtTelefone2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone2_KeyPress);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(2, 16);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(66, 13);
			this.label17.TabIndex = 38;
			this.label17.Text = "*Telefone:";
			// 
			// txtEmail
			// 
			this.txtEmail.Enabled = false;
			this.txtEmail.Location = new System.Drawing.Point(68, 42);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(129, 20);
			this.txtEmail.TabIndex = 60;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(211, 16);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(58, 13);
			this.label18.TabIndex = 39;
			this.label18.Text = "Telefone2:";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(16, 42);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(39, 13);
			this.label19.TabIndex = 40;
			this.label19.Text = "E-Mail:";
			// 
			// txtTelefone
			// 
			this.txtTelefone.Enabled = false;
			this.txtTelefone.Location = new System.Drawing.Point(105, 13);
			this.txtTelefone.MaxLength = 9;
			this.txtTelefone.Name = "txtTelefone";
			this.txtTelefone.Size = new System.Drawing.Size(92, 20);
			this.txtTelefone.TabIndex = 50;
			this.txtTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefone_KeyPress);
			// 
			// gbSituacao
			// 
			this.gbSituacao.Controls.Add(this.rbtAtivo);
			this.gbSituacao.Controls.Add(this.rbtInativo);
			this.gbSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbSituacao.Location = new System.Drawing.Point(492, 19);
			this.gbSituacao.Name = "gbSituacao";
			this.gbSituacao.Size = new System.Drawing.Size(131, 50);
			this.gbSituacao.TabIndex = 169;
			this.gbSituacao.TabStop = false;
			this.gbSituacao.Text = "Situação:";
			// 
			// rbtAtivo
			// 
			this.rbtAtivo.AutoSize = true;
			this.rbtAtivo.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.rbtAtivo.Enabled = false;
			this.rbtAtivo.Location = new System.Drawing.Point(9, 23);
			this.rbtAtivo.Name = "rbtAtivo";
			this.rbtAtivo.Size = new System.Drawing.Size(49, 17);
			this.rbtAtivo.TabIndex = 67;
			this.rbtAtivo.Text = "Ativo";
			this.rbtAtivo.UseVisualStyleBackColor = false;
			this.rbtAtivo.CheckedChanged += new System.EventHandler(this.rbtAtivo_CheckedChanged);
			// 
			// rbtInativo
			// 
			this.rbtInativo.AutoSize = true;
			this.rbtInativo.Enabled = false;
			this.rbtInativo.Location = new System.Drawing.Point(64, 23);
			this.rbtInativo.Name = "rbtInativo";
			this.rbtInativo.Size = new System.Drawing.Size(57, 17);
			this.rbtInativo.TabIndex = 67;
			this.rbtInativo.Text = "Inativo";
			this.rbtInativo.UseVisualStyleBackColor = false;
			this.rbtInativo.CheckedChanged += new System.EventHandler(this.rbtInativo_CheckedChanged);
			// 
			// btnAtualizar
			// 
			this.btnAtualizar.Enabled = false;
			this.btnAtualizar.Location = new System.Drawing.Point(111, 315);
			this.btnAtualizar.Name = "btnAtualizar";
			this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
			this.btnAtualizar.TabIndex = 170;
			this.btnAtualizar.Text = "Atualizar";
			this.btnAtualizar.UseVisualStyleBackColor = true;
			this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
			// 
			// btnCadastroCasoInativoSelecionado
			// 
			this.btnCadastroCasoInativoSelecionado.Enabled = false;
			this.btnCadastroCasoInativoSelecionado.Location = new System.Drawing.Point(111, 315);
			this.btnCadastroCasoInativoSelecionado.Margin = new System.Windows.Forms.Padding(2);
			this.btnCadastroCasoInativoSelecionado.Name = "btnCadastroCasoInativoSelecionado";
			this.btnCadastroCasoInativoSelecionado.Size = new System.Drawing.Size(75, 23);
			this.btnCadastroCasoInativoSelecionado.TabIndex = 164;
			this.btnCadastroCasoInativoSelecionado.Text = "Cadastrar";
			this.btnCadastroCasoInativoSelecionado.UseVisualStyleBackColor = true;
			// 
			// txtID
			// 
			this.txtID.Enabled = false;
			this.txtID.Location = new System.Drawing.Point(63, 300);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(38, 20);
			this.txtID.TabIndex = 46;
			this.txtID.Visible = false;
			// 
			// txtSenha
			// 
			this.txtSenha.Enabled = false;
			this.txtSenha.Location = new System.Drawing.Point(63, 359);
			this.txtSenha.Name = "txtSenha";
			this.txtSenha.Size = new System.Drawing.Size(38, 20);
			this.txtSenha.TabIndex = 165;
			this.txtSenha.Text = "123";
			this.txtSenha.Visible = false;
			// 
			// Pesquisa_Alunos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(850, 516);
			this.Controls.Add(this.txtSenha);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.pnlEditar);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dgPesquisaAluno);
			this.Controls.Add(this.btnSair);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Pesquisa_Alunos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Pesquisa_Alunos";
			this.Load += new System.EventHandler(this.Pesquisa_Alunos_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgPesquisaAluno)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.pnlEditar.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.gbSituacao.ResumeLayout(false);
			this.gbSituacao.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView dgPesquisaAluno;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdInativo;
        private System.Windows.Forms.RadioButton rdAtivo;
		private System.Windows.Forms.Panel pnlEditar;
		private System.Windows.Forms.Button btnLimpar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.MaskedTextBox mskCPF;
		private System.Windows.Forms.MaskedTextBox mskDataNasc;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cbxSexo;
		private System.Windows.Forms.TextBox txtRG;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtNomeEditar;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtCEP;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtCidade;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtLogradouro;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtComplemento;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox cbxUF;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtBairro;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtDDD2;
		private System.Windows.Forms.TextBox txtDDD1;
		private System.Windows.Forms.TextBox txtTelefone2;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtTelefone;
		private System.Windows.Forms.GroupBox gbSituacao;
		private System.Windows.Forms.RadioButton rbtAtivo;
		private System.Windows.Forms.RadioButton rbtInativo;
		private System.Windows.Forms.Button btnAtualizar;
		private System.Windows.Forms.Button btnCadastroCasoInativoSelecionado;
		private System.Windows.Forms.Button btnEditar;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.TextBox txtSenha;
	}
}