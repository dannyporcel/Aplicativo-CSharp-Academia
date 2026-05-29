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
using iTextSharp;//E A BIBLIOTECA ITEXTSHARP E SUAS EXTENSÕES
using iTextSharp.text;//EXTENSÃO 1 (TEXT)
using iTextSharp.text.pdf;//EXTENSÃO 2 (PDF)
using System.IO;// A BIBLIOTECA DE ENTRADA E SAIDA DE ARQUIVOS

namespace Cadastro_de_Alunos
{
    public partial class Pesquisa_Plano : Form
    {
        

        public Pesquisa_Plano()
        {
            InitializeComponent();

        }

        DataTable dt = new DataTable("tbl_Plano");
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp");
        SqlCommand command;
        public void populateDGV()
        {


            string selectQuery = "SELECT id_plano, nome_plano, valor_plano, observacao FROM tbl_plano";

            SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);

            DataTable table = new DataTable();
            da.Fill(table);
            dgPesquisaPlano.DataSource = table;
        }

        private void GerarPDF()
        {
            SaveFileDialog salvar = new SaveFileDialog();

            salvar.Filter = "Arquivo PDF|*.pdf";
            salvar.Title = "Salvar Relatório";

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                Document documento = new Document(PageSize.A4);

                try
                {
                    PdfWriter.GetInstance(documento, new FileStream(salvar.FileName, FileMode.Create));

                    documento.Open();

                    Paragraph titulo = new Paragraph("RELATÓRIO DE PLANOS");
                    titulo.Alignment = Element.ALIGN_CENTER;
                    titulo.SpacingAfter = 20f;

                    documento.Add(titulo);

                    Paragraph dataGeracao = new Paragraph(
                        "Gerado em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    dataGeracao.SpacingAfter = 15;

                    documento.Add(dataGeracao);

                    PdfPTable tabela = new PdfPTable(4);
                    tabela.WidthPercentage = 100;

                    tabela.AddCell("ID");
                    tabela.AddCell("Nome");
                    tabela.AddCell("Valor");
                    tabela.AddCell("Observação");

                    foreach (DataGridViewRow row in dgPesquisaPlano.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            tabela.AddCell(row.Cells[0].Value?.ToString());
                            tabela.AddCell(row.Cells[1].Value?.ToString());
                            tabela.AddCell(row.Cells[2].Value?.ToString());
                            tabela.AddCell(row.Cells[3].Value?.ToString());
                        }
                    }

                    documento.Add(tabela);

                    documento.Close();

                    MessageBox.Show("PDF gerado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
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
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT id_plano, nome_plano, valor_plano, observacao FROM tbl_plano", conn))
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
            



        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtNomeEditar.Text == "")
            {
                MessageBox.Show("Favor insira o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNomeEditar.Focus();
            }
            else if (txtValor.Text == "")
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
                    string updateQuery = "UPDATE tbl_plano SET nome_plano='" + txtNomeEditar.Text +
                     "', valor_plano='" + float.Parse(txtValor.Text) +
                     "', observacao='" + txtObservacao.Text +
                     "' WHERE id_plano=" + int.Parse(txtID.Text);
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

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            txtNomeEditar.Enabled = true;
            txtObservacao.Enabled = true;
            txtValor.Enabled = true;
           
            btnAtualizar.Enabled = true;
            btnLimpar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            txtNomeEditar.Enabled = false;
            txtObservacao.Enabled = false;
            txtValor.Enabled = false;
           
            btnAtualizar.Enabled = false;
            btnLimpar.Enabled = false;
            btnCancelar.Enabled = false;
        }


        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            GerarPDF();
        }
    }
}