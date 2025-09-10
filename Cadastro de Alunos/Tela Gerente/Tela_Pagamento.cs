using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Alunos
{
    public partial class Tela_Pagamento : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");/*copiando do appconfig*//*DESKTOP-1VUTL33*/
        SqlCommand comando = new SqlCommand();/*instanciando*/
        DataTable dt = new DataTable("tbl_Aluno");

        string data = DateTime.Now.ToShortDateString();

        public Tela_Pagamento()
        {
            InitializeComponent();            
        }

        public void executeMyQuery(string query)
        {
            try
            {
                conn.Open();
                comando = new SqlCommand(query, conn);
                if (comando.ExecuteNonQuery() == 1)
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
                conn.Close();
            }
        }

        public void populateDGV()
        {
            string selectQuery = "SELECT nomeAluno,CPF,ID_Aluno from tbl_Aluno where alSituacao = 'Ativo' ";
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
            DataTable tabel = new DataTable();
            da.Fill(tabel);
          
            dgPesquisaAluno.DataSource = tabel;
        }

        private void preencher_lbPlanos()
        {

            try
            {
                conn.Open();
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("Falha ao efetuar a conexão. Erro: " + sqle);
            }
            string scom = "select * from tbl_Plano where plSituacao = 'Ativo'";
            SqlDataAdapter da = new SqlDataAdapter(scom, conn);
            DataTable dtResultado = new DataTable();
            dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
            lbPlanos.DataSource = null;
            da.Fill(dtResultado);
            lbPlanos.DataSource = dtResultado;
            lbPlanos.ValueMember = "nomePlano";
            //comboBox1.DisplayMember = "descricao";
            lbPlanos.SelectedItem = "";
            lbPlanos.Refresh();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbPlanos_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");

            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From tbl_Plano WHERE nomePlano = '" + lbPlanos.Text + "'";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtValor.Text = (dr["PlanoValor"].ToString());
                txtPlanoEscolhido.Text = (dr["nomePlano"].ToString());
                txtDescricao.Text = (dr["Observacao"].ToString());
                txtID_Plano.Text = (dr["ID_Plano"].ToString());
                txtSituacao.Text = (dr["plSituacao"].ToString());
            }
            conn.Close();

        }

        private void Tela_Pagamento_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT nomeAluno,CPF,ID_Aluno from tbl_Aluno where alSituacao = 'Ativo' ", conn))
                {

                    da.Fill(dt);
                    dgPesquisaAluno.DataSource = dt;
                }
            }
            preencher_lbPlanos();
            populateDGV();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtDescricao.Text == "")
            {
                MessageBox.Show("Selecione um plano");
            }
            else if(txtNome.Text == "")
            {
                MessageBox.Show("Selecione um aluno");
            }
            else
            {
                conn.Open();
                SqlCommand comando = conn.CreateCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT ID_Aluno From tbl_planoAluno WHERE ID_Aluno = '" + int.Parse(txtID_Aluno.Text) + "'";
                comando.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lblID_Aluno.Text = (dr["ID_Aluno"].ToString());
                }
                conn.Close();

                if (lblID_Aluno.Text != "")
                {
                    MessageBox.Show("Este aluno já tem um plano vigente", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult confirm = MessageBox.Show("Deseja cancelar o plano atual e trocar por outro plano?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm.ToString().ToUpper() == "NO")
                    {
                        MessageBox.Show("Não é possível ter mais de um plano, caso queira mudar de plano cancele o atual.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {
                        
                        string updateQuery = "UPDATE tbl_planoAluno SET  ID_Plano = '" + int.Parse(txtID_Plano.Text)+ "' WHERE ID_Aluno=" + int.Parse(txtID_Aluno.Text);
                        executeMyQuery(updateQuery);
                        txtPlanoEscolhido.Clear();
                        txtDescricao.Clear();
                        txtValor.Clear();
                        txtID_Aluno.Clear();
                        txtID_Plano.Clear();
                        txtSituacao.Clear();
                        txtCPF.Clear();
                        txtNome.Clear();

                    }
                }
                else
                {
                    try
                    {
                        conn.Open();/*abrindo base de dados*/
                        comando.Connection = conn;
                        comando.CommandText = "insert into tbl_PlanoAluno(nomePlano, PlanoValor, Observacao, plSituacao, ID_Aluno, ID_Plano, dataCadastro) values " +
                            "('" + txtPlanoEscolhido.Text + "','" + float.Parse(txtValor.Text) + "','" + txtDescricao.Text + "', '" + txtSituacao.Text + "','" + int.Parse(txtID_Aluno.Text) + "', '" + int.Parse(txtID_Plano.Text) + "', '" + data + "')";
                        comando.ExecuteNonQuery();/*executando bd*/
                        conn.Close();


                        txtPlanoEscolhido.Clear();
                        txtDescricao.Clear();
                        txtValor.Clear();
                        txtID_Aluno.Clear();
                        txtID_Plano.Clear();
                        txtSituacao.Clear();
                        txtCPF.Clear();
                        txtNome.Clear();



                        MessageBox.Show("Pagamento feito!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
               
            }
           
        }



        private void dgPesquisaAluno_MouseClick(object sender, MouseEventArgs e)
        {
            txtNome.Text = dgPesquisaAluno.CurrentRow.Cells[0].Value.ToString();
            txtCPF.Text = dgPesquisaAluno.CurrentRow.Cells[1].Value.ToString();
            txtID_Aluno.Text = dgPesquisaAluno.CurrentRow.Cells[2].Value.ToString(); 
           
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("nomeAluno like '%{0}%'", textBox1.Text);
                dgPesquisaAluno.DataSource = dv.ToTable();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("CPF like '%{0}%'", textBox2.Text);
                dgPesquisaAluno.DataSource = dv.ToTable();
            }
        }
    }
}
