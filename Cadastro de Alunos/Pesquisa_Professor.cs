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
    public partial class Pesquisa_Professor : Form
    {
		
		
        public Pesquisa_Professor()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("tbl_Professor");


        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtCREF.Clear();
            txtNome.Focus();
        }
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("nomeProfessor like '%{0}%'", txtNome.Text);
                dgPesquisaProf.DataSource = dv.ToTable();
            }
        }

        private void txtCREF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("regCREF like '%{0}%'", txtCREF.Text);
                dgPesquisaProf.DataSource = dv.ToTable();
            }
        }
		SqlConnection connection = new SqlConnection("Data Source=LAB02T-19;Initial Catalog=BeMighty;Integrated Security=True");
		SqlCommand command;
		private void Pesquisa_Professor_Load(object sender, EventArgs e)
        {

			populateDGV();


			/*if (conn.State == ConnectionState.Closed)
				conn.Open();*/
			//"select ID_Professor,nomeProfessor,regCREF,CPF,RG,dataNasc,Sexo,Logradouro,Complemento,numEndereco,Bairro,Cidade,UF,CEP,DDD1,Telefone,DDD2,Telefone2,Email from tbl_Professor", conn))

		}
		public void populateDGV()
		{
			string selectQuery = "SELECT * FROM tbl_Professor";
			SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
			//SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
			da.Fill(dt);
			dgPesquisaProf.DataSource = dt;
		}

		private void dgPesquisaProf_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			/*SelectedRow = e.RowIndex;
			DataGridViewRow row = dgPesquisaProf.Rows[SelectedRow];
			txtNomeEditar.Text = row.Cells[1].Value.ToString();
			txtCrefEditar.Text = row.Cells[6].Value.ToString();
			mskCpf.Text = row.Cells[2].Value.ToString();
			txtRG.Text = row.Cells[3].Value.ToString();
			mskDataNascimento.Text = row.Cells[4].Value.ToString();
			cbxSexo.Text = row.Cells[5].Value.ToString();
			txtLogradouro.Text = row.Cells[7].Value.ToString();
			txtComplemento.Text = row.Cells[8].Value.ToString();
			txtNumero.Text = row.Cells[9].Value.ToString();
			txtBairro.Text = row.Cells[10].Value.ToString();
			txtCidade.Text = row.Cells[11].Value.ToString();
			cbxUF.Text = row.Cells[12].Value.ToString();
			txtCEP.Text = row.Cells[13].Value.ToString();
			txtDDD1.Text = row.Cells[16].Value.ToString();
			txtTelefone.Text = row.Cells[14].Value.ToString();
			txtDDD2.Text = row.Cells[17].Value.ToString();
			txtTelefone2.Text = row.Cells[15].Value.ToString();
			txtEmail.Text = row.Cells[18].Value.ToString();
			txtID.Text = row.Cells[0].Value.ToString();*/

		}
		public void openConnection()
		{
			if(connection.State == ConnectionState.Closed)
			{
				connection.Open();
			}
		}
		public void closeConnection()
		{
			if(connection.State == ConnectionState.Open)
			{
				connection.Close();
			}
		}
		public void executeMyQuery(string query)
		{
			try
			{
				openConnection();
				command = new SqlCommand(query,connection);
				if (command.ExecuteNonQuery() == 1)
				{
					MessageBox.Show("Dados Atualizados com sucesso!");
				}
				else
				{
					MessageBox.Show("Falha ao Atualizar");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				closeConnection();
			}
		}

		private void btnAtualizar_Click(object sender, EventArgs e)
		{
			string validar = mskCpf.Text;

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

			if (txtCrefEditar.Text == "")
			{
				MessageBox.Show("Informe o CREF!", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtCREF.Focus();
			}
			else if (txtCEP.Text == "")
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
			 if (txtDDD1.Text == "")
			{
				MessageBox.Show("Informe o DDD", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtDDD1.Focus();
			}
			else
			{
				mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
				try
				{
					string updateQuery = "UPDATE tbl_Professor SET nomeProfessor='" + txtNomeEditar.Text + "',CPF='" + mskCpf.Text + "',RG='" + txtRG.Text + "',dataNasc='" + mskDataNascimento.Text + "',Sexo='" + cbxSexo.Text + "',regCREF='" + txtCrefEditar.Text + "',Logradouro='" + txtLogradouro.Text + "',Complemento='" + txtComplemento.Text + "',numEndereco='" + txtNumero.Text + "',Bairro='" + txtBairro.Text + "',Cidade='" + txtCidade.Text + "',UF='" + cbxUF.Text + "',CEP='" + txtCEP.Text + "',Telefone='" + txtTelefone.Text + "',Telefone2='" + txtTelefone2.Text + "',DDD1='" + txtDDD1.Text + "',DDD2='" + txtDDD2.Text + "',Email='" + txtEmail.Text + "' WHERE ID_Professor =" + int.Parse(txtID.Text);
					executeMyQuery(updateQuery);
					populateDGV();
				}
				catch
				{
					MessageBox.Show("Falaha ao atualizar", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					txtCrefEditar.Clear();

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
			txtCrefEditar.Enabled = true;
			btnCancelar.Enabled = true;
		}


		private void dgPesquisaProf_MouseClick(object sender, MouseEventArgs e)
		{
			txtNomeEditar.Text = dgPesquisaProf.CurrentRow.Cells[1].Value.ToString();
			txtCrefEditar.Text = dgPesquisaProf.CurrentRow.Cells[6].Value.ToString();
			mskCpf.Text = dgPesquisaProf.CurrentRow.Cells[2].Value.ToString();
			txtRG.Text = dgPesquisaProf.CurrentRow.Cells[3].Value.ToString();
			mskDataNascimento.Text = dgPesquisaProf.CurrentRow.Cells[4].Value.ToString();
			cbxSexo.Text = dgPesquisaProf.CurrentRow.Cells[5].Value.ToString();
			txtLogradouro.Text = dgPesquisaProf.CurrentRow.Cells[7].Value.ToString();
			txtComplemento.Text = dgPesquisaProf.CurrentRow.Cells[8].Value.ToString();
			txtNumero.Text = dgPesquisaProf.CurrentRow.Cells[9].Value.ToString();
			txtBairro.Text = dgPesquisaProf.CurrentRow.Cells[10].Value.ToString();
			txtCidade.Text = dgPesquisaProf.CurrentRow.Cells[11].Value.ToString();
			cbxUF.Text = dgPesquisaProf.CurrentRow.Cells[12].Value.ToString();
			txtCEP.Text = dgPesquisaProf.CurrentRow.Cells[13].Value.ToString();
			txtDDD1.Text = dgPesquisaProf.CurrentRow.Cells[16].Value.ToString();
			txtTelefone.Text = dgPesquisaProf.CurrentRow.Cells[14].Value.ToString();
			txtDDD2.Text = dgPesquisaProf.CurrentRow.Cells[17].Value.ToString();
			txtTelefone2.Text = dgPesquisaProf.CurrentRow.Cells[15].Value.ToString();
			txtEmail.Text = dgPesquisaProf.CurrentRow.Cells[18].Value.ToString();
			txtID.Text = dgPesquisaProf.CurrentRow.Cells[0].Value.ToString();

		}

		private void btnLimpar_Click_1(object sender, EventArgs e)
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
			txtCrefEditar.Clear();
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			btnCancelar.Enabled = false;
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
			txtCrefEditar.Enabled = false;

		}

		private void btnVoltar_Click(object sender, EventArgs e)
		{
			Form Inicial = new frmTelaInicial();
			Inicial.Show();
			this.Hide();
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

		private void txtCrefEditar_KeyPress(object sender, KeyPressEventArgs e)
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
	}
}
