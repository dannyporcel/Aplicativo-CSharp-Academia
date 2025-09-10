using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Cadastro_de_Alunos
{
    public partial class Pesquisa_Funcionario : Form
    {
		string Cargo;
		public Pesquisa_Funcionario()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("tbl_Funcionario");
		SqlConnection connection = new SqlConnection("Data Source=LAB02T-19;Initial Catalog=BeMighty;Integrated Security=True");
		SqlCommand command;


		public void populateDGV()
		{
			string selectQuery = "SELECT * FROM tbl_Funcionario";
			SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
			//SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
			da.Fill(dt);
			dgPesquisaFunc.DataSource = dt;
		}

		public void openConnection()
		{
			if (connection.State == ConnectionState.Closed)
			{
				connection.Open();
			}
		}
		public void closeConnection()
		{
			if (connection.State == ConnectionState.Open)
			{
				connection.Close();
			}
		}
		public void executeMyQuery(string query)
		{
			try
			{
				openConnection();
				command = new SqlCommand(query, connection);
				if (command.ExecuteNonQuery() == 1)
				{
					MessageBox.Show("Dados Atualizados com sucesso!");
				}
				else
				{
					MessageBox.Show("Falha ao Atualizar");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				closeConnection();
			}
		}

		private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("nomeFuncionario like '%{0}%'", txtNome.Text);
                dgPesquisaFunc.DataSource = dv.ToTable();
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("CPF like '%{0}%'", txtCPF.Text);
                dgPesquisaFunc.DataSource = dv.ToTable();
            }
        }

        

        private void Pesquisa_Funcionario_Load(object sender, EventArgs e)
        {
			populateDGV();
		}

        private void btnSair_Click(object sender, EventArgs e)
        {
			Form Inicial = new frmTelaInicial();
			Inicial.Show();
			this.Hide();
        }

        private void rdGerente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGerente.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("funcSituacao like 'Gerente'", rdGerente.Text);
                dgPesquisaFunc.DataSource = dv.ToTable();
            }
        }

        private void rdAtendente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAtendente.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("funcSituacao like 'Atendente'", rdAtendente.Text);
                dgPesquisaFunc.DataSource = dv.ToTable();
            }
        }

		private void dgPesquisaFunc_MouseClick(object sender, MouseEventArgs e)
		{
			txtNomeEditar.Text = dgPesquisaFunc.CurrentRow.Cells[1].Value.ToString();			
			mskCpf.Text = dgPesquisaFunc.CurrentRow.Cells[2].Value.ToString();
			txtRG.Text = dgPesquisaFunc.CurrentRow.Cells[3].Value.ToString();
			mskDataNascimento.Text = dgPesquisaFunc.CurrentRow.Cells[4].Value.ToString();
			cbxSexo.Text = dgPesquisaFunc.CurrentRow.Cells[5].Value.ToString();
			txtLogradouro.Text = dgPesquisaFunc.CurrentRow.Cells[6].Value.ToString();
			txtComplemento.Text = dgPesquisaFunc.CurrentRow.Cells[7].Value.ToString();
			txtNumero.Text = dgPesquisaFunc.CurrentRow.Cells[8].Value.ToString();
			txtBairro.Text = dgPesquisaFunc.CurrentRow.Cells[9].Value.ToString();
			txtCidade.Text = dgPesquisaFunc.CurrentRow.Cells[10].Value.ToString();
			cbxUF.Text = dgPesquisaFunc.CurrentRow.Cells[11].Value.ToString();
			txtCEP.Text = dgPesquisaFunc.CurrentRow.Cells[12].Value.ToString();
			txtDDD1.Text = dgPesquisaFunc.CurrentRow.Cells[15].Value.ToString();
			txtTelefone.Text = dgPesquisaFunc.CurrentRow.Cells[13].Value.ToString();
			txtDDD2.Text = dgPesquisaFunc.CurrentRow.Cells[16].Value.ToString();
			txtTelefone2.Text = dgPesquisaFunc.CurrentRow.Cells[14].Value.ToString();
			txtEmail.Text = dgPesquisaFunc.CurrentRow.Cells[17].Value.ToString();
			txtID.Text = dgPesquisaFunc.CurrentRow.Cells[0].Value.ToString();
			if(dgPesquisaFunc.CurrentRow.Cells[22].Value.ToString()== "Atendente")
			{
				rbAtendente.Checked = true;
			}
			else
			{
				rbGerente.Checked = true;
			}
		
		}

		private void btnCadastrar_Click(object sender, EventArgs e)
		{
			string validar = mskCpf.Text;
			mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

			if (txtNomeEditar.Text == "")
			{
				MessageBox.Show("Informe o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtNomeEditar.Focus();
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

			if (txtRG.Text == "")
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
			if (rbAtendente.Checked == false && rbGerente.Checked == false)
			{
				MessageBox.Show("Informe o Cargo", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtTelefone.Focus();
			}
			else
			{				
				if(rbAtendente.Checked == true)
				{
					Cargo = "Atendente";
				}
				else
				{
					Cargo = "Gerente";
				}
				mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
				try
				{
					string updateQuery = "UPDATE tbl_Funcionario SET nomeFuncionario='" + txtNomeEditar.Text + "',CPF='" + mskCpf.Text + "',RG='" + txtRG.Text + "',dataNasc='" + mskDataNascimento.Text + "',Sexo='" + cbxSexo.Text + "',Logradouro='" + txtLogradouro.Text + "',Complemento='" + txtComplemento.Text + "',numEndereco='" + txtNumero.Text + "',Bairro='" + txtBairro.Text + "',Cidade='" + txtCidade.Text + "',UF='" + cbxUF.Text + "',CEP='" + txtCEP.Text + "',Telefone='" + txtTelefone.Text + "',Telefone2='" + txtTelefone2.Text + "',DDD1='" + txtDDD1.Text + "',DDD2='" + txtDDD2.Text + "',Email='" + txtEmail.Text + "',Cargo='" + Cargo + "' WHERE ID_Funcionario =" + int.Parse(txtID.Text);
					executeMyQuery(updateQuery);
					populateDGV();
				}
				catch
				{
					MessageBox.Show("Falha ao atualizar,", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			}
		}


		private void btnEditar_Click(object sender, EventArgs e)
		{
			txtNomeEditar.Enabled = true;
			cbxSexo.Enabled = true;
			mskCpf.Enabled = true;
			txtRG.Enabled = true;
			mskDataNascimento.Enabled = true;
			txtCEP.Enabled = true;
			txtLogradouro.Enabled = true;
			txtComplemento.Enabled = true;
			txtNumero.Enabled = true;
			txtBairro.Enabled = true;
			txtCidade.Enabled = true;
			cbxUF.Enabled = true;
			txtTelefone.Enabled = true;
			txtTelefone2.Enabled = true;
			txtDDD1.Enabled = true;
			txtDDD2.Enabled = true;
			txtEmail.Enabled = true;
			btnAtualizar.Enabled = true;
			btnLimpar.Enabled = true;
			rbGerente.Enabled = true;
			rbAtendente.Enabled = true;
			btnCancelar.Enabled = true;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{			
			txtNomeEditar.Enabled = false;
			cbxSexo.Enabled = false;
			mskCpf.Enabled = false;
			txtRG.Enabled = false;
			mskDataNascimento.Enabled = false;
			txtCEP.Enabled = false;
			txtLogradouro.Enabled = false;
			txtComplemento.Enabled = false;
			txtNumero.Enabled = false;
			txtBairro.Enabled = false;
			txtCidade.Enabled = false;
			cbxUF.Enabled = false;
			txtTelefone.Enabled = false;
			txtTelefone2.Enabled = false;
			txtDDD1.Enabled = false;
			txtDDD2.Enabled = false;
			txtEmail.Enabled = false;
			btnAtualizar.Enabled = false;
			btnLimpar.Enabled = false;
			rbGerente.Enabled = false;
			rbAtendente.Enabled = false;
			btnCancelar.Enabled = false;
		}

		private void btnLimpar_Click(object sender, EventArgs e)
		{
			txtNomeEditar.Clear();
			cbxSexo.ResetText();
			mskCpf.Clear();
			txtRG.Clear();
			mskDataNascimento.Clear();
			txtCEP.Clear();
			txtLogradouro.Clear();
			txtComplemento.Clear();
			txtNumero.Clear();
			txtBairro.Clear();
			txtCidade.Clear();
			cbxUF.ResetText();
			txtTelefone.Clear();
			txtTelefone2.Clear();
			txtDDD1.Clear();
			txtDDD2.Clear();
			txtEmail.Clear();
			rbAtendente.Checked = false;
			rbGerente.Checked = false;
		}

		private void txtNomeEditar_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}

		private void mskCpf_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}

		private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsLower(e.KeyChar)) e.Handled = true;
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
	}
}
