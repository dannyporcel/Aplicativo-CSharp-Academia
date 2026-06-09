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
    public partial class PesquisaAlunoAtendente : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp";
        DataTable dt = new DataTable("tbl_aluno");

        public PesquisaAlunoAtendente()
        {
            InitializeComponent();
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }

        public void populateDGV()
        {
            using (SqlConnection connection = CreateConnection())
            {
                string selectQuery = @"
                    SELECT 
                        a.id_aluno,
                        a.nome,
                        a.cpf,
                        a.genero,
                        a.data_nasc,
                        a.dd1,
                        a.telefone,
                        a.email,
                        e.rua,
                        e.numero_endereco,
                        e.bairro,
                        e.cidade,
                        e.uf,
                        e.cep,
                        e.complemento
                    FROM tbl_aluno a
                    INNER JOIN tbl_enderecoAluno e ON a.id_enderecoAluno = e.id_enderecoAluno";

                SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
                DataTable tabel = new DataTable();
                da.Fill(tabel);
                dgPesquisaAluno.DataSource = tabel;
            }
        }

        private void PesquisaAlunoAtendente_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = CreateConnection())
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT 
                        a.id_aluno,
                        a.nome,
                        a.cpf,
                        a.genero,
                        a.data_nasc,
                        a.dd1,
                        a.telefone,
                        a.email,
                        e.rua,
                        e.numero_endereco,
                        e.bairro,
                        e.cidade,
                        e.uf,
                        e.cep,
                        e.complemento
                    FROM tbl_aluno a
                    INNER JOIN tbl_enderecoAluno e ON a.id_enderecoAluno = e.id_enderecoAluno", conn))
                {
                    da.Fill(dt);
                    dgPesquisaAluno.DataSource = dt;
                }
            }
            populateDGV();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string validar = mskCPF.Text.Replace(".", "").Replace("-", "");
            mskDataNasc.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

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

            if (mskCPF.Text == "")
            {
                MessageBox.Show("Inserir CPF", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskCPF.Focus();
                return;
            }

            if (CPF.ValidaCPF(validar))
            {
                //enviar dados ao banco
            }
            else
            {
                MessageBox.Show("CPF inválido", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskCPF.Clear();
                mskCPF.Focus();
                return;
            }

            if (mskDataNasc.Text == "")
            {
                MessageBox.Show("Informe a data de nascimento", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskDataNasc.Focus();
                return;
            }


            if (txtCEP.Text == "")
            {
                MessageBox.Show("Informe o CEP", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCEP.Focus();
                return;
            }
            else if (txtLogradouro.Text == "")
            {
                MessageBox.Show("Informe o Logradouro", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLogradouro.Focus();
                return;
            }
            else if (txtNumero.Text == "")
            {
                MessageBox.Show("Informe o Número", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumero.Focus();
                return;
            }
            else if (cbxUF.Text == "")
            {
                MessageBox.Show("Informe a UF", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxUF.Focus();
                return;
            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Informe a Cidade", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCidade.Focus();
                return;
            }
            else if (txtDDD1.Text == "")
            {
                MessageBox.Show("Informe o DDD", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDDD1.Focus();
                return;
            }
            else if (txtTelefone.Text == "")
            {
                MessageBox.Show("Informe o Telefone", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefone.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    conn.Open();
                    string updateAlunoQuery = @"
                        UPDATE tbl_aluno 
                        SET 
                            nome = @nome,
                            cpf = @cpf,
                            genero = @genero,
                            data_nasc = @data_nasc,
                            dd1 = @dd1,
                            telefone = @telefone,
                            email = @email,
                            data_alteracao = GETDATE()
                        WHERE id_aluno = @id_aluno";

                    SqlCommand comandoAluno = new SqlCommand(updateAlunoQuery, conn);
                    comandoAluno.Parameters.AddWithValue("@nome", txtNomeEditar.Text);
                    comandoAluno.Parameters.AddWithValue("@cpf", long.Parse(validar));
                    comandoAluno.Parameters.AddWithValue("@genero", cbxSexo.Text);
                    comandoAluno.Parameters.AddWithValue("@data_nasc", DateTime.Parse(mskDataNasc.Text));
                    comandoAluno.Parameters.AddWithValue("@dd1", int.Parse(txtDDD1.Text));
                    comandoAluno.Parameters.AddWithValue("@telefone", long.Parse(txtTelefone.Text));
                    comandoAluno.Parameters.AddWithValue("@email", txtEmail.Text);
                    comandoAluno.Parameters.AddWithValue("@id_aluno", int.Parse(txtID.Text));

                    comandoAluno.ExecuteNonQuery();

           
                    string getEnderecoId = "SELECT id_enderecoAluno FROM tbl_aluno WHERE id_aluno = @id_aluno";
                    SqlCommand cmdEnderecoId = new SqlCommand(getEnderecoId, conn);
                    cmdEnderecoId.Parameters.AddWithValue("@id_aluno", int.Parse(txtID.Text));
                    int idEndereco = (int)cmdEnderecoId.ExecuteScalar();

                    string updateEnderecoQuery = @"
                        UPDATE tbl_enderecoAluno 
                        SET 
                            rua = @rua,
                            numero_endereco = @numero_endereco,
                            bairro = @bairro,
                            cidade = @cidade,
                            uf = @uf,
                            cep = @cep,
                            complemento = @complemento
                        WHERE id_enderecoAluno = @id_enderecoAluno";

                    SqlCommand comandoEndereco = new SqlCommand(updateEnderecoQuery, conn);
                    comandoEndereco.Parameters.AddWithValue("@rua", txtLogradouro.Text);
                    comandoEndereco.Parameters.AddWithValue("@numero_endereco", int.Parse(txtNumero.Text));
                    comandoEndereco.Parameters.AddWithValue("@bairro", txtBairro.Text);
                    comandoEndereco.Parameters.AddWithValue("@cidade", txtCidade.Text);
                    comandoEndereco.Parameters.AddWithValue("@uf", cbxUF.Text);
                    comandoEndereco.Parameters.AddWithValue("@cep", long.Parse(txtCEP.Text.Replace("-", "")));
                    comandoEndereco.Parameters.AddWithValue("@complemento", txtComplemento.Text);
                    comandoEndereco.Parameters.AddWithValue("@id_enderecoAluno", idEndereco);

                    comandoEndereco.ExecuteNonQuery();

                    MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    populateDGV();
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao atualizar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgPesquisaAluno_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgPesquisaAluno.CurrentRow != null)
            {
 
                txtID.Text = dgPesquisaAluno.CurrentRow.Cells[0].Value.ToString(); // id_aluno
                txtNomeEditar.Text = dgPesquisaAluno.CurrentRow.Cells[1].Value.ToString(); // nome
                mskCPF.Text = dgPesquisaAluno.CurrentRow.Cells[2].Value.ToString(); // cpf
                cbxSexo.Text = dgPesquisaAluno.CurrentRow.Cells[3].Value.ToString(); // genero
                mskDataNasc.Text = dgPesquisaAluno.CurrentRow.Cells[4].Value.ToString(); // data_nasc
                txtDDD1.Text = dgPesquisaAluno.CurrentRow.Cells[5].Value.ToString(); // dd1
                txtTelefone.Text = dgPesquisaAluno.CurrentRow.Cells[6].Value.ToString(); // telefone
                txtEmail.Text = dgPesquisaAluno.CurrentRow.Cells[7].Value.ToString(); // email
                txtLogradouro.Text = dgPesquisaAluno.CurrentRow.Cells[8].Value.ToString(); // rua
                txtNumero.Text = dgPesquisaAluno.CurrentRow.Cells[9].Value.ToString(); // numero_endereco
                txtBairro.Text = dgPesquisaAluno.CurrentRow.Cells[10].Value.ToString(); // bairro
                txtCidade.Text = dgPesquisaAluno.CurrentRow.Cells[11].Value.ToString(); // cidade
                cbxUF.Text = dgPesquisaAluno.CurrentRow.Cells[12].Value.ToString(); // uf
                txtCEP.Text = dgPesquisaAluno.CurrentRow.Cells[13].Value.ToString(); // cep
                txtComplemento.Text = dgPesquisaAluno.CurrentRow.Cells[14].Value.ToString(); // complemento
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("nome like '%{0}%'", txtNome.Text);
                dgPesquisaAluno.DataSource = dv.ToTable();
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("cpf like '%{0}%'", txtCPF.Text);
                dgPesquisaAluno.DataSource = dv.ToTable();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNomeEditar.Clear();
            cbxSexo.ResetText();
            mskCPF.Clear();
            mskDataNasc.Clear();
            txtCEP.Clear();
            txtLogradouro.Clear();
            txtComplemento.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            cbxUF.ResetText();
            txtTelefone.Clear();
            txtDDD1.Clear();
            txtEmail.Clear();
            txtID.Clear();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void mskDataNasc_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNomeEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNomeEditar.Enabled = true;
            cbxSexo.Enabled = true;
            mskCPF.Enabled = true;
            mskDataNasc.Enabled = true;
            txtCEP.Enabled = true;
            txtLogradouro.Enabled = true;
            txtComplemento.Enabled = true;
            txtNumero.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            cbxUF.Enabled = true;
            txtTelefone.Enabled = true;
            txtDDD1.Enabled = true;
            txtEmail.Enabled = true;
            btnAtualizar.Enabled = true;
            btnLimpar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNomeEditar.Enabled = false;
            cbxSexo.Enabled = false;
            mskCPF.Enabled = false;
            mskDataNasc.Enabled = false;
            txtCEP.Enabled = false;
            txtLogradouro.Enabled = false;
            txtComplemento.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            cbxUF.Enabled = false;
            txtTelefone.Enabled = false;
            txtDDD1.Enabled = false;
            txtEmail.Enabled = false;
            btnAtualizar.Enabled = false;
            btnLimpar.Enabled = false;
            btnCancelar.Enabled = false;
        }
    }
}