namespace Cadastro_de_Alunos
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public partial class TelaLogin : Form
    {
        internal string usuario, senha, perfil;

        public TelaLogin()
        {
            InitializeComponent();
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string validar = mskCpf.Text;

            if (mskCpf.Text == "")
            {
                MessageBox.Show("Inserir CPF", "OPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskCpf.Focus();
                return;
            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("Inserir Senha", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSenha.Focus();
                return;
            }
            if (rbGerente.Checked == true)
            {
                LogarGerente();
            }
            else if (rbAtendente.Checked == true)
            {
                LogarAtendente();
            }
            else
            {
                MessageBox.Show("Selecione um Perfil (Gerente ou Atendente)", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LogarAtendente()
        {
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // ALTERADO: String de conexão para BD_Nexus
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp");

            // ALTERADO: Tabela e colunas conforme BD_Nexus
            string selectlogin = @"SELECT cpf, senha, cargo
                                 FROM tbl_funcionarios
                                 WHERE cpf = '" + mskCpf.Text + "'AND senha = '" + txtSenha.Text + "'AND cargo IN('Recepcionista', 'Atendente', 'Administrativo')";

            SqlCommand comando = new SqlCommand(selectlogin, conn);
            comando.CommandType = CommandType.Text;
            SqlDataReader reader;

            try
            {
                conn.Open();
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    usuario = reader[0].ToString();
                    senha = reader[1].ToString();
                    perfil = reader[2].ToString();
                    conn.Close();

                    if (usuario == mskCpf.Text && senha == txtSenha.Text &&
                        (perfil == "Recepcionista" || perfil == "Atendente" || perfil == "Administrativo"))
                    {
                        mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        Form Inicial = new Tela_Atendente(mskCpf.Text);
                        Inicial.Show();
                        this.Hide();

                        // ALTERADO: Verificação de senha padrão
                        if (txtSenha.Text == "1234")
                        {
                            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            MudarSenhaAtendente NovaSenha = new MudarSenhaAtendente(mskCpf.Text);
                            NovaSenha.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("CPF ou senha incorretos", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogarGerente()
        {
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // ALTERADO: String de conexão para BD_Nexus
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp");

            // ALTERADO: Tabela e colunas conforme BD_Nexus
            string selectlogin = @"SELECT cpf, senha, cargo
                                 FROM tbl_funcionarios
                                 WHERE cpf = '" + mskCpf.Text + "'AND senha = '" + txtSenha.Text + "'AND cargo = 'Gerente'";

            SqlCommand comando = new SqlCommand(selectlogin, conn);
            comando.CommandType = CommandType.Text;
            SqlDataReader reader;

            try
            {
                conn.Open();
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    usuario = reader[0].ToString();
                    senha = reader[1].ToString();
                    perfil = reader[2].ToString();
                    conn.Close();

                    if (usuario == mskCpf.Text && senha == txtSenha.Text && perfil == "Gerente")
                    {
                        mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        Form Inicial = new frmTelaInicial(mskCpf.Text);
                        Inicial.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("CPF ou senha incorretos", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mskCpf.Clear();
            txtSenha.Clear();
            if (rbAtendente.Checked == true)
            {
                rbAtendente.Checked = false;
            }
            else if (rbGerente.Checked == true)
            {
                rbGerente.Checked = false;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}