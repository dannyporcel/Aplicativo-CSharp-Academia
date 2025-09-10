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
        public void carregaLista()
        {
            connection.Open();
            command.CommandText = "select * from tbl_Plano";
            connection.Close();
        }
        


        int DiaAtual = DateTime.Now.Day;
        int MesAtual = DateTime.Now.Month;
        int AnoAtual = DateTime.Now.Year;
        string Situacao;
        public PesquisaAlunoAtendente()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");
        SqlCommand command;
        DataTable dt = new DataTable("tbl_Aluno");

        public void populateDGV()
        {
            string selectQuery = "SELECT nomeAluno,CPF,RG,dataNasc,Genero,Logradouro,Complemento,numEndereco,Bairro,Cidade,UF,CEP,Telefone,Telefone_2,DDD1,DDD2,Email,alSituacao,ID_Aluno from tbl_Aluno";
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
            DataTable tabel = new DataTable();
            da.Fill(tabel);
            dgPesquisaAluno.DataSource = tabel;
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNomeEditar.Clear();
            cbxSexo.ResetText();
            mskCPF.Clear();
            txtRG.Clear();
            mskDataNasc.Clear();
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
            rbtAtivo.Checked = false;
            rbtInativo.Checked = false;

        }

        private void PesquisaAlunoAtendente_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT nomeAluno,CPF,RG,dataNasc,Genero,Logradouro,numEndereco,Bairro,Cidade,UF,CEP,Complemento,telefone,telefone_2,DDD1,DDD2,Email,alSituacao,ID_Aluno from tbl_Aluno", conn))
                {

                    da.Fill(dt);
                    dgPesquisaAluno.DataSource = dt;
                }
            }
            populateDGV();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("nomeAluno like '%{0}%'", txtNome.Text);
                dgPesquisaAluno.DataSource = dv.ToTable();
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("CPF like '%{0}%'", txtCPF.Text);
                dgPesquisaAluno.DataSource = dv.ToTable();
            }
        }

        private void rdAtivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAtivo.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("alSituacao like 'Ativo'", rdAtivo.Text);
                dgPesquisaAluno.DataSource = dv.ToTable();
            }
        }

        private void rdInativo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdInativo.Checked == true)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("alSituacao like 'Inativo'", rdInativo.Text);
                dgPesquisaAluno.DataSource = dv.ToTable();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNomeEditar.Enabled = true;
            cbxSexo.Enabled = true;
            mskCPF.Enabled = true;
            txtRG.Enabled = true;
            mskDataNasc.Enabled = true;
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
            rbtAtivo.Enabled = true;
            rbtInativo.Enabled = true;
            btnAtualizar.Enabled = true;
            btnLimpar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNomeEditar.Enabled = false;
            cbxSexo.Enabled = false;
            mskCPF.Enabled = false;
            txtRG.Enabled = false;
            mskDataNasc.Enabled = false;
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
            rbtAtivo.Enabled = false;
            rbtInativo.Enabled = false;
            btnAtualizar.Enabled = false;
            btnLimpar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string validar = mskCPF.Text;
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
            else
            {
                mskCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

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
            if (txtRG.Text == "")
            {
                MessageBox.Show("Informe o RG", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRG.Focus();
                return;
            }
            if (RG.ValidarRG(txtRG.Text))
            {

            }
            else
            {
                MessageBox.Show("RG Inválido", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRG.Clear();
                txtRG.Focus();
                return;
            }
            if (mskDataNasc.Text == "")
            {
                MessageBox.Show("Informe a data de nascimento", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskDataNasc.Focus();
                return;
            }
            if (Data.ValidaData(mskDataNasc.Text))
            {

            }
            else
            {
                MessageBox.Show("Data inválida", "Opa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskDataNasc.Clear();
                mskDataNasc.Focus();
                return;

            }
            if (Idade.CalculoIdade(mskDataNasc.Text))
            {

            }
            else
            {
                rbtInativo.Checked = true;
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
            if (telefone.ValidaTelefone(txtTelefone.Text))
            {

            }
            else
            {
                MessageBox.Show("O número de telefone é inválido", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefone.Clear();
                txtTelefone.Focus();
                return;
            }
            if (rbtAtivo.Checked == false && rbtInativo.Checked == false)
            {
                MessageBox.Show("Selecione a Situação", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                if (rbtAtivo.Checked == true)
                {
                    Situacao = "Ativo";
                }
                else
                {
                    Situacao = "Inativo";
                }
                mskDataNasc.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                mskCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                try
                {
                    string updateQuery = "UPDATE tbl_Aluno SET  nomeAluno = '" + txtNomeEditar.Text + "', CPF='" + mskCPF.Text + "', RG= '" + txtRG.Text + "', dataNasc= '" + mskDataNasc.Text + "', Genero= '" + cbxSexo.Text + "'," + "  Logradouro= '" + txtLogradouro.Text + "', Complemento= '" + txtComplemento.Text + "',  numEndereco= '" + txtNumero.Text + "', Bairro= '" + txtBairro.Text + "',  Cidade= '" + txtCidade.Text + "',  UF= '" + cbxUF.Text + "'," + "CEP = '" + txtCEP.Text + "', Telefone = '" + txtTelefone.Text + "', Telefone2 = '" + txtTelefone2.Text + "',  DDD1= '" + txtDDD1.Text + "',  DDD2= '" + txtDDD2.Text + "',  Email= '" + txtEmail.Text + "' , alSituacao= '" + Situacao + "' WHERE ID_Aluno=" + int.Parse(txtID.Text);
                    executeMyQuery(updateQuery);
                    populateDGV();
                    Form Pesquisa = new Pesquisa_Funcionario();
                    Pesquisa.ShowDialog();
                    Close();
                }
                catch
                {
                    MessageBox.Show("Falha ao atualizar", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeEditar.Clear();
                    cbxSexo.ResetText();
                    mskCPF.Clear();
                    txtRG.Clear();
                    mskDataNasc.Clear();
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
                    rbtAtivo.Checked = false;
                    rbtInativo.Checked = false;

                }

            }
        }

        private void rbtAtivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtAtivo.Checked == true)///////////TAVA ENVIANDO NADA PRO BANCO
            {
                Situacao = "Ativo";

            }
        }

        private void rbtInativo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtInativo.Checked == true)
            {
                Situacao = "Inativo";
            }
        }

        private void dgPesquisaAluno_MouseClick(object sender, MouseEventArgs e)
        {
            txtNomeEditar.Text = dgPesquisaAluno.CurrentRow.Cells[0].Value.ToString();
            mskCPF.Text = dgPesquisaAluno.CurrentRow.Cells[1].Value.ToString();
            txtRG.Text = dgPesquisaAluno.CurrentRow.Cells[2].Value.ToString();
            mskDataNasc.Text = dgPesquisaAluno.CurrentRow.Cells[3].Value.ToString();
            cbxSexo.Text = dgPesquisaAluno.CurrentRow.Cells[4].Value.ToString();
            txtLogradouro.Text = dgPesquisaAluno.CurrentRow.Cells[5].Value.ToString();
            txtComplemento.Text = dgPesquisaAluno.CurrentRow.Cells[6].Value.ToString();
            txtNumero.Text = dgPesquisaAluno.CurrentRow.Cells[7].Value.ToString();
            txtBairro.Text = dgPesquisaAluno.CurrentRow.Cells[8].Value.ToString();
            txtCidade.Text = dgPesquisaAluno.CurrentRow.Cells[9].Value.ToString();
            cbxUF.Text = dgPesquisaAluno.CurrentRow.Cells[10].Value.ToString();
            txtCEP.Text = dgPesquisaAluno.CurrentRow.Cells[11].Value.ToString();
            txtTelefone.Text = dgPesquisaAluno.CurrentRow.Cells[12].Value.ToString();
            txtTelefone2.Text = dgPesquisaAluno.CurrentRow.Cells[13].Value.ToString();
            txtDDD1.Text = dgPesquisaAluno.CurrentRow.Cells[14].Value.ToString();
            txtDDD2.Text = dgPesquisaAluno.CurrentRow.Cells[15].Value.ToString();
            txtEmail.Text = dgPesquisaAluno.CurrentRow.Cells[16].Value.ToString();
            if (dgPesquisaAluno.CurrentRow.Cells[17].Value.ToString() == "Ativo")
            {
                rbtAtivo.Checked = true;
            }
            else
            {
                rbtInativo.Checked = true;
            }
            txtID.Text = dgPesquisaAluno.CurrentRow.Cells[18].Value.ToString();
        }

        private void mskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
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

        private void txtDDD2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtTelefone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

        private void txtNomeEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

       
    }
}
