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
    public partial class Pesquisa_Funcionario : Form
    {
        string Cargo;
        public Pesquisa_Funcionario()
        {
            InitializeComponent();
        }

        // ALTERADO: Nome da tabela e estrutura do DataTable
        DataTable dt = new DataTable("tbl_funcionarios");
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp");
        SqlCommand command;

        public void populateDGV()
        {
            // ALTERADO: Consulta SQL com colunas do BD_Nexus
            string selectQuery = @"SELECT 
                                id_funcionarios as ID_Funcionario,
                                nome as nomeFuncionario,
                                cpf as CPF,
                                genero as Sexo,
                                data_nasc as dataNasc,
                                rua as Logradouro,
                                complemento as Complemento,
                                numero_endereco as numEndereco,
                                bairro as Bairro,
                                cidade as Cidade,
                                uf as UF,
                                cep as CEP,
                                dd1 as DDD1,
                                telefone as telefone,
                                email as Email,
                                cargo as Cargo
                                FROM tbl_funcionarios";

            SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
            DataTable table = new DataTable();
            da.Fill(table);
            dgPesquisaFunc.DataSource = table;
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

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("nomeFuncionario like '%{0}%'", txtNome.Text);
                dgPesquisaFunc.DataSource = dv.ToTable();
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("CPF like '%{0}%'", txtCPF.Text);
                dgPesquisaFunc.DataSource = dv.ToTable();
            }
        }

        private void Pesquisa_Funcionario_Load(object sender, EventArgs e)
        {
            // ALTERADO: String de conexão direta (removido ConfigurationManager)
            using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp"))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // ALTERADO: Consulta SQL com colunas do BD_Nexus
                using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT 
                                                            id_funcionarios as ID_Funcionario,
                                                            nome as nomeFuncionario,
                                                            cpf as CPF,
                                                            genero as Sexo,
                                                            data_nasc as dataNasc,
                                                            rua as Logradouro,
                                                            complemento as Complemento,
                                                            numero_endereco as numEndereco,
                                                            bairro as Bairro,
                                                            cidade as Cidade,
                                                            uf as UF,
                                                            cep as CEP,
                                                            dd1 as DDD1,
                                                            telefone as telefone,
                                                            email as Email,
                                                            cargo as Cargo
                                                            FROM tbl_funcionarios", conn))
                {
                    da.Fill(dt);
                    dgPesquisaFunc.DataSource = dt;
                }
            }
            populateDGV();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdGerente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGerente.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("Cargo like 'Gerente'");
                dgPesquisaFunc.DataSource = dv.ToTable();
            }
        }

        private void rdAtendente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAtendente.Checked == true)
            {
                DataView dv = dt.DefaultView;
                // ALTERADO: Filtro para múltiplos cargos de atendimento
                dv.RowFilter = "Cargo IN ('Recepcionista', 'Atendente', 'Administrativo')";
                dgPesquisaFunc.DataSource = dv.ToTable();
            }
        }

        private void dgPesquisaFunc_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // ALTERADO: Ajuste dos índices das células conforme nova consulta
                txtNomeEditar.Text = dgPesquisaFunc.CurrentRow.Cells["nomeFuncionario"].Value.ToString();
                mskCpf.Text = dgPesquisaFunc.CurrentRow.Cells["CPF"].Value.ToString();
                // REMOVIDO: RG (não existe no BD_Nexus)
                txtRG.Text = ""; // Campo mantido mas vazio
                mskDataNascimento.Text = dgPesquisaFunc.CurrentRow.Cells["dataNasc"].Value.ToString();
                cbxSexo.Text = dgPesquisaFunc.CurrentRow.Cells["Sexo"].Value.ToString();
                txtLogradouro.Text = dgPesquisaFunc.CurrentRow.Cells["Logradouro"].Value.ToString();
                txtComplemento.Text = dgPesquisaFunc.CurrentRow.Cells["Complemento"]?.Value?.ToString() ?? "";
                txtNumero.Text = dgPesquisaFunc.CurrentRow.Cells["numEndereco"].Value.ToString();
                txtBairro.Text = dgPesquisaFunc.CurrentRow.Cells["Bairro"].Value.ToString();
                txtCidade.Text = dgPesquisaFunc.CurrentRow.Cells["Cidade"].Value.ToString();
                cbxUF.Text = dgPesquisaFunc.CurrentRow.Cells["UF"].Value.ToString();
                txtCEP.Text = dgPesquisaFunc.CurrentRow.Cells["CEP"].Value.ToString();
                txtDDD1.Text = dgPesquisaFunc.CurrentRow.Cells["DDD1"].Value.ToString();
                txtTelefone.Text = dgPesquisaFunc.CurrentRow.Cells["telefone"].Value.ToString();
                // REMOVIDO: DDD2 e telefone2 (não existem no BD_Nexus)
                txtDDD2.Text = "";
                txtTelefone2.Text = "";
                txtEmail.Text = dgPesquisaFunc.CurrentRow.Cells["Email"].Value.ToString();

                string cargoAtual = dgPesquisaFunc.CurrentRow.Cells["Cargo"].Value.ToString();
                if (cargoAtual == "Gerente")
                {
                    rbGerente.Checked = true;
                }
                else
                {
                    rbAtendente.Checked = true;
                }

                txtID.Text = dgPesquisaFunc.CurrentRow.Cells["ID_Funcionario"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // ALTERADO: Método renomeado para btnAtualizar_Click para melhor semântica
            string validar = mskCpf.Text;
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (txtNomeEditar.Text == "")
            {
                MessageBox.Show("Informe o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNomeEditar.Focus();
                return;
            }

            if (cbxSexo.Text == "")
            {
                MessageBox.Show("Informe o Sexo", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxSexo.Focus();
                return;
            }

            if (mskCpf.Text == "")
            {
                MessageBox.Show("Informe o CPF", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskCpf.Focus();
                return;
            }
            else
            {
                mskCpf.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }

            // REMOVIDO: Validação de RG (não existe no BD_Nexus)

            if (txtCEP.Text == "")
            {
                MessageBox.Show("Informe o CEP !", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCEP.Focus();
            }
            else if (txtLogradouro.Text == "")
            {
                MessageBox.Show("Informe o Logradouro", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLogradouro.Focus();
            }
            else if (txtNumero.Text == "")
            {
                MessageBox.Show("Informe o Número", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumero.Focus();
            }
            else if (cbxUF.Text == "")
            {
                MessageBox.Show("Informe a UF", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxUF.Focus();
            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Informe a Cidade", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCidade.Focus();
            }
            else if (txtDDD1.Text == "")
            {
                MessageBox.Show("Informe o DDD", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDDD1.Focus();
            }
            else if (txtTelefone.Text == "")
            {
                MessageBox.Show("Informe o Telefone", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefone.Focus();
                return;
            }

            if (rbAtendente.Checked == false && rbGerente.Checked == false)
            {
                MessageBox.Show("Informe o Cargo", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (rbAtendente.Checked == true)
                {
                    // ALTERADO: Cargos possíveis no BD_Nexus
                    Cargo = "Recepcionista"; // Ou "Atendente" ou "Administrativo"
                }
                else
                {
                    Cargo = "Gerente";
                }

                mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                try
                {
                    // ALTERADO: Query UPDATE com estrutura do BD_Nexus
                    string updateQuery = @"UPDATE tbl_funcionarios SET 
                                        nome = '" + txtNomeEditar.Text + "', " +
                                        "cpf = '" + mskCpf.Text + "', " +
                                        "genero = '" + cbxSexo.Text + "', " +
                                        "data_nasc = '" + mskDataNascimento.Text + "', " +
                                        "rua = '" + txtLogradouro.Text + "', " +
                                        "complemento = '" + txtComplemento.Text + "', " +
                                        "numero_endereco = " + txtNumero.Text + ", " +
                                        "bairro = '" + txtBairro.Text + "', " +
                                        "cidade = '" + txtCidade.Text + "', " +
                                        "uf = '" + cbxUF.Text + "', " +
                                        "cep = '" + txtCEP.Text + "', " +
                                        "dd1 = " + txtDDD1.Text + ", " +
                                        "telefone = '" + txtTelefone.Text + "', " +
                                        "email = '" + txtEmail.Text + "', " +
                                        "cargo = '" + Cargo + "' " +
                                        "WHERE id_funcionarios = " + int.Parse(txtID.Text);

                    executeMyQuery(updateQuery);
                    populateDGV();

                    MessageBox.Show("Funcionário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao atualizar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ... (os métodos restantes permanecem iguais - btnEditar, btnCancelar, btnLimpar, validações de KeyPress)
        // Mantive os métodos abaixo pois não precisam de alterações significativas

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNomeEditar.Enabled = true;
            cbxSexo.Enabled = true;
            mskCpf.Enabled = true;
            txtRG.Enabled = true;
            mskDataNascimento.Enabled = true;
            txtCEP.Enabled = true;
            txtLogradouro.Enabled = true;
            txtComplemento.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cbxUF.Enabled = true;
            txtTelefone.Enabled = true;
            txtTelefone2.Enabled = true;
            txtDDD1.Enabled = true;
            txtDDD2.Enabled = true;
            txtEmail.Enabled = true;
            btnAtualizar.Enabled = true;
            btnLimpar.Enabled = true;
            rbGerente.Enabled = true;
            rbAtendente.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNomeEditar.Enabled = false;
            cbxSexo.Enabled = false;
            mskCpf.Enabled = false;
            txtRG.Enabled = false;
            mskDataNascimento.Enabled = false;
            txtCEP.Enabled = false;
            txtLogradouro.Enabled = false;
            txtComplemento.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            cbxUF.Enabled = false;
            txtTelefone.Enabled = false;
            txtTelefone2.Enabled = false;
            txtDDD1.Enabled = false;
            txtDDD2.Enabled = false;
            txtEmail.Enabled = false;
            btnAtualizar.Enabled = false;
            btnLimpar.Enabled = false;
            rbGerente.Enabled = false;
            rbAtendente.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNomeEditar.Clear();
            cbxSexo.ResetText();
            mskCpf.Clear();
            txtRG.Clear();
            mskDataNascimento.Clear();
            txtCEP.Clear();
            txtLogradouro.Clear();
            txtComplemento.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            cbxUF.ResetText();
            txtTelefone.Clear();
            txtTelefone2.Clear();
            txtDDD1.Clear();
            txtDDD2.Clear();
            txtEmail.Clear();
            rbAtendente.Checked = false;
            rbGerente.Checked = false;
        }

        private void txtNomeEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void mskCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsLower(e.KeyChar)) e.Handled = true;
        }

        private void mskDataNascimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtDDD1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtDDD2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtTelefone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
    }
}