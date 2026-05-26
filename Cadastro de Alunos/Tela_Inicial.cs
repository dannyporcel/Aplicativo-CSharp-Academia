using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cadastro_de_Alunos
{
	public partial class frmTelaInicial : Form
	{
		public frmTelaInicial()
		{
			InitializeComponent();
		}

		private void cadastroDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form Inicial = new frmTelaCadastroAluno();
			Inicial.Show();
			this.Hide();
		}

		private void cadastroDeFuncináriosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form Inicial = new Cadastro_de_Funcionários();
			Inicial.Show();
			this.Hide();
		}

		private void cadastroDeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form Inicial = new Cadastro_de_Professores();
			Inicial.Show();
			this.Hide();
		}

		private void cadastroDeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Form Inicial = new Cadastro_Planos();
			Inicial.Show();
			this.Hide();
		}

		private void cadastroDeModalidadesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form Inicial = new Cadastro_Modalidades();
			Inicial.Show();
			this.Hide();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

        private void pesquisaDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Pesquisa_Alunos();
            Inicial.Show();
			this.Hide();
        }

        private void pesquisaDeFuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Pesquisa_Funcionario();
            Inicial.Show();
			this.Hide();
        }

        private void pesquisaDeProfessoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Pesquisa_Professor();
            Inicial.Show();
			this.Hide();
        }

        private void pesquisaDePlanosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Pesquisa_Plano();
            Inicial.Show();
			this.Hide();
        }

        private void pesquisaDeModalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Inicial = new Pesquisa_Modalidade();
            Inicial.Show();
			this.Hide();
        }

        private void frmTelaInicial_Load(object sender, EventArgs e)
        {

        }
    }
}
