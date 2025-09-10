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
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }
		string m;
		

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }

		private void btnEntrar_Click(object sender, EventArgs e)
		{
            string validar = mskCpf.Text;
			
			if(mskCpf.Text=="")
            {
                MessageBox.Show("Inserir CPF", "OPS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskCpf.Focus();
            }
           
			 else if (txtSenha.Text == "")
			{
				MessageBox.Show("Inserir Senha", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				txtSenha.Focus();
			}
			else
			{ 
			Form Inicial = new frmTelaInicial();
			Inicial.ShowDialog();
		    }
                     
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            mskCpf.Clear();
            txtSenha.Clear();
        }

		private void btnSair_Click(object sender, EventArgs e)
		{
			Close();
		}

        private void TelaLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
