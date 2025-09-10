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
	public partial class Tela_Atendente : Form
	{
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");
        SqlCommand comando = new SqlCommand();/*instanciando*/
        void carregaLista()
        {
            conn.Open();
            comando.CommandText = "select Senha from tbl_Funcionario";            
            conn.Close();
        }
        public Tela_Atendente(string CPF_Usuario)
		{
			InitializeComponent();
            txtCPF.Text = CPF_Usuario;
		}

		private void cadastroDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form inicial = new CadastroAlunosAtendente();
			inicial.ShowDialog();
			
		}

		

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Tela_Pagamento_Atendente();
            Inicial.ShowDialog();
            
        }

        private void Tela_Atendente_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, -1);
            this.Size = new Size(w, h);
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");

            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT nomeFuncionario From tbl_Funcionario WHERE CPF = '" + txtCPF.Text + "'";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                lblUsuario.Text = (dr["nomeFuncionario"].ToString());
            }
            conn.Close();
        }

        private void pesquisasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new PesquisaAlunoAtendente();
            Inicial.ShowDialog();
        }

        private void logoffToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Login = new TelaLogin();
            Login.Show();
            this.Hide();
        }
    }
}
