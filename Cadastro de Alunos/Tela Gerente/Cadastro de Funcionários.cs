using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Cadastro_de_Alunos
{
    public partial class Cadastro_de_Funcionários : Form
    {
        string Perfil;
        string senha = "1234";
        bool isProfessor = false;

        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp");

        public Cadastro_de_Funcionários()
        {
            InitializeComponent();
            ConfigurarVisibilidadeCamposProfessor();
        }

        private void ConfigurarVisibilidadeCamposProfessor()
        {
            lblCREF.Visible = false;
            txtCREF.Visible = false;
            gbPermissoesProfessor.Visible = false;
        }

        private DateTime? ValidarData(string dataTexto)
        {
            if (string.IsNullOrEmpty(dataTexto))
                return null;

            dataTexto = dataTexto.Replace("/", "").Trim();
            if (dataTexto.Length != 8)
                return null;

            try
            {
                string dia = dataTexto.Substring(0, 2);
                string mes = dataTexto.Substring(2, 2);
                string ano = dataTexto.Substring(4, 4);

                string dataFormatada = $"{dia}/{mes}/{ano}";
                return DateTime.ParseExact(dataFormatada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Validações básicas
            if (!ValidarCamposObrigatorios())
                return;

            try
            {
                byte[] imagebt = ProcessarFoto();
                string cpfSemFormatacao = mskCpf.Text;

                conn.Open();

                // PASSO 1: Inserir na tbl_funcionarios
                int idFuncionarioInserido = InserirFuncionario(cpfSemFormatacao, imagebt);

                // PASSO 2: Se for professor, inserir na tbl_professor
                if (isProfessor)
                {
                    InserirProfessor(idFuncionarioInserido, imagebt);
                }

                // PASSO 3: Inserir permissões
                InserirPermissao(idFuncionarioInserido);

                MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                txtNome.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // ADICIONADO: Método para validar todos os campos
        private bool ValidarCamposObrigatorios()
        {
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mskDataNascimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                MessageBox.Show("Informe o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cbxSexo.Text))
            {
                MessageBox.Show("Informe o Sexo", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxSexo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(mskCpf.Text))
            {
                MessageBox.Show("Informe o CPF", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskCpf.Focus();
                return false;
            }

            if (!CPF.ValidaCPF(mskCpf.Text))
            {
                MessageBox.Show("CPF Inválido", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskCpf.Clear();
                mskCpf.Focus();
                return false;
            }

            DateTime? dataNascimento = ValidarData(mskDataNascimento.Text);
            if (dataNascimento == null)
            {
                MessageBox.Show("Data de Nascimento inválida", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskDataNascimento.Clear();
                mskDataNascimento.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCEP.Text) ||
                string.IsNullOrEmpty(txtLogradouro.Text) ||
                string.IsNullOrEmpty(txtNumero.Text) ||
                string.IsNullOrEmpty(cbxUF.Text) ||
                string.IsNullOrEmpty(txtCidade.Text) ||
                string.IsNullOrEmpty(txtDDD1.Text) ||
                string.IsNullOrEmpty(txtTelefone.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!telefone.ValidaTelefone(txtTelefone.Text))
            {
                MessageBox.Show("O número de telefone é inválido", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefone.Clear();
                txtTelefone.Focus();
                return false;
            }

            if (isProfessor && string.IsNullOrEmpty(txtCREF.Text))
            {
                MessageBox.Show("Informe o Registro CREF para professor", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCREF.Focus();
                return false;
            }

            if (isProfessor && !ValidarCREF(txtCREF.Text))
            {
                MessageBox.Show("CREF inválido", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCREF.Focus();
                return false;
            }

            if (!rbAtendente.Checked && !rbGerente.Checked && !isProfessor)
            {
                MessageBox.Show("Selecione o Perfil de Acesso", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        // CORRIGIDO: Método para inserir funcionário
        private int InserirFuncionario(string cpfSemFormatacao, byte[] imagebt)
        {
            int proximoId = ObterProximoId("tbl_funcionarios", "id_funcionarios");
            DateTime dataAtual = DateTime.Now;
            DateTime dataNascimento = ValidarData(mskDataNascimento.Text).Value;

            string insertFuncionario = @"INSERT INTO tbl_funcionarios (
                id_funcionarios, nome, genero, cpf, data_nasc, rua, numero_endereco, 
                bairro, cidade, uf, cep, complemento, dd1, telefone, 
                email, cargo, data_cadastro, senha, foto, situacao, data_registro, 
                data_inicio, data_alteracao, id_professor
            ) VALUES (
                @id_funcionarios, @nome, @genero, @cpf, @data_nasc, @rua, @numero_endereco,
                @bairro, @cidade, @uf, @cep, @complemento, @dd1, @telefone,
                @email, @cargo, @data_cadastro, @senha, @foto, @situacao, @data_registro, 
                @data_inicio, @data_alteracao, @id_professor
            )";

            using (SqlCommand comando = new SqlCommand(insertFuncionario, conn))
            {
                // Parâmetros com tipos explícitos
                comando.Parameters.Add("@id_funcionarios", SqlDbType.Int).Value = proximoId;
                comando.Parameters.Add("@nome", SqlDbType.VarChar, 100).Value = txtNome.Text.Trim();
                comando.Parameters.Add("@genero", SqlDbType.VarChar, 3).Value = cbxSexo.Text;

                decimal cpfDecimal;
                if (decimal.TryParse(cpfSemFormatacao, out cpfDecimal))
                    comando.Parameters.Add("@cpf", SqlDbType.Decimal).Value = cpfDecimal;
                else
                    throw new Exception("CPF inválido");

                comando.Parameters.Add("@data_nasc", SqlDbType.Date).Value = dataNascimento;
                comando.Parameters.Add("@rua", SqlDbType.VarChar, 100).Value = txtLogradouro.Text.Trim();

                decimal numeroDecimal;
                if (decimal.TryParse(txtNumero.Text, out numeroDecimal))
                    comando.Parameters.Add("@numero_endereco", SqlDbType.Decimal).Value = numeroDecimal;
                else
                    throw new Exception("Número inválido");

                comando.Parameters.Add("@bairro", SqlDbType.VarChar, 50).Value = txtBairro.Text.Trim();
                comando.Parameters.Add("@cidade", SqlDbType.VarChar, 50).Value = txtCidade.Text.Trim();
                comando.Parameters.Add("@uf", SqlDbType.VarChar, 3).Value = cbxUF.Text;

                decimal cepDecimal;
                if (decimal.TryParse(txtCEP.Text, out cepDecimal))
                    comando.Parameters.Add("@cep", SqlDbType.Decimal).Value = cepDecimal;
                else
                    throw new Exception("CEP inválido");

                comando.Parameters.Add("@complemento", SqlDbType.VarChar, 100).Value = txtComplemento.Text.Trim() ?? "";

                decimal dddDecimal;
                if (decimal.TryParse(txtDDD1.Text, out dddDecimal))
                    comando.Parameters.Add("@dd1", SqlDbType.Decimal).Value = dddDecimal;
                else
                    throw new Exception("DDD inválido");

                decimal telefoneDecimal;
                if (decimal.TryParse(txtTelefone.Text, out telefoneDecimal))
                    comando.Parameters.Add("@telefone", SqlDbType.Decimal).Value = telefoneDecimal;
                else
                    throw new Exception("Telefone inválido");

                comando.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txtEmail.Text.Trim();
                comando.Parameters.Add("@cargo", SqlDbType.VarChar, 100).Value = Perfil;
                comando.Parameters.Add("@data_cadastro", SqlDbType.DateTime).Value = dataAtual;

                decimal senhaDecimal;
                if (decimal.TryParse(senha, out senhaDecimal))
                    comando.Parameters.Add("@senha", SqlDbType.Decimal).Value = senhaDecimal;
                else
                    comando.Parameters.Add("@senha", SqlDbType.Decimal).Value = 1234m;

                // CORREÇÃO DO ERRO: Tratamento correto do varbinary
                if (imagebt != null && imagebt.Length > 0)
                    comando.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = imagebt;
                else
                    comando.Parameters.Add("@foto", SqlDbType.VarBinary).Value = DBNull.Value;

                comando.Parameters.Add("@situacao", SqlDbType.VarChar, 20).Value = "Ativo";
                comando.Parameters.Add("@data_registro", SqlDbType.DateTime).Value = dataAtual;
                comando.Parameters.Add("@data_inicio", SqlDbType.DateTime).Value = dataAtual;
                comando.Parameters.Add("@data_alteracao", SqlDbType.DateTime).Value = dataAtual;
                comando.Parameters.Add("@id_professor", SqlDbType.Int).Value = DBNull.Value;

                comando.ExecuteNonQuery();
                return proximoId;
            }
        }

        // CORRIGIDO: Método para inserir professor
        private void InserirProfessor(int idFuncionario, byte[] imagebt)
        {
            int proximoIdProfessor = ObterProximoId("tbl_professor", "id_professor");
            DateTime dataAtual = DateTime.Now;
            DateTime dataNascimento = ValidarData(mskDataNascimento.Text).Value;

            string insertProfessor = @"INSERT INTO tbl_professor (
                id_professor, foto, nome, nome_social, genero, email, senha, 
                registro_cref, cpf, data_nasc, dd1, telefone, data_cadastro, 
                data_inicio, data_alteracao, rua, numero_endereco, bairro, cep, 
                cidade, uf, complemento, id_funcionarios
            ) VALUES (
                @id_professor, @foto, @nome, @nome_social, @genero, @email, @senha,
                @registro_cref, @cpf, @data_nasc, @dd1, @telefone, @data_cadastro,
                @data_inicio, @data_alteracao, @rua, @numero_endereco, @bairro, @cep,
                @cidade, @uf, @complemento, @id_funcionarios
            )";

            using (SqlCommand cmdProfessor = new SqlCommand(insertProfessor, conn))
            {
                cmdProfessor.Parameters.Add("@id_professor", SqlDbType.Int).Value = proximoIdProfessor;

                // CORREÇÃO DO ERRO: Tratamento correto do varbinary
                if (imagebt != null && imagebt.Length > 0)
                    cmdProfessor.Parameters.Add("@foto", SqlDbType.VarBinary, -1).Value = imagebt;
                else
                    cmdProfessor.Parameters.Add("@foto", SqlDbType.VarBinary).Value = DBNull.Value;

                cmdProfessor.Parameters.Add("@nome", SqlDbType.VarChar, 100).Value = txtNome.Text.Trim();
                cmdProfessor.Parameters.Add("@nome_social", SqlDbType.VarChar, 100).Value = DBNull.Value;
                cmdProfessor.Parameters.Add("@genero", SqlDbType.VarChar, 3).Value = cbxSexo.Text;
                cmdProfessor.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txtEmail.Text.Trim();
                cmdProfessor.Parameters.Add("@senha", SqlDbType.VarChar, 255).Value = "prof123";

                decimal crefDecimal;
                if (decimal.TryParse(txtCREF.Text, out crefDecimal))
                    cmdProfessor.Parameters.Add("@registro_cref", SqlDbType.Decimal).Value = crefDecimal;
                else
                    throw new Exception("CREF inválido");

                decimal cpfDecimal;
                if (decimal.TryParse(mskCpf.Text, out cpfDecimal))
                    cmdProfessor.Parameters.Add("@cpf", SqlDbType.Decimal).Value = cpfDecimal;

                cmdProfessor.Parameters.Add("@data_nasc", SqlDbType.Date).Value = dataNascimento;

                decimal dddDecimal;
                if (decimal.TryParse(txtDDD1.Text, out dddDecimal))
                    cmdProfessor.Parameters.Add("@dd1", SqlDbType.Decimal).Value = dddDecimal;

                decimal telefoneDecimal;
                if (decimal.TryParse(txtTelefone.Text, out telefoneDecimal))
                    cmdProfessor.Parameters.Add("@telefone", SqlDbType.Decimal).Value = telefoneDecimal;

                cmdProfessor.Parameters.Add("@data_cadastro", SqlDbType.DateTime).Value = dataAtual;
                cmdProfessor.Parameters.Add("@data_inicio", SqlDbType.DateTime).Value = dataAtual;
                cmdProfessor.Parameters.Add("@data_alteracao", SqlDbType.DateTime).Value = dataAtual;
                cmdProfessor.Parameters.Add("@rua", SqlDbType.VarChar, 100).Value = txtLogradouro.Text.Trim();

                decimal numeroDecimal;
                if (decimal.TryParse(txtNumero.Text, out numeroDecimal))
                    cmdProfessor.Parameters.Add("@numero_endereco", SqlDbType.Decimal).Value = numeroDecimal;

                cmdProfessor.Parameters.Add("@bairro", SqlDbType.VarChar, 50).Value = txtBairro.Text.Trim();

                decimal cepDecimal;
                if (decimal.TryParse(txtCEP.Text, out cepDecimal))
                    cmdProfessor.Parameters.Add("@cep", SqlDbType.Decimal).Value = cepDecimal;

                cmdProfessor.Parameters.Add("@cidade", SqlDbType.VarChar, 50).Value = txtCidade.Text.Trim();
                cmdProfessor.Parameters.Add("@uf", SqlDbType.VarChar, 3).Value = cbxUF.Text;
                cmdProfessor.Parameters.Add("@complemento", SqlDbType.VarChar, 100).Value = txtComplemento.Text.Trim() ?? "";
                cmdProfessor.Parameters.Add("@id_funcionarios", SqlDbType.Int).Value = idFuncionario;

                cmdProfessor.ExecuteNonQuery();

                // Atualizar funcionário com o id_professor
                string updateFuncionario = "UPDATE tbl_funcionarios SET id_professor = @id_professor WHERE id_funcionarios = @id_funcionarios";
                using (SqlCommand cmdUpdate = new SqlCommand(updateFuncionario, conn))
                {
                    cmdUpdate.Parameters.Add("@id_professor", SqlDbType.Int).Value = proximoIdProfessor;
                    cmdUpdate.Parameters.Add("@id_funcionarios", SqlDbType.Int).Value = idFuncionario;
                    cmdUpdate.ExecuteNonQuery();
                }
            }
        }

        private void InserirPermissao(int idFuncionario)
        {
            int proximoIdPermissao = ObterProximoId("tbl_permissao", "id_permissao");
            DateTime dataAtual = DateTime.Now;

            string tipoPermissao = "";
            string descricao = "";

            if (isProfessor)
            {
                tipoPermissao = "Acesso Professor";
                descricao = "Acesso ao sistema web para professores";
            }
            else if (Perfil == "Gerente")
            {
                tipoPermissao = "Acesso Total";
                descricao = "Acesso completo ao sistema";
            }
            else if (Perfil == "Recepcionista")
            {
                tipoPermissao = "Acesso Limitado";
                descricao = "Acesso ao cadastro e consulta";
            }

            string insertPermissao = @"INSERT INTO tbl_permissao (
                id_permissao, nome_funcionario, tipo_permissao, descricao, 
                dataPermissao, id_funcionarios
            ) VALUES (
                @id_permissao, @nome_funcionario, @tipo_permissao, @descricao,
                @dataPermissao, @id_funcionarios
            )";

            using (SqlCommand cmdPermissao = new SqlCommand(insertPermissao, conn))
            {
                cmdPermissao.Parameters.Add("@id_permissao", SqlDbType.Int).Value = proximoIdPermissao;
                cmdPermissao.Parameters.Add("@nome_funcionario", SqlDbType.VarChar, 100).Value = txtNome.Text.Trim();
                cmdPermissao.Parameters.Add("@tipo_permissao", SqlDbType.VarChar, 50).Value = tipoPermissao;
                cmdPermissao.Parameters.Add("@descricao", SqlDbType.VarChar, 50).Value = descricao;
                cmdPermissao.Parameters.Add("@dataPermissao", SqlDbType.DateTime).Value = dataAtual;
                cmdPermissao.Parameters.Add("@id_funcionarios", SqlDbType.Int).Value = idFuncionario;

                cmdPermissao.ExecuteNonQuery();
            }
        }

        private int ObterProximoId(string tabela, string campoId)
        {
            try
            {
                string query = $"SELECT ISNULL(MAX({campoId}), 0) + 1 FROM {tabela}";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao obter próximo ID para {tabela}: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }

        private bool ValidarCREF(string cref)
        {
            if (string.IsNullOrEmpty(cref))
                return false;

            if (cref.Length < 6 || cref.Length > 10)
                return false;

            return decimal.TryParse(cref, out _);
        }

        private byte[] ProcessarFoto()
        {
            byte[] imagebt = null;
            if (!string.IsNullOrEmpty(txtFotoLocal.Text) && File.Exists(txtFotoLocal.Text))
            {
                try
                {
                    using (FileStream fstream = new FileStream(txtFotoLocal.Text, FileMode.Open, FileAccess.Read))
                    {
                        imagebt = new byte[fstream.Length];
                        fstream.Read(imagebt, 0, (int)fstream.Length);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a foto: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return imagebt;
        }

        private void chkProfessor_CheckedChanged_1(object sender, EventArgs e)
        {
            isProfessor = chkProfessor.Checked;
            lblCREF.Visible = isProfessor;
            txtCREF.Visible = isProfessor;
            gbPermissoesProfessor.Visible = isProfessor;

            if (isProfessor)
            {
                Perfil = "Professor";
                rbAtendente.Checked = false;
                rbGerente.Checked = false;
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            cbxSexo.SelectedIndex = -1;
            txtLogradouro.Clear();
            txtNumero.Clear();
            cbxUF.SelectedIndex = -1;
            txtCidade.Clear();
            txtTelefone.Clear();
            txtComplemento.Clear();
            mskCpf.Clear();
            txtCEP.Clear();
            txtBairro.Clear();
            txtEmail.Clear();
            txtDDD1.Clear();
            mskDataNascimento.Clear();
            pbFotoFunc.Image = null;
            rbAtendente.Checked = false;
            rbGerente.Checked = false;
            txtFotoLocal.Clear();
            chkProfessor.Checked = false;
            txtCREF.Clear();
        }

        // Outros métodos existentes (btnVoltar, btnLimpar, etc.)
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            LimparCampos();
            txtNome.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelecFoto_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog img = new OpenFileDialog();
            img.InitialDirectory = "c:\\";
            img.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.bmp|Todos os arquivos|*.*";

            if (img.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string picpath = img.FileName;
                    txtFotoLocal.Text = picpath;
                    pbFotoFunc.Image = Image.FromFile(picpath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}