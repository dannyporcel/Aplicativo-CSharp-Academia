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
    public partial class Tela_Pagamento_Atendente : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp";
        DataTable dt = new DataTable("tbl_aluno");

        public Tela_Pagamento_Atendente()
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
                string selectQuery = "SELECT nome, cpf, id_aluno from tbl_aluno";
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

        private void Tela_Pagamento_Atendente_Load(object sender, EventArgs e)
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

        

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        

        private void dgPesquisaAluno_MouseClick(object sender, MouseEventArgs e)
        {
            txtNome.Text = dgPesquisaAluno.CurrentRow.Cells[0].Value.ToString();
            txtCPF.Text = dgPesquisaAluno.CurrentRow.Cells[1].Value.ToString();
            txtID_Aluno.Text = dgPesquisaAluno.CurrentRow.Cells[2].Value.ToString();

            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                string sql = @"SELECT TOP 1 *
                       FROM tbl_plano
                       WHERE id_aluno = @idAluno";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idAluno", txtID_Aluno.Text);

                SqlDataReader dr = cmd.ExecuteReader();

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

        private void btnVerifica_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID_Aluno.Text))
            {
                MessageBox.Show("Selecione um aluno primeiro!");
                return;
            }

            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                string sql = @"SELECT
                                p.nome_plano,
                                p.valor_plano,
                                p.observacao,
                                pg.id_pagamento,
                                pg.dataPagamento,
                                pg.dataVencimento,
                                pg.valor
                            FROM tbl_plano p
                            INNER JOIN tbl_pagamento pg
                                ON p.id_plano = pg.id_plano
                            WHERE p.id_aluno = @idAluno";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idAluno", txtID_Aluno.Text);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int dataPagamento = Convert.ToInt32(dr["dataPagamento"]);
                    int dataVencimento = Convert.ToInt32(dr["dataVencimento"]);

                    DateTime dtPagamento = DateTime.ParseExact(
                        dataPagamento.ToString(),
                        "yyyyMMdd",
                        null);

                    DateTime dtVencimento = DateTime.ParseExact(
                        dataVencimento.ToString(),
                        "yyyyMMdd",
                        null);

                    string situacao =
                        DateTime.Now.Date <= dtVencimento.Date
                            ? "ATIVO"
                            : "VENCIDO";

                    string mensagem =
                        "PLANO DO ALUNO\n\n" +

                        "Plano: " + dr["nome_plano"] + "\n" +
                        "Valor do Plano: R$ " + dr["valor_plano"] + "\n" +
                        "Descrição: " + dr["observacao"] + "\n\n" +

                        "PAGAMENTO\n\n" +

                        "ID Pagamento: " + dr["id_pagamento"] + "\n" +
                        "Valor Pago: R$ " + dr["valor"] + "\n" +
                        "Data Pagamento: " + dtPagamento.ToString("dd/MM/yyyy") + "\n" +
                        "Vencimento: " + dtVencimento.ToString("dd/MM/yyyy") + "\n" +
                        "Situação: " + situacao;

                    MessageBox.Show(
                        mensagem,
                        "Situação do Plano",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Este aluno não possui plano cadastrado.",
                        "Situação do Plano",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }
    }
}