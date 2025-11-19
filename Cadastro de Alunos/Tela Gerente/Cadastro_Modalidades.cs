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

namespace Cadastro_de_Alunos
{
    public partial class Cadastro_Modalidades : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp");
        SqlCommand comando = new SqlCommand();

        void carregaLista()
        {
            try
            {
                conn.Open();
                comando.CommandText = "SELECT * FROM tbl_modalidade";
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Cadastro_Modalidades()
        {
            InitializeComponent();
        }

        // ADICIONADO: Método para obter o status selecionado
        private string ObterStatusSelecionado()
        {
            if (rbAtivo.Checked)
                return "Ativo";
            else if (rbInativo.Checked)
                return "Inativo";
            else
                return "Ativo"; // Valor padrão se nenhum estiver selecionado
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Favor insira o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return;
            }
            else if (txtDescricao.Text == "")
            {
                MessageBox.Show("Favor insira a Descrição", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescricao.Focus();
                return;
            }
            else
            {
                try
                {
                    DateTime dataAtual = DateTime.Now;

                    // ADICIONADO: Obter o status selecionado
                    string status = ObterStatusSelecionado();

                    conn.Open();

                    string insertQuery = @"INSERT INTO tbl_modalidade (
                                        nome_modal, descricao_modal, 
                                        data_cadastro, modal_situacao, id_funcionarios
                                    ) VALUES (
                                        @nome_modal, @descricao_modal, 
                                        @data_cadastro, @modal_situacao, @id_funcionarios
                                    )";

                    comando.CommandText = insertQuery;
                    comando.Parameters.Clear();

                    // Parâmetros conforme estrutura atualizada do BD_Nexus
                    comando.Parameters.Add("@nome_modal", SqlDbType.VarChar, 100).Value = txtNome.Text.Trim();
                    comando.Parameters.Add("@descricao_modal", SqlDbType.VarChar, 100).Value = txtDescricao.Text.Trim();
                    comando.Parameters.AddWithValue("@data_cadastro", dataAtual);

                    // ALTERADO: Usar o status selecionado em vez de "Ativo" fixo
                    comando.Parameters.Add("@modal_situacao", SqlDbType.VarChar, 100).Value = status;

                    // ID do funcionário (por enquanto NULL - pode ser ajustado posteriormente)
                    comando.Parameters.AddWithValue("@id_funcionarios", DBNull.Value);

                    comando.ExecuteNonQuery();
                    conn.Close();

                    carregaLista();

                    // Limpar campos
                    txtNome.Clear();
                    txtDescricao.Clear();
                    rbAtivo.Checked = true; // ADICIONADO: Reset para Ativo como padrão

                    MessageBox.Show("Modalidade Cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Erro no banco de dados: " + sqlEx.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtDescricao.Clear();
            rbAtivo.Checked = true; // ADICIONADO: Reset para Ativo como padrão
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Implementar edição se necessário
            MessageBox.Show("Funcionalidade de edição não implementada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Implementar consulta se necessário
            MessageBox.Show("Funcionalidade de consulta não implementada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cadastro_Modalidades_Load(object sender, EventArgs e)
        {
            comando.Connection = conn;
            carregaLista();

            // ADICIONADO: Definir Ativo como padrão ao carregar o formulário
            rbAtivo.Checked = true;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
                e.Handled = true;
        }

        // ADICIONADO: Eventos para garantir que apenas um RadioButton esteja selecionado
        private void rbAtivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAtivo.Checked)
            {
                // Garante que apenas um esteja selecionado
                rbInativo.Checked = false;
            }
        }

        private void rbInativo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInativo.Checked)
            {
                // Garante que apenas um esteja selecionado
                rbAtivo.Checked = false;
            }
        }
    }
}