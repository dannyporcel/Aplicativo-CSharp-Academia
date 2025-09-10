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
        string Situacao;
       
        public Pesquisa_Plano()
        {
            InitializeComponent();
        }
        
        DataTable dt = new DataTable("tbl_Plano");
		SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");
		SqlCommand command;
		public void populateDGV()
		{
            

            string selectQuery = "SELECT ID_Plano,nomePlano, planoValor, Observacao, plSituacao FROM tbl_Plano ";
            
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
            
            DataTable table = new DataTable();
			da.Fill(table);
			dgPesquisaPlano.DataSource = table;
		}

      
       /* private void preenchertxtModalidades()                                                                                                                                 
        {                                                                                                                                                                      
                                                                                                                                                                               
                                                                                                                                                                               
            connection.Open();                              
            int id = int.Parse(txtID.Text);
            String sqlSelectQuery = "select nomeModal from tbl_Modalidade where ID_Modalidade in (select ID_Modalidade from tbl_PlanoModal where ID_Plano = " + id + ")";
            SqlCommand cmd = new SqlCommand(sqlSelectQuery, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtModalidades.Text = (dr["nomeModal"].ToString());
               
            }
            connection.Close();
        }*/
        
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

      

        private void Pesquisa_Plano_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Plano,nomePlano, planoValor, Observacao, plSituacao FROM tbl_Plano", conn))
                {

                    da.Fill(dt);
                    dgPesquisaPlano.DataSource = dt;
                }
            }
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
            txtID.Clear();
            txtNomeEditar.Clear();
            txtValor.Clear();
            txtObservacao.Clear();
           
            txtID.Text = dgPesquisaPlano.CurrentRow.Cells[0].Value.ToString();
            txtNomeEditar.Text = dgPesquisaPlano.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = dgPesquisaPlano.CurrentRow.Cells[2].Value.ToString();
            txtObservacao.Text = dgPesquisaPlano.CurrentRow.Cells[3].Value.ToString();
            if(dgPesquisaPlano.CurrentRow.Cells[4].Value.ToString() == "Ativo")
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
			if(txtNomeEditar.Text == "")
			{
				MessageBox.Show("Favor insira o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtNomeEditar.Focus();
			}
			else if(txtValor.Text == "")
			{
				MessageBox.Show("Favor insira o Valor", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtValor.Focus();
			}
            else if (txtObservacao.Text == "")
            {
                MessageBox.Show("Favor insira a Observação", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtObservacao.Focus();
            }			
			else
			{
				try
				{
                    if(rbAtivo.Checked == true)
                    {
                        Situacao = "Ativo";
                    }
                    else if(rbInativo.Checked == true)
                    {
                        Situacao = "Inativo";
                    }
					string updateQuery = "UPDATE tbl_Plano SET nomePlano='" + txtNomeEditar.Text + "',planoValor='" + float.Parse( txtValor.Text) + "',Observacao='" + txtObservacao.Text + "',plSituacao='"+ Situacao +"' WHERE ID_Plano=" + int.Parse(txtID.Text);
					executeMyQuery(updateQuery);
					populateDGV();
				}
				catch
				{
					MessageBox.Show("Falha ao atualizar o plano", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtNomeEditar.Clear();
                    txtObservacao.Clear();
					txtValor.Clear();
				}

                Form Pesquisa = new Pesquisa_Plano();
                Pesquisa.ShowDialog();
                Close();
			}
		}

		private void btnLimpar_Click_1(object sender, EventArgs e)
		{
			txtNomeEditar.Clear();
			txtObservacao.Clear();
			txtValor.Clear();
            rbAtivo.Checked = false;
            rbInativo.Checked = false;

		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
            
			txtNomeEditar.Enabled = true;
			txtObservacao.Enabled = true;
			txtValor.Enabled = true;
            rbAtivo.Enabled = true;
            rbInativo.Enabled = true;
			btnAtualizar.Enabled = true;
			btnLimpar.Enabled = true;
			btnCancelar.Enabled = true;
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
            
            txtNomeEditar.Enabled = false;
			txtObservacao.Enabled = false;
			txtValor.Enabled = false;
            rbAtivo.Enabled = false;
            rbInativo.Enabled = false;
			btnAtualizar.Enabled = false;
			btnLimpar.Enabled = false;
			btnCancelar.Enabled = false;
		}
		

		private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}

       

        private void rbInativo_Pesquisa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInativo_Pesquisa.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("plSituacao like 'Inativo'", rbInativo_Pesquisa.Text);
                dgPesquisaPlano.DataSource = dv.ToTable();
            }
        }

        private void rbAtivo_Pesquisa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAtivo_Pesquisa.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("plSituacao like 'Ativo'", rbAtivo_Pesquisa.Text);
                dgPesquisaPlano.DataSource = dv.ToTable();
            }
        }
    }
}
