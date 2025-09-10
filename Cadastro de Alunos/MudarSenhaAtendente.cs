using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Alunos
{
    public partial class MudarSenhaAtendente : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");
        SqlCommand comando = new SqlCommand();/*instanciando*/

       

        public MudarSenhaAtendente(string validacao)
        {
            InitializeComponent();
            mskCPF.Text = validacao;

        }



        private void btnAtualizarSenha_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                MessageBox.Show("Insira a Senha", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSenha.Focus();
            }
            else if (txtConfirmarSenha.Text == "")
            {
                MessageBox.Show("Confirme a Senha", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtConfirmarSenha.Focus();
            }
            else if (txtConfirmarSenha.Text != txtSenha.Text)
            {
                MessageBox.Show("Senha Incorreta", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtConfirmarSenha.Clear();
                txtConfirmarSenha.Focus();
            }
            else if(txtSenha.Text == "1234")
            {
                MessageBox.Show("A nova senha não pode ser igual a sua antiga senha ", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSenha.Clear();
                txtConfirmarSenha.Clear();
                txtSenha.Focus();
            }
            else
            {                                                   
                string updateQuery = "Update tbl_Funcionario set Senha = '" + txtConfirmarSenha.Text + "', CPF='"+mskCPF.Text+"' where Senha = '1234' AND CPF = '"+mskCPF.Text+"' ";
                executeMyQuery(updateQuery);
                Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMostrarSenha.Checked == true)
            {
                txtSenha.UseSystemPasswordChar = false;
                txtConfirmarSenha.UseSystemPasswordChar = false;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = true;
                txtConfirmarSenha.UseSystemPasswordChar = true;
            }
        }
        public void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public void executeMyQuery(string query)
        {
            try
            {
                openConnection();
                comando = new SqlCommand(query, conn);
                if (comando.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Senha atualizada com sucesso!");
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
    }
}
