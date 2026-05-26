using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TELATESTE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)|| char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if  ( char.IsSymbol(e.KeyChar)  || char.IsPunctuation(e.KeyChar)|| char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void txtTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Por Favor Insira um Nome !", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
            }
            
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Por Favor Escreva a Descrição !", "OPS!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescricao.Focus();
            }
        }
    }
}
