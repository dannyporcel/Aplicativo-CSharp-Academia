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
    public partial class Cadastro_de_Funcionários : Form
    {
        string data = DateTime.Now.ToShortDateString();
        string Perfil;
        string senha = "1234";

     SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");
     SqlCommand comando = new SqlCommand();/*instanciando*/
     void carregaLista()
     {
            conn.Open();
            comando.CommandText = "select * from tbl_Funcionario";
            conn.Close();
     }
        public Cadastro_de_Funcionários()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
			string validar = mskCpf.Text;
			mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
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

            if (mskCpf.Text == "")
            {
                MessageBox.Show("Informe o CPF", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
				MessageBox.Show("CPF Inválido", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				mskCpf.Clear();
				mskCpf.Focus();
				return;
			}

            if(txtRG.Text == "")
            {
                MessageBox.Show("Informe o RG", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			if (mskDataNascimento.Text=="")
			{		
				MessageBox.Show("Informe a Data de Nascimento", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				mskDataNascimento.Focus();
				return;
			}
			if (Data.ValidaData(mskDataNascimento.Text))
			{

			}
			else
			{
				MessageBox.Show("Data inválida", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				mskDataNascimento.Clear();
				mskDataNascimento.Focus();
				return;
			}
             if (txtCEP.Text == "")
            {
                MessageBox.Show("Informe o CEP !", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCEP.Focus();
            }
            else if (txtLogradouro.Text == "")
            {
                MessageBox.Show("Informe o Logradouro", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLogradouro.Focus();
            }
            else if (txtNumero.Text == "")
            {
                MessageBox.Show("Informe o Número", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumero.Focus();
            }
            else if (cbxUF.Text == "")
            {
                MessageBox.Show("Informe a UF", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxUF.Focus();
            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Informe a Cidade", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCidade.Focus();
            }
            else if (txtDDD1.Text == "")
            {
                MessageBox.Show("Informe o DDD", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDDD1.Focus();
            }
             else if(txtTelefone.Text == "")
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
				txtTelefone.Focus();
				return;
			}
            if (rbAtendente.Checked == false && rbGerente.Checked == false)
            {
                MessageBox.Show("Selecione o Perfil de Acesso", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    //
                    byte[] imagebt = null;
                    FileStream fstream = new FileStream(this.txtFotoLocal.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imagebt = br.ReadBytes((int)fstream.Length);
                    //
                    string teste = mskCpf.Text;
                    mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                    string cpf1 = mskCpf.Text;
                    // 				
                    mskDataNascimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    conn.Open();/*abrindo base de dados*/
                    comando.Parameters.Add(new SqlParameter("@IMG", imagebt));
                    comando.CommandText = "insert into tbl_Funcionario(nomeFuncionario,Sexo,Logradouro,numEndereco,UF,Cidade,telefone,RG,CEP,Bairro,Email,Complemento,CPF,DDD1,DDD2,Telefone_2,Cargo,dataNasc,dataCadastro,Senha,Foto) values ('"
                        + txtNome.Text + "','" + cbxSexo.Text + "','" + txtLogradouro.Text + "','" + txtNumero.Text + "','"
                        + cbxUF.Text + "','" + txtCidade.Text + "','" + txtTelefone.Text + "','" + txtRG.Text + "','"
                        + txtCEP.Text + "','" + txtBairro.Text + "','" + txtEmail.Text + "','" + txtComplemento.Text + "','"
                        + cpf1 + "','" + txtDDD1.Text + "','" + txtDDD2.Text + "','" + txtTelefone2.Text + "','" + Perfil + "','"
                        + Convert.ToDateTime(mskDataNascimento.Text) + "','"+data+"','" + senha + "',@IMG)";
                    comando.ExecuteNonQuery();/*executando bd*/

                    conn.Close();/*fechar bd*/
                                 //
                    carregaLista();
                    txtNome.Clear();
                    cbxSexo.ResetText();
                    txtLogradouro.Clear();
                    txtNumero.Clear();
                    cbxUF.ResetText();
                    txtCidade.Clear();
                    txtTelefone.Clear();
                    txtComplemento.Clear();
                    txtRG.Clear();
                    mskCpf.Clear();
                    txtCEP.Clear();
                    txtBairro.Clear();
                    txtEmail.Clear();
                    txtDDD1.Clear();
                    txtDDD2.Clear();
                    mskDataNascimento.Clear();
                    pbFotoFunc.Image = null;
                    rbAtendente.Checked = false;
                    rbGerente.Checked = false;
                    txtTelefone2.Clear();
                    txtFotoLocal.Clear();
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
        }
       

		private void btnVoltar_Click(object sender, EventArgs e)
		{
            Close();
		}

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void mskCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
                       txtNome.Clear();
                       mskCpf.Clear();
                       cbxSexo.ResetText();
                       txtRG.Clear();
                       txtCEP.Clear();
                       txtLogradouro.Clear();
                       txtNumero.Clear();
                       txtBairro.Clear();
                       txtComplemento.Clear();
                       cbxUF.ResetText();           
                       txtEmail.Clear();                                   
                       txtCidade.Clear();                       
                       txtNome.Focus();
                       pbFotoFunc.Image = null;
                       txtDDD1.Clear();
                       txtDDD2.Clear();
                       mskDataNascimento.Clear();
                       pbFotoFunc.Image = null;
                       rbAtendente.Checked = false;
                       rbGerente.Checked = false;
                       txtTelefone.Clear();
                       txtTelefone2.Clear();
                       txtFotoLocal.Clear();
                       cbxSexo.SelectedIndex = -1;
                       cbxUF.SelectedIndex = -1;
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
                pbFotoFunc.ImageLocation = picpath;
            }
        }
        
       

        private void pbFotoFunc_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void Cadastro_de_Funcionários_Load(object sender, EventArgs e)
        {
            
        }

        private void rbAtendente_CheckedChanged(object sender, EventArgs e)
        {
            Perfil = "Atendente";
        }

        private void rbGerente_CheckedChanged(object sender, EventArgs e)
        {
            Perfil = "Gerente";
        }

        private void Cadastro_de_Funcionários_Load_1(object sender, EventArgs e)
        {
            comando.Connection = conn;/*abertura de BD*//*usar try catch p/solucao de erro conect bd*/
            carregaLista();
        }
    }
}
