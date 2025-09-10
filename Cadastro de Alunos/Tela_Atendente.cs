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
	public partial class Tela_Atendente : Form
	{
		public Tela_Atendente()
		{
			InitializeComponent();
		}

		private void cadastroDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form inicial = new CadastroAlunosAtendente();
			inicial.Show();
			this.Hide();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
