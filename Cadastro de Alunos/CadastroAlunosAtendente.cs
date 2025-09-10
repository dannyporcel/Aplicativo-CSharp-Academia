using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Alunos
{
	public partial class CadastroAlunosAtendente : Form
	{
		int DiaAtual = DateTime.Now.Day;
		int MesAtual = DateTime.Now.Month;
		int AnoAtual = DateTime.Now.Year;
		string Situacao;
		string Questionario1;
		string Questionario2;
		string Questionario3;
		string Questionario4;
		string Questionario5;
		string Questionario6;
		string Questionario7;
		string Questionario8;
		string Questionario9;
		string Questionario10;
		string Senha = "123";

		SqlConnection conn = new SqlConnection("Data Source=LAB02T-19;Initial Catalog=BeMighty;Integrated Security=True");/*copiando do appconfig*//*DESKTOP-1VUTL33*/
		SqlCommand comando = new SqlCommand();/*instanciando*/

		public int CalculaIdade { get; private set; }

		/*SqlDataReader dr; leitor*/
		void carregaLista()
		{
			conn.Open();
			comando.CommandText = "select * from tbl_Aluno";
			conn.Close();
		}
		public CadastroAlunosAtendente()
		{
			InitializeComponent();
		}

		private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}

		private void mskCpf_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}

		private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}

		private void mskDataNascimento_KeyPress(object sender, KeyPressEventArgs e)
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

		private void txtDDD2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}

		private void txtTelefone2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}

		private void btnLimpar_Click(object sender, EventArgs e)
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
			txtCidade.Clear();
			mskCpf.Clear();
			txtNome.Focus();
			pbFotoAluno.Image = null;
			txtFotoLocal.Clear();
			txtDDD1.Clear();
			rbAtivo.Checked = false;
			rbInativo.Checked = false;

			cbxSexo.SelectedIndex = -1;
			cbxUF.SelectedIndex = -1;
		}

		private void btnVoltar_Click(object sender, EventArgs e)
		{
			Form Inicial = new Tela_Atendente();
			Inicial.Show();
			this.Hide();
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
				pbFotoAluno.ImageLocation = picpath;
			}
		}

		private void CadastroAlunosAtendente_Load(object sender, EventArgs e)
		{
			comando.Connection = conn;/*abertura de BD*//*usar try catch p/solucao de erro conect bd*/
			carregaLista();
		}

		private void btnAvançar_Click(object sender, EventArgs e)
		{
			string validar = mskCpf.Text;
			mskDataNascimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
			mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
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
				MessageBox.Show("Inserir CPF", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				mskCpf.Focus();
				return;
			}
			else
			{
				mskCpf.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

			}

			if (CPF.ValidaCPF(validar))
			{
				//enviar dados ao banco
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
			if (mskDataNascimento.Text == "")
			{
				MessageBox.Show("Informe a data de nascimento", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
			if (Idade.CalculoIdade(mskDataNascimento.Text))
			{

			}
			else
			{
				rbInativo.Checked = true;
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
				txtTelefone.Focus();
				return;
			}
			if (rbAtivo.Checked == false && rbInativo.Checked == false)
			{
				MessageBox.Show("Selecione a Situação", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (rbInativo.Checked == true)
			{
				panQuestionario.Visible = false;
				btnAvancar.Visible = false;
				btnCadastroCasoInativoSelecionado.Visible = true;
			}
			else
			{
				panQuestionario.Visible = true;
				gbFoto.Visible = false;
				txtFotoLocal.Visible = false;
				btnSelecFoto.Visible = false;
				gbSituacao.Visible = false;
			}
		}

		private void btnCadastrar_Click(object sender, EventArgs e)
		{
			try
			{
				//FOTO ENVIAR
				mskDataNascimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
				byte[] imagebt = null;
				FileStream fstream = new FileStream(this.txtFotoLocal.Text, FileMode.Open, FileAccess.Read);
				BinaryReader br = new BinaryReader(fstream);
				imagebt = br.ReadBytes((int)fstream.Length);
				//CPF MASK ENVIAR
				string teste = mskCpf.Text;
				mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
				string cpf1 = mskCpf.Text;
				//DATA COM BARRAS
				mskDataNascimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
				//
				conn.Open();/*abrindo base de dados*/
				comando.Parameters.Add(new SqlParameter("@IMG", imagebt));
				comando.CommandText = "insert into tbl_Aluno(nomeAluno,Genero,Logradouro,numEndereco,UF,Cidade,Telefone,RG,CEP,Bairro,Email,CPF,dataNasc,alSituacao,Foto,Telefone2,DDD1,DDD2,Complemento,questao1,questao2,questao3,questao4,questao5,questao6,questao7,questao8,questao9,questao10,Senha) values " +
					"('" + txtNome.Text + "','" + cbxSexo.Text + "','" + txtLogradouro.Text + "','" + txtNumero.Text + "','"
					+ cbxUF.Text + "','" + txtCidade.Text + "','"
					+ txtTelefone.Text + "','" + txtRG.Text + "','" + txtCEP.Text + "','"
					+ txtBairro.Text + "','" + txtEmail.Text + "','" + cpf1 + "','" + (mskDataNascimento.Text) + "','" + Situacao + "',@IMG,'" + txtTelefone2.Text + "','"
					+ txtDDD1.Text + "','" + txtDDD2.Text + "','" + txtComplemento.Text + "','" + Questionario1 + "','" + Questionario2 + "','" + Questionario3 + "','" + Questionario4 + "','" + Questionario5 + "','" + Questionario6 + "','" + Questionario7 + "','" + Questionario8 + "','" + Questionario9 + "','" + Questionario10 + "','" + Senha + "')"; /*datanasc.ToString("yyyy-MM-dd")*/
				comando.ExecuteNonQuery();/*executando bd*/
				conn.Close();/*fechar bd*/

				carregaLista();

				txtNome.Clear();
				cbxSexo.ResetText();
				txtCidade.Clear();
				txtComplemento.Clear();
				txtLogradouro.Clear();
				txtNumero.Clear();
				cbxUF.ResetText();
				txtCidade.Clear();
				txtTelefone.Clear();
				txtTelefone2.Clear();
				txtRG.Clear();
				mskCpf.Clear();
				mskDataNascimento.Clear();
				txtCEP.Clear();
				txtBairro.Clear();
				txtEmail.Clear();
				txtDDD1.Clear();
				txtDDD2.Clear();
				pbFotoAluno.Image = null;
				txtFotoLocal.Clear();
				rbAtivo.Checked = false;
				rbInativo.Checked = false;
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

		private void rbAtivo_CheckedChanged(object sender, EventArgs e)
		{
			if (rbAtivo.Checked == true)///////////TAVA ENVIANDO NADA PRO BANCO
			{
				Situacao = "Ativo";
				btnAvancar.Visible = true;
				btnCadastroCasoInativoSelecionado.Visible = false;
			}
		}

		private void rbInativo_CheckedChanged(object sender, EventArgs e)
		{

			if (rbInativo.Checked == true)///////////TAVA ENVIANDO NADA PRO BANCO
			{
				Situacao = "Inativo";
				btnAvancar.Visible = false;
				btnCadastroCasoInativoSelecionado.Visible = true;
			}
		}

		private void btnCadastroCasoInativoSelecionado_Click(object sender, EventArgs e)
		{
			string validar = mskCpf.Text;
			mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
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
				MessageBox.Show("Inserir CPF", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				mskCpf.Focus();
				return;
			}
			else
			{
				mskCpf.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

			}

			if (CPF.ValidaCPF(validar))
			{
				//enviar dados ao banco
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
			if (mskDataNascimento.Text == "")
			{
				MessageBox.Show("Informe a data de nascimento", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				mskDataNascimento.Focus();
				return;
			}
			if (Data.ValidaData(mskDataNascimento.Text))
			{

			}
			else
			{
				MessageBox.Show("Data inválida", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				mskDataNascimento.Focus();
				return;
			}

			if (txtCEP.Text == "")
			{
				MessageBox.Show("Informe o CEP", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
				txtTelefone.Focus();
				return;
			}
			if (pbFotoAluno.Image == null)
			{
				MessageBox.Show("Escolha uma Foto !", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			try
			{
				//FOTO ENVIAR
				byte[] imagebt = null;
				FileStream fstream = new FileStream(this.txtFotoLocal.Text, FileMode.Open, FileAccess.Read);
				BinaryReader br = new BinaryReader(fstream);
				imagebt = br.ReadBytes((int)fstream.Length);
				//CPF MASK ENVIAR
				string teste = mskCpf.Text;
				mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
				string cpf1 = mskCpf.Text;
				//DATA COM BARRAS
				mskDataNascimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
				//
				conn.Open();/*abrindo base de dados*/
				comando.Parameters.Add(new SqlParameter("@IMG", imagebt));
				comando.CommandText = "insert into tbl_Aluno(nomeAluno,Genero,Logradouro,numEndereco,UF,Cidade,Telefone,RG,CEP,Bairro,Email,CPF,dataNasc,alSituacao,Foto,Telefone2,DDD1,DDD2,Complemento,questao1,questao2,questao3,questao4,questao5,questao6,questao7,questao8,questao9,questao10,Senha) values " +
					"('" + txtNome.Text + "','" + cbxSexo.Text + "','" + txtLogradouro.Text + "','" + txtNumero.Text + "','"
					+ cbxUF.Text + "','" + txtCidade.Text + "','" + txtTelefone.Text + "','" + txtRG.Text + "','" + txtCEP.Text + "','"
					+ txtBairro.Text + "','" + txtEmail.Text + "','" + cpf1 + "','" + (mskDataNascimento.Text) + "','" + Situacao + "',@IMG,'" + txtTelefone2.Text + "','"
					+ txtDDD1.Text + "','" + txtDDD2.Text + "','" + txtComplemento.Text + "','" + Questionario1 + "','" + Questionario2 + "','" + Questionario3 + "','" + Questionario4 + "','" + Questionario5 + "','" + Questionario6 + "','" + Questionario7 + "','" + Questionario8 + "','" + Questionario9 + "','" + Questionario10 + "','" + Senha + "')"; /*datanasc.ToString("yyyy-MM-dd")*/
				comando.ExecuteNonQuery();/*executando bd*/
				conn.Close();/*fechar bd*/

				carregaLista();

				txtNome.Clear();
				cbxSexo.ResetText();
				txtCidade.Clear();
				txtComplemento.Clear();
				txtLogradouro.Clear();
				txtNumero.Clear();
				cbxUF.ResetText();
				txtCidade.Clear();
				txtTelefone.Clear();
				txtTelefone2.Clear();
				txtRG.Clear();
				mskCpf.Clear();
				mskDataNascimento.Clear();
				txtCEP.Clear();
				txtBairro.Clear();
				txtEmail.Clear();
				txtDDD1.Clear();
				txtDDD2.Clear();
				pbFotoAluno.Image = null;
				txtFotoLocal.Clear();
				rbAtivo.Checked = false;
				rbInativo.Checked = false;
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

		private void ckbSim1_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbSim1.Checked == true)
			{
				Questionario1 = "Sim";
			}
			else
			{
				Questionario1 = "Não";
			}
		}

		private void ckbSim2_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbSim2.Checked == true)
			{
				Questionario2 = "Sim";
			}
			else
			{
				Questionario2 = "Não";
			}
		}

		private void ckbSim3_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbSim3.Checked == true)
			{
				Questionario3 = "Sim";
			}
			else
			{
				Questionario3 = "Não";
			}
		}

		private void ckbSim4_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbSim4.Checked == true)
			{
				Questionario4 = "Sim";
			}
			else
			{
				Questionario4 = "Não";
			}
		}

		private void ckbSim5_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbSim5.Checked == true)
			{
				Questionario5 = "Sim";
			}
			else
			{
				Questionario5 = "Não";
			}
		}

		private void ckbSim6_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbSim6.Checked == true)
			{
				Questionario6 = "Sim";
			}
			else
			{
				Questionario6 = "Não";
			}
		}

		private void ckbSim7_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbSim7.Checked == true)
			{
				Questionario7 = "Sim";
			}
			else
			{
				Questionario7 = "Não";
			}
		}

		private void ckbSim8_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbSim8.Checked == true)
			{
				Questionario8 = "Sim";
			}
			else
			{
				Questionario8 = "Não";
			}
		}

		private void ckbSim9_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbSim9.Checked == true)
			{
				Questionario9 = "Sim";
			}
			else
			{
				Questionario9 = "Não";
			}
		}

		private void ckbSim10_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbSim10.Checked == true)
			{
				Questionario10 = "Sim";
			}
			else
			{
				Questionario10 = "Não";
			}
		}

		private void btnVoltarPanel_Click(object sender, EventArgs e)
		{
			panQuestionario.Visible = false;
		}
	}
}
