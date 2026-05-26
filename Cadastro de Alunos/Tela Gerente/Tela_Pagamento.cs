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
        // Removida a conexão global para evitar conflitos
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

        // Método para converter DateTime para formato YYYYMMDD (int)
        private int ConvertToIntDate(DateTime date)
        {
            return date.Year * 10000 + date.Month * 100 + date.Day;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Selecione um plano");
            }
            else if (txtNome.Text == "")
            {
                MessageBox.Show("Selecione um aluno");
            }
            else
            {
                // Verificar se o aluno já tem pagamento em aberto para este mês
                int pagamentosExistentes = 0;
                using (SqlConnection conn = CreateConnection())
                {
                    conn.Open();

                    // CORREÇÃO: Converter datas para inteiro no formato YYYYMMDD
                    int mesAtual = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + 1; // Primeiro dia do mês
                    int proximoMes = DateTime.Now.AddMonths(1).Year * 10000 + DateTime.Now.AddMonths(1).Month * 100 + 1; // Primeiro dia do próximo mês

                    SqlCommand verificaCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM tbl_pagamento WHERE id_aluno = @id_aluno AND dataVencimento >= @mesAtual AND dataVencimento < @proximoMes",
                        conn);
                    verificaCmd.Parameters.AddWithValue("@id_aluno", int.Parse(txtID_Aluno.Text));
                    verificaCmd.Parameters.AddWithValue("@mesAtual", mesAtual);
                    verificaCmd.Parameters.AddWithValue("@proximoMes", proximoMes);

                    pagamentosExistentes = (int)verificaCmd.ExecuteScalar();
                } // A conexão é fechada automaticamente aqui pelo using

                if (pagamentosExistentes > 0)
                {
                    MessageBox.Show("Este aluno já possui um pagamento para este mês", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult confirm = MessageBox.Show("Deseja gerar um novo pagamento mesmo assim?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.No)
                    {
                        return;
                    }
                }

                // Realizar o pagamento
                try
                {
                    DateTime dataPagamento = DateTime.Now;
                    DateTime dataVencimento = dataPagamento.AddMonths(1);

                    // CORREÇÃO: Converter datas para o formato inteiro YYYYMMDD
                    int dataPagamentoInt = ConvertToIntDate(dataPagamento);
                    int dataVencimentoInt = ConvertToIntDate(dataVencimento);

                    using (SqlConnection conn = CreateConnection())
                    {
                        conn.Open();

                        // CORREÇÃO: Usar valores inteiros para as datas
                        string insertQuery = @"INSERT INTO tbl_pagamento (id_pagamento, dataPagamento, dataVencimento, valor, id_aluno, id_plano) 
                                             VALUES ((SELECT ISNULL(MAX(id_pagamento), 0) + 1 FROM tbl_pagamento), 
                                             @dataPagamento, @dataVencimento, @valor, @id_aluno, @id_plano)";

                        SqlCommand comando = new SqlCommand(insertQuery, conn);
                        comando.Parameters.AddWithValue("@dataPagamento", dataPagamentoInt);
                        comando.Parameters.AddWithValue("@dataVencimento", dataVencimentoInt);
                        comando.Parameters.AddWithValue("@valor", decimal.Parse(txtValor.Text));
                        comando.Parameters.AddWithValue("@id_aluno", int.Parse(txtID_Aluno.Text));
                        comando.Parameters.AddWithValue("@id_plano", int.Parse(txtID_Plano.Text));

                        int rowsAffected = comando.ExecuteNonQuery();

                        if (rowsAffected == 1)
                        {
                            // Segundo: Atualizar data_pg do aluno (esta coluna é datetime, então manter como está)
                            string updateAluno = "UPDATE tbl_aluno SET data_pg = @dataPagamento WHERE id_aluno = @id_aluno";
                            comando = new SqlCommand(updateAluno, conn);
                            comando.Parameters.AddWithValue("@dataPagamento", dataPagamento);
                            comando.Parameters.AddWithValue("@id_aluno", int.Parse(txtID_Aluno.Text));
                            comando.ExecuteNonQuery();

                            MessageBox.Show("Pagamento realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                        }
                    } // A conexão é fechada automaticamente aqui
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro ao realizar pagamento: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimparCampos()
        {
            txtPlanoEscolhido.Clear();
            txtDescricao.Clear();
            txtValor.Clear();
            txtID_Aluno.Clear();
            txtID_Plano.Clear();
            txtCPF.Clear();
            txtNome.Clear();
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