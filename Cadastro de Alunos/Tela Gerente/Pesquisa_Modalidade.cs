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
        string situacao;
        DataTable dt = new DataTable("tbl_Modalidade");		
		SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");
		SqlCommand command;
		public void populateDGV()
		{
			string selectQuery = "SELECT ID_Modalidade,nomeModal, descricaoModal, modalSituacao FROM tbl_Modalidade";
			SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
            DataTable table = new DataTable();
			da.Fill(table);
			dgPesquisaModal.DataSource = table;
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
            Close();
        }
        private void Pesquisa_Modalidade_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Modalidade,nomeModal, descricaoModal, modalSituacao FROM tbl_Modalidade", conn))
                {

                    da.Fill(dt);
                    dgPesquisaModal.DataSource = dt;
                }
            }
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
                dv.RowFilter = string.Format("descricaoModal like '%{0}%'", txtDescricao.Text);
                dgPesquisaModal.DataSource = dv.ToTable();
            }
        }

		private void dgPesquisaModal_MouseClick(object sender, MouseEventArgs e)
		{
			txtID.Text = dgPesquisaModal.CurrentRow.Cells[0].Value.ToString();
			txtNomeEditar.Text = dgPesquisaModal.CurrentRow.Cells[1].Value.ToString();						
			txtDescricao.Text = dgPesquisaModal.CurrentRow.Cells[2].Value.ToString();
            if (dgPesquisaModal.CurrentRow.Cells[3].Value.ToString() == "Ativo")
            {
                rbAtivo.Checked = true;
            }
            else
            {
                rbInativo.Checked = true;
            }
        }

		private void btnAtualizar_Click(object sender, EventArgs e)
		{
 
			if (txtNomeEditar.Text == "")
			{
				MessageBox.Show("Favor insira o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtNomeEditar.Focus();
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
					string updateQuery = "UPDATE tbl_Modalidade SET nomeModal='" + txtNomeEditar.Text + "', descricaoModal='" + txtDescricao.Text + "',modalSituacao ='"+situacao+"' WHERE ID_Modalidade=" + int.Parse(txtID.Text);
					executeMyQuery(updateQuery);
					populateDGV();
				}
				catch
				{
					MessageBox.Show("Falha ao atualizar a modalidade", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtNomeEditar.Clear();									
					txtDescricao.Clear();
				}

                Form pesquisa = new Pesquisa_Modalidade();
                pesquisa.ShowDialog();
                Close();
					
			}
			
			
		}

		private void btnLimpar_Click(object sender, EventArgs e)
		{
			txtNomeEditar.Clear();						
			txtDescricao.Clear();
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			txtNomeEditar.Enabled = true;					
			txtDescricao.Enabled = true;
			btnAtualizar.Enabled = true;
			btnLimpar.Enabled = true;
			btnCancelar.Enabled = true;
            rbAtivo.Enabled = true;
            rbInativo.Enabled = true;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			txtNomeEditar.Enabled = false;					
			txtDescricao.Enabled = false;
			btnCancelar.Enabled = false;
			btnLimpar.Enabled = false;
			btnAtualizar.Enabled = false;
            rbAtivo.Enabled = false;
            rbInativo.Enabled = false;
		}

		private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar)  || char.IsSymbol(e.KeyChar)) e.Handled = true;
            
		}

        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void rbAtivo_CheckedChanged(object sender, EventArgs e)
        {
            if(rbAtivo.Checked == true)
            {
                situacao = "Ativo";
            }
        }

        private void rbInativo_CheckedChanged(object sender, EventArgs e)
        {
            if(rbInativo.Checked == true)
            {
                situacao = "Inativo";
            }
        }

        private void rbPesquisa_Ativo_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("modalSituacao like 'Ativo'", rbPesquisa_Ativo.Text);
            dgPesquisaModal.DataSource = dv.ToTable();
        }

        private void rbPesquisa_Inativo_CheckedChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("modalSituacao like 'Inativo'", rbPesquisa_Inativo.Text);
            dgPesquisaModal.DataSource = dv.ToTable();
        }
    }
}
