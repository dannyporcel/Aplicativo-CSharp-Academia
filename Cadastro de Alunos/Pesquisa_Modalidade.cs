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
    public partial class Pesquisa_Modalidade : Form
    {
        public Pesquisa_Modalidade()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("tbl_Modalidade");		
		SqlConnection connection = new SqlConnection("Data Source=LAB02T-19;Initial Catalog=BeMighty;Integrated Security=True");
		SqlCommand command;
		public void populateDGV()
		{
			string selectQuery = "SELECT ID_Modalidade,nomeModal, modalTipo, modalValor, descricaoModal FROM tbl_Modalidade";
			SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
			//SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
			da.Fill(dt);
			dgPesquisaModal.DataSource = dt;
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
		private void btnSair_Click(object sender, EventArgs e)
        {
			Form Inicial = new frmTelaInicial();
			Inicial.Show();
			this.Hide();
        }
        private void Pesquisa_Modalidade_Load(object sender, EventArgs e)
        {
			populateDGV();
		}

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("nomeModal like '%{0}%'", txtNome.Text);
                dgPesquisaModal.DataSource = dv.ToTable();
            }
        }

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("modalTipo like '%{0}%'", txtTipo.Text);
                dgPesquisaModal.DataSource = dv.ToTable();
            }
        }

		private void dgPesquisaModal_MouseClick(object sender, MouseEventArgs e)
		{
			txtID.Text = dgPesquisaModal.CurrentRow.Cells[0].Value.ToString();
			txtNomeEditar.Text = dgPesquisaModal.CurrentRow.Cells[1].Value.ToString();
			txtTipoEditar.Text = dgPesquisaModal.CurrentRow.Cells[2].Value.ToString();
			txtValor.Text = dgPesquisaModal.CurrentRow.Cells[3].Value.ToString();
			txtDescricao.Text = dgPesquisaModal.CurrentRow.Cells[4].Value.ToString();
		}

		private void btnAtualizar_Click(object sender, EventArgs e)
		{
			if (txtNomeEditar.Text == "")
			{
				MessageBox.Show("Favor insira o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtNomeEditar.Focus();
			}
			else if (txtTipoEditar.Text == "")
			{
				MessageBox.Show("Favor insira o Tipo", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtTipoEditar.Focus();
			}
			else if (txtValor.Text == "")
			{
				MessageBox.Show("Favor insira o Valor", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtValor.Focus();
			}
			else if (txtDescricao.Text == "")
			{
				MessageBox.Show("Favor insira a Descrição", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtDescricao.Focus();
			}
			else
			{
				try
				{
					string updateQuery = "UPDATE tbl_Modalidade SET nomeModal='" + txtNomeEditar.Text + "', descricaoModal='" + txtTipo.Text + "',modalValor='" + txtValor.Text + "' WHERE ID_Modalidade=" + int.Parse(txtID.Text);
					executeMyQuery(updateQuery);
					populateDGV();
				}
				catch
				{
					MessageBox.Show("Falha ao atualizar a modalidade", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtNomeEditar.Clear();
					txtTipoEditar.Clear();
					txtValor.Clear();
					txtDescricao.Clear();
				}
					
			}
			
			
		}

		private void btnLimpar_Click(object sender, EventArgs e)
		{
			txtNomeEditar.Clear();
			txtTipoEditar.Clear();
			txtValor.Clear();
			txtDescricao.Clear();
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			txtNomeEditar.Enabled = true;
			txtTipoEditar.Enabled = true;
			txtValor.Enabled = true;
			txtDescricao.Enabled = true;
			btnAtualizar.Enabled = true;
			btnLimpar.Enabled = true;
			btnCancelar.Enabled = true;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			txtNomeEditar.Enabled = false;
			txtTipoEditar.Enabled = false;
			txtValor.Enabled = false;
			txtDescricao.Enabled = false;
			btnCancelar.Enabled = false;
			btnLimpar.Enabled = false;
			btnAtualizar.Enabled = false;
		}

		private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}
	}
}
