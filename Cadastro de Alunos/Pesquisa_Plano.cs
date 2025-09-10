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
    public partial class Pesquisa_Plano : Form
    {
	

        public Pesquisa_Plano()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("tbl_Plano");
		SqlConnection connection = new SqlConnection("Data Source=LAB02T-19;Initial Catalog=BeMighty;Integrated Security=True");
		SqlCommand command;
		public void populateDGV()
		{
			string selectQuery = "SELECT ID_Plano,nomePlano, planoValor, Observacao,PeriodoInadimplencia  FROM tbl_Plano";
			SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
			//SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
			da.Fill(dt);
			dgPesquisaPlano.DataSource = dt;
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            
            txtNome.Focus();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            
        }

        private void Pesquisa_Plano_Load(object sender, EventArgs e)
        {
			populateDGV();
		}

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("nomePlano like '%{0}%'", txtNome.Text);
                dgPesquisaPlano.DataSource = dv.ToTable();
            }
        }

		private void dgPesquisaPlano_MouseClick(object sender, MouseEventArgs e)
		{
			txtID.Text = dgPesquisaPlano.CurrentRow.Cells[0].Value.ToString();
			txtNomeEditar.Text = dgPesquisaPlano.CurrentRow.Cells[1].Value.ToString();
			txtValor.Text = dgPesquisaPlano.CurrentRow.Cells[2].Value.ToString();
			txtPMI.Text = dgPesquisaPlano.CurrentRow.Cells[4].Value.ToString();
		}

		private void btnAtualizar_Click(object sender, EventArgs e)
		{
			if(txtNomeEditar.Text == "")
			{
				MessageBox.Show("Favor insira o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtNomeEditar.Focus();
			}
			else if(txtValor.Text == "")
			{
				MessageBox.Show("Favor insira o Valor", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtNomeEditar.Focus();
			}
			else if(txtPMI.Text == "")
			{
				MessageBox.Show("Favor informe o Período Máximo de Inadimplência", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtNomeEditar.Focus();
			}
			else
			{
				try
				{
					string updateQuery = "UPDATE tbl_Plano SET nomePlano='" + txtNomeEditar.Text + "',planoValor='" + txtValor.Text + "',PeriodoInadimplencia='" + txtPMI.Text + "' WHERE ID_Plano=" + int.Parse(txtID.Text);
					executeMyQuery(updateQuery);
					populateDGV();
				}
				catch
				{
					MessageBox.Show("Falha ao atualizar o plano", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtNomeEditar.Clear();
					txtPMI.Clear();
					txtValor.Clear();
				}
			}
		}

		private void btnLimpar_Click_1(object sender, EventArgs e)
		{
			txtNomeEditar.Clear();
			txtPMI.Clear();
			txtValor.Clear();
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			txtNomeEditar.Enabled = true;
			txtPMI.Enabled = true;
			txtValor.Enabled = true;
			btnAtualizar.Enabled = true;
			btnLimpar.Enabled = true;
			btnCancelar.Enabled = true;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			txtNomeEditar.Enabled = false;
			txtPMI.Enabled = false;
			txtValor.Enabled = false;
			btnAtualizar.Enabled = false;
			btnLimpar.Enabled = false;
			btnCancelar.Enabled = false;
		}

		private void txtPMI_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}

		private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}
	}
}
