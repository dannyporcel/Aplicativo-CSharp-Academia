using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Data.SqlClient;
using System.IO;


namespace Cadastro_de_Alunos
{

    public partial class Cadastro_de_Professores : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAB02T-19;Initial Catalog=BeMighty;Integrated Security=True");/*copiando do appconfig*/
        SqlCommand comando = new SqlCommand();/*instanciando*/
        void carregaLista()
        {
            conn.Open();
            comando.CommandText = "select * from tbl_Professor";
            conn.Close();
        }
        public Cadastro_de_Professores()
        {
            InitializeComponent();
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string validar = mskCpf.Text;
            mskDataNascimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (txtNome.Text == "")
            {
                MessageBox.Show("Informe o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return;
            }
            if (cbxSexo.Text == "")
            {
                MessageBox.Show("Informe o Sexo", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxSexo.Focus();
                return;
            }

            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mskCpf.Text == "")
            {
                MessageBox.Show("Informe o CPF", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskCpf.Focus();
                return;
            }

            else
            {
                mskCpf.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }

            if (CPF.ValidaCPF(validar))
            {
                //enviar dados para o banco
            }
            else
            {
                MessageBox.Show("CPF inválido", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskCpf.Clear();
                mskCpf.Focus();
                return;
            }
            if (txtRG.Text == "")
            {
                MessageBox.Show("Informe o RG", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRG.Focus();
                return;
            }
            if (RG.ValidarRG(txtRG.Text))
            {

            }
            else
            {
                MessageBox.Show("RG Inválido", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRG.Clear();
                txtRG.Focus();
                return;
            }

            if (txtCREF.Text == "")
            {
                MessageBox.Show("Informe o CREF!", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCREF.Focus();
                return;
            }
            if (mskDataNascimento.Text == "")
            {
                MessageBox.Show("Informe a Data de nascimento!", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskDataNascimento.Focus();
                return;
            }
            if (Data.ValidaData(mskDataNascimento.Text))
            {

            }
            else
            {
                MessageBox.Show("Data Inválida", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskDataNascimento.Clear();
                mskDataNascimento.Focus();
                return;
            }
            if (txtCEP.Text == "")
            {
                MessageBox.Show("Informe o CEP", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCEP.Focus();
                return;
            }
            else if (txtLogradouro.Text == "")
            {
                MessageBox.Show("Informe o Logradouro", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLogradouro.Focus();
                return;
            }
            else if (txtNumero.Text == "")
            {
                MessageBox.Show("Informe o Número", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumero.Focus();
                return;
            }
            else if (cbxUF.Text == "")
            {
                MessageBox.Show("Informe a UF", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxUF.Focus();
                return;
            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Informe a Cidade", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCidade.Focus();
                return;
            }
            else if (txtDDD1.Text == "")
            {
                MessageBox.Show("Informe o DDD", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDDD1.Focus();
                return;
            }
            else if (txtTelefone.Text == "")
            {
                MessageBox.Show("Informe o Telefone", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefone.Focus();
                return;
            }
            if (telefone.ValidaTelefone(txtTelefone.Text))
            {

            }
            else
            {
                MessageBox.Show("O número de telefone é inválido", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefone.Clear();
                txtNumero.Focus();
                return;
            }
            if (txtSenha.Text == "")
            {
                MessageBox.Show("Insira a Senha", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSenha.Focus();
            }
            else if (txtConfirmarSenha.Text == "")
            {
                MessageBox.Show("Confirme a Senha", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtConfirmarSenha.Focus();
            }
            else if (txtConfirmarSenha.Text != txtSenha.Text)
            {
                MessageBox.Show("Senha Incorreta", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtConfirmarSenha.Clear();
                txtConfirmarSenha.Focus();
            }

            try
            {
                //Foto Enviar   
                byte[] imagebt = null;
                FileStream fstream = new FileStream(this.txtFotoLocal.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imagebt = br.ReadBytes((int)fstream.Length);
                //Cpf msk enviar
                string teste = mskCpf.Text;
                mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                string cpf1 = mskCpf.Text;
                mskDataNascimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                //conec banco
                conn.Open();/*abrindo base de dados*/
                comando.Parameters.Add(new SqlParameter("@IMG", imagebt));
                comando.CommandText = "insert into tbl_Professor(nomeProfessor,Sexo,Logradouro,numEndereco,UF,Cidade,Telefone,RG,CEP,Bairro,Email,regCREF,CPF,DDD1,DDD2,Telefone2,dataNasc,Complemento,Senha,Foto) values ('"
                    + txtNome.Text + "','" + cbxSexo.Text + "','" + txtLogradouro.Text + "','" + txtNumero.Text + "','"
                    + cbxUF.Text + "','" + txtCidade.Text + "','" + txtTelefone.Text + "','" + txtRG.Text + "','"
                    + txtCEP.Text + "','" + txtBairro.Text + "','" + txtEmail.Text + "','" + txtCREF.Text + "','"
                    + cpf1 + "','" + txtDDD1.Text + "','" + txtDDD2.Text + "','" + txtTelefone2.Text + "','"
                    + Convert.ToDateTime(mskDataNascimento.Text) + "','" + txtComplemento.Text + "','" + txtSenha.Text + "',@IMG)";
                comando.ExecuteNonQuery();/*executando bd*/
                conn.Close();/*fechar bd*/
                carregaLista();

                txtNome.Clear();
                cbxSexo.ResetText();
                txtLogradouro.Clear();
                txtNumero.Clear();
                cbxUF.ResetText();
                txtCidade.Clear();
                txtComplemento.Clear();
                mskCpf.Clear();
                txtTelefone.Clear();
                txtRG.Clear();
                mskCpf.Clear();
                txtCEP.Clear();
                txtBairro.Clear();
                txtEmail.Clear();
                txtCREF.Clear();
                mskDataNascimento.Clear();
                txtFotoLocal.Clear();
                pbFotoProf.Image = null;
                txtDDD1.Clear();
                txtDDD2.Clear();
                txtTelefone2.Clear();
                cbxSexo.SelectedIndex = -1;
                cbxUF.SelectedIndex = -1;

                MessageBox.Show("Dados Cadastrados !", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNome.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Form Inicial = new frmTelaInicial();
            Inicial.Show();
            this.Hide();
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            txtNome.Clear();
            cbxSexo.ResetText();
            txtRG.Clear();
            txtCEP.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtComplemento.Clear();
            cbxUF.ResetText();
            txtTelefone.Clear();
            txtDDD1.Clear();
            txtTelefone2.Clear();
            txtDDD2.Clear();
            txtEmail.Clear();
            txtCREF.Clear();
            txtCidade.Clear();
            txtNome.Focus();
            mskCpf.Clear();
            pbFotoProf.Image = null;
            cbxSexo.SelectedIndex = -1;
            cbxUF.SelectedIndex = -1;
        }

        private void Cadastro_de_Professores_Load(object sender, EventArgs e)
        {
            comando.Connection = conn;/*abertura de BD*//*usar try catch p/solucao de erro conect bd*/
            carregaLista();
        }

        private void btnSelecFoto_Click(object sender, EventArgs e)
        {

            OpenFileDialog img = new OpenFileDialog();

            img.InitialDirectory = "c:\\";/*qual diretório ?*/
            img.Filter = "JPG(*.JPG)|*.jpg";/*tipo de arquivo ?*/
            if (img.ShowDialog() == DialogResult.OK)
            {
                string picpath = img.FileName.ToString();
                txtFotoLocal.Text = picpath;
                pbFotoProf.ImageLocation = picpath;
            }
        }

        private void txtRG_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsLower(e.KeyChar)) e.Handled = true;
        }

        private void txtCEP_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtDDD1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtDDD2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtTelefone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void ckbMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMostrarSenha.Checked == true)
            {
                txtSenha.UseSystemPasswordChar = false;
                txtConfirmarSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                txtConfirmarSenha.UseSystemPasswordChar = true;
            }
        }
    }
}

	
		

