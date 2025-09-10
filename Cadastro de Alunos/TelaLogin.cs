using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Alunos
{
    public partial class TelaLogin : Form
    {
		
		string usuario, senha, perfil;
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
			
			if(mskCpf.Text=="")
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
			if(rbGerente.Checked == true)
			{
                LogarGerente();
		    }
			else if(rbAtendente.Checked == true)
			{
				LogarAtendente();
                
			}						
			else
			{
				MessageBox.Show("Selecione um Perfil(Gerente ou Atendente)", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			
                     
        }
		private void LogarAtendente()//MÉTODO PARA LOGAR NA TELA DE ATENDENTE
		{
			mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
			SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");/*copiando do appconfig*/
			string selectlogin = "SELECT CPF, Senha, Cargo FROM tbl_Funcionario WHERE CPF = '" + mskCpf.Text + "' AND Senha = '" + txtSenha.Text + "'AND Cargo = 'Atendente'"; // CODIGO PARA FAZER O SELECIONAR NO BANCO
			SqlCommand comando = new SqlCommand(selectlogin, conn); // DECLARAÇÃO DO COMANDO COM O CÓDIGO A SER EXECUTADO E ONDE DEVE SER EXECUTADO
			comando.CommandType = CommandType.Text; // DEFININDO O COMANDO COMO TEXTO
		    SqlDataReader reader; // DECLARANDO UM DATAREADER UM
			try

			{
				conn.Open(); // ABRINDO A CONEXÃO
				reader = comando.ExecuteReader(); // EXECUTANDO O READER
				if (reader.Read()) // VERIFICANDO SE EXISTE ALGO PARA SER LIDO
				{
					usuario = reader[0].ToString(); //verificando se o CPF é o mesmo no banco
					senha = reader[1].ToString(); // verificando se a senha é o mesmo no banco e se está ligada ao cpf do campo usuario
                    perfil = reader[2].ToString(); // ver o cargo do usuario
					conn.Close();
					if (usuario == mskCpf.Text && senha == txtSenha.Text && perfil == "Atendente") // COMPARANDO O VALOR DAS VARIAVEIS COM O QUE FOI DIGITADO
					{
                        mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        Form Inicial = new Tela_Atendente(mskCpf.Text); // INSTANCIANDO UM FORMULARIO
						Inicial.Show(); // ABRINDO O FORMULARIO INSTANCIADO
						this.Hide(); // ESCONDENDO O FORMULARIO CORRENTE
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
			catch(Exception ex)

			{
				MessageBox.Show("Erro" + ex);
			}
		}
      
        private void LogarGerente()//MÉTODO PARA LOGAR NA TELA DE GERENTE
        {
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");/*copiando do appconfig*/
            string selectlogin = "SELECT CPF, Senha, Cargo FROM tbl_Funcionario WHERE CPF = '" + mskCpf.Text + "' AND Senha = '" + txtSenha.Text + "'AND Cargo = 'Gerente'"; // CODIGO PARA FAZER O SELECIONAR NO BANCO
            SqlCommand comando = new SqlCommand(selectlogin, conn); // DECLARAÇÃO DO COMANDO COM O CÓDIGO A SER EXECUTADO E ONDE DEVE SER EXECUTADO
            comando.CommandType = CommandType.Text; // DEFININDO O COMANDO COMO TEXTO
            SqlDataReader reader; // DECLARANDO UM DATAREADER UM
            try

            {
                conn.Open(); // ABRINDO A CONEXÃO
                reader = comando.ExecuteReader(); // EXECUTANDO O READER
                if (reader.Read()) // VERIFICANDO SE EXISTE ALGO PARA SER LIDO
                {
                    usuario = reader[0].ToString(); // ATRIBUINDO VALORES RECEBIDOS DO LEITOR ÀS VARIAVEIS
                    senha = reader[1].ToString(); // ATRIBUINDO VALORES RECEBIDOS DO LEITOR ÀS VARIAVEIS
                    perfil = reader[2].ToString(); // ATRIBUINDO VALORES RECEBIDOS DO LEITOR ÀS VARIAVEIS
                    conn.Close();
                    if (usuario == mskCpf.Text && senha == txtSenha.Text && perfil == "Gerente") // COMPARANDO O VALOR DAS VARIAVEIS COM O QUE FOI DIGITADO
                    {
                        mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        Form Inicial = new frmTelaInicial(mskCpf.Text); // INSTANCIANDO UM FORMULARIO
                        Inicial.Show(); // ABRINDO O FORMULARIO INSTANCIADO
                        this.Hide(); // ESCONDENDO O FORMULARIO CORRENTE
                    }

                }
                else
                {
                    MessageBox.Show("CPF ou senha incorretos", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show("Erro" + ex);
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
