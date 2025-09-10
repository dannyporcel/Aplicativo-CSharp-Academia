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
		
		private void btnSair_Click(object sender, EventArgs e)
		{
			Close();
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

		private void cadastroDeToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Form Inicial = new Cadastro_Planos();
			Inicial.ShowDialog();
		}

		private void cadastroDeModalidadesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form Inicial = new Planos_Modalidades();
			Inicial.ShowDialog();
		}
	}
}
