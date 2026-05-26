using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace Cadastro_de_Alunos
{
    public partial class Cadastro_Planos : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp");
        SqlCommand comando = new SqlCommand();

        // Lista para armazenar modalidades selecionadas
        List<string> modalidadesSelecionadas = new List<string>();

        public Cadastro_Planos()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cadastro_Planos_Load(object sender, EventArgs e)
        {
            preencherModalidades();
            comando.Connection = conn;
        }

        private void preencherModalidades()
        {
            try
            {
                conn.Open();

                string query = "SELECT id_modalidade, nome_modal FROM tbl_modalidade WHERE modal_situacao = 'Ativo'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dtResultado = new DataTable();
                dtResultado.Clear();
                lbModalidades.DataSource = null;
                da.Fill(dtResultado);

                lbModalidades.DataSource = dtResultado;
                lbModalidades.DisplayMember = "nome_modal";
                lbModalidades.ValueMember = "id_modalidade";

                lbModalidades.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar modalidades: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lbDescricao.Items.Clear();
            txtValorTotal.Clear();
            txtNome_Plano.Clear();
            txtObservacao.Clear();
            modalidadesSelecionadas.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Validações
            if (string.IsNullOrWhiteSpace(txtNome_Plano.Text))
            {
                MessageBox.Show("Favor insira o nome do plano", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome_Plano.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtObservacao.Text))
            {
                MessageBox.Show("Favor insira a descrição do plano", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacao.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtValorTotal.Text))
            {
                MessageBox.Show("Favor insira o valor do plano", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorTotal.Focus();
                return;
            }

            if (modalidadesSelecionadas.Count == 0)
            {
                MessageBox.Show("Selecione pelo menos uma modalidade para o plano", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Converter para decimal (agora compatível com o banco)
                decimal valorPlano;
                if (!decimal.TryParse(txtValorTotal.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out valorPlano))
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido para o plano.", "Erro de Formato",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtValorTotal.Focus();
                    return;
                }

                conn.Open();

                // Obter próximo ID do plano
                comando.CommandText = "SELECT ISNULL(MAX(id_plano), 0) + 1 FROM tbl_plano";
                int proximoId = Convert.ToInt32(comando.ExecuteScalar());

                // Preparar observação com modalidades incluídas
                string observacaoCompleta = txtObservacao.Text +
                                           " | Modalidades: " +
                                           string.Join(", ", modalidadesSelecionadas);

                // Usar parameters para evitar problemas de SQL Injection e formatação
                comando.CommandText = @"INSERT INTO tbl_plano 
                                      (id_plano, nome_plano, valor_plano, data_cadastro, observacao, id_aluno, id_funcionarios) 
                                      VALUES (@id_plano, @nome_plano, @valor_plano, @data_cadastro, @observacao, @id_aluno, @id_funcionarios)";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id_plano", proximoId);
                comando.Parameters.AddWithValue("@nome_plano", txtNome_Plano.Text.Trim());
                comando.Parameters.AddWithValue("@valor_plano", valorPlano);
                comando.Parameters.AddWithValue("@data_cadastro", DateTime.Now);
                comando.Parameters.AddWithValue("@observacao", observacaoCompleta);
                comando.Parameters.AddWithValue("@id_aluno", DBNull.Value);
                comando.Parameters.AddWithValue("@id_funcionarios", 1);

                int resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show($"Plano Cadastrado com Sucesso!\nID do Plano: {proximoId}\nValor: R$ {valorPlano:F2}",
                                  "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpar campos
                    btnLimpar_Click(sender, e);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Erro de banco de dados: {sqlEx.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar plano: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnAdicionarModalidade_Click(object sender, EventArgs e)
        {
            if (lbModalidades.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)lbModalidades.SelectedItem;
                string nomeModalidade = selectedRow["nome_modal"].ToString();

                if (!modalidadesSelecionadas.Contains(nomeModalidade))
                {
                    modalidadesSelecionadas.Add(nomeModalidade);
                    lbDescricao.Items.Add(nomeModalidade);
                }
                else
                {
                    MessageBox.Show("Esta modalidade já foi adicionada ao plano.", "Atenção",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma modalidade da lista.", "Atenção",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemoverModalidade_Click(object sender, EventArgs e)
        {
            if (lbDescricao.SelectedItem != null)
            {
                string modalidadeRemover = lbDescricao.SelectedItem.ToString();
                modalidadesSelecionadas.Remove(modalidadeRemover);
                lbDescricao.Items.Remove(lbDescricao.SelectedItem);
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma modalidade para remover.", "Atenção",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Permitir números, backspace, ponto e vírgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

            // Permitir apenas um separador decimal
            if ((e.KeyChar == '.' || e.KeyChar == ',') && textBox.Text.IndexOfAny(new char[] { '.', ',' }) > -1)
            {
                e.Handled = true;
                return;
            }

            // Se for separador decimal, substituir por ponto para padronização
            if (e.KeyChar == ',')
            {
                e.Handled = true;
                textBox.Text += ".";
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void txtValorTotal_Leave(object sender, EventArgs e)
        {
            // Formatar o valor quando o campo perder o foco
            if (!string.IsNullOrWhiteSpace(txtValorTotal.Text))
            {
                if (decimal.TryParse(txtValorTotal.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
                {
                    txtValorTotal.Text = valor.ToString("F2", CultureInfo.InvariantCulture);
                }
            }
        }

        // Eventos das pictureBox (setas)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnAdicionarModalidade_Click(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnRemoverModalidade_Click(sender, e);
        }

        // Métodos não utilizados
        private void button1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void lbModalidades_Click(object sender, EventArgs e) { }
        private void lbModalidades_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lbDescricao_KeyPress(object sender, KeyPressEventArgs e) { }
        private void lbDescricao_ControlAdded(object sender, ControlEventArgs e) { }
        private void lbDescricao_Layout(object sender, LayoutEventArgs e) { }

        // Método removido - não é mais necessário
        // void carregaLista() { }
    }
}