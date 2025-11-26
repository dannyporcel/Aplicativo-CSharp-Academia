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
        string connectionString = "Data Source=localhost;Initial Catalog=BD_Nexus;User ID=sa;Password=etesp";

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
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

            using (SqlConnection conn = CreateConnection())
            {
                conn.Open();

                // CORREÇÃO: Usar a tabela e campos corretos do BD_Nexus
                SqlCommand comando = new SqlCommand(
                    "SELECT nome FROM tbl_funcionarios WHERE cpf = @cpf",
                    conn);

                // CORREÇÃO: Converter CPF para numérico (pois no BD é numeric)
                comando.Parameters.AddWithValue("@cpf", long.Parse(txtCPF.Text));

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    lblUsuario.Text = dr["nome"].ToString();
                }
                else
                {
                    lblUsuario.Text = "Usuário não encontrado";
                }
            } // A conexão é fechada automaticamente aqui
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