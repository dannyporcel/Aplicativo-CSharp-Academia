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
	public partial class frmTelaInicial : Form
	{
		public frmTelaInicial(string CPF_Usuario)
		{
			InitializeComponent();
            txtCPF.Text = CPF_Usuario;
		}

		private void cadastroDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form Inicial = new frmTelaCadastroAluno();
			Inicial.ShowDialog();
			
		}

		private void cadastroDeFuncináriosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form Inicial = new Cadastro_de_Funcionários();
			Inicial.ShowDialog();
			
		}

		private void cadastroDeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form Inicial = new Cadastro_de_Professores();
			Inicial.ShowDialog();
			
		}

		

		private void cadastroDeModalidadesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form Inicial = new Cadastro_Modalidades();
			Inicial.ShowDialog();
			
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
            Form Inicial = new Tela_Pagamento();
            Inicial.ShowDialog();
            
		}

        private void pesquisaDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Pesquisa_Alunos();
            Inicial.ShowDialog();
			
        }

        private void pesquisaDeFuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Pesquisa_Funcionario();
            Inicial.ShowDialog();
			
        }

        private void pesquisaDeProfessoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Pesquisa_Professor();
            Inicial.ShowDialog();
			
        }

        private void pesquisaDePlanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Pesquisa_Plano();
            Inicial.ShowDialog();
			
        }

        private void pesquisaDeModalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Pesquisa_Modalidade();
            Inicial.ShowDialog();
			
        }

        private void frmTelaInicial_Load(object sender, EventArgs e)
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

        private void cadastroDePlanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Plano = new Cadastro_Planos();
            Plano.ShowDialog();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new TelaLogin();
            Inicial.Show();
            this.Hide();

        }
    }
}
