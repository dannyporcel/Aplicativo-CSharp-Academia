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
        SqlConnection conn = new SqlConnection("Data Source=LAB02T-19;Initial Catalog=BeMighty;Integrated Security=True");/*copiando do appconfig*//*DESKTOP-1VUTL33*/
        SqlCommand comando = new SqlCommand();/*instanciando*/
        void carregaLista()
        {
            conn.Open();
            comando.CommandText = "select * from tbl_Modalidade";
            conn.Close();
        }
        public Cadastro_Modalidades()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
			if (txtNome.Text == "")
			{
				MessageBox.Show("Favor insira o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtNome.Focus();
			}
			else if (txtTipo.Text == "")
			{
				MessageBox.Show("Favor insira o Tipo", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtTipo.Focus();
			}
			else if (txtValor.Text == "")
			{
				MessageBox.Show("Favor insira o Valor", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtValor.Focus();
			}
			else if (txtDescricao.Text == "")
			{
				MessageBox.Show("Favor insira a Descrição", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtDescricao.Focus();
			}
			else
			{
				try
				{
					conn.Open();/*abrindo base de dados*/

					comando.CommandText = "insert into tbl_Modalidade(nomeModal,descricaoModal,modalValor,modalTipo) values " +
						"('" + txtNome.Text + "','" + txtDescricao.Text + "','" + txtValor.Text + "','" + txtTipo.Text + "')"; /*datanasc.ToString("yyyy-MM-dd")*/
					comando.ExecuteNonQuery();/*executando bd*/
					conn.Close();
					carregaLista();

					txtNome.Clear();
					txtDescricao.Clear();
					txtValor.Clear();
					txtTipo.Clear();

					MessageBox.Show("Modalidade Cadastrada !", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
			txtNome.Clear();
			txtTipo.Clear();
			txtValor.Clear();
			txtDescricao.Clear();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        

        private void btnVoltar_Click(object sender, EventArgs e)
        {
			Form Inicial = new frmTelaInicial();
			Inicial.Show();
			this.Hide();
        }

        private void Cadastro_Modalidades_Load(object sender, EventArgs e)
        {
            comando.Connection = conn;/*abertura de BD*//*usar try catch p/solucao de erro conect bd*/
            carregaLista();
        }

		private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
		}
	}
}
