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
        string connectionString = "Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp";
        DataTable dt = new DataTable("tbl_aluno");

        string data = DateTime.Now.ToShortDateString();

        public Tela_Pagamento()
        {
            InitializeComponent();
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
        public void populateDGV()
        {
            using (SqlConnection conn = CreateConnection())
            {
                string selectQuery = "SELECT nome, cpf from tbl_aluno";
                SqlDataAdapter da = new SqlDataAdapter(selectQuery, conn);
                DataTable tabel = new DataTable();
                da.Fill(tabel);
                dgPesquisaAluno.DataSource = tabel;
            }
        }

        private void preencher_lbPlanos()
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    conn.Open();
                    string scom = "SELECT id_plano, nome_plano, valor_plano, observacao FROM tbl_plano";
                    SqlDataAdapter da = new SqlDataAdapter(scom, conn);
                    DataTable dtResultado = new DataTable();
                    dtResultado.Clear();
                    
                    da.Fill(dtResultado);

                }
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("Falha ao efetuar a conexão. Erro: " + sqle);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void Tela_Pagamento_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = CreateConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT nome, cpf, id_aluno from tbl_aluno", conn))
                {
                    da.Fill(dt);
                    dgPesquisaAluno.DataSource = dt;
                }
            }
            preencher_lbPlanos();
            populateDGV();
        }

        private void dgPesquisaAluno_MouseClick(object sender, MouseEventArgs e)
        {
            txtNome.Text = dgPesquisaAluno.CurrentRow.Cells[0].Value.ToString();
            txtCPF.Text = dgPesquisaAluno.CurrentRow.Cells[1].Value.ToString();

            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                string query = @"
        SELECT 
            a.id_aluno,
            p.id_plano,
            p.nome_plano,
            p.observacao,
            p.valor_plano
        FROM tbl_aluno a
        INNER JOIN tbl_plano p
            ON a.id_aluno = p.id_aluno
        WHERE a.cpf = @cpf";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@cpf", txtCPF.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtID_Aluno.Text = dr["id_aluno"].ToString();
                    txtID_Plano.Text = dr["id_plano"].ToString();

                    txtPlanoEscolhido.Text = dr["nome_plano"].ToString();
                    txtDescricao.Text = dr["observacao"].ToString();
                    txtValor.Text = dr["valor_plano"].ToString();
                }
                else
                {
                    MessageBox.Show("Aluno não possui plano cadastrado.");
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("nome like '%{0}%'", textBox1.Text);
                dgPesquisaAluno.DataSource = dv.ToTable();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("cpf like '%{0}%'", textBox2.Text);
                dgPesquisaAluno.DataSource = dv.ToTable();
            }
        }
    }
}