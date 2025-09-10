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
    public partial class Cadastro_de_Professores : Form
    {
        public Cadastro_de_Professores()
        {
            InitializeComponent();
        }
			
		private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
        private void txtRG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
        private void txtLogradouro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
        
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Informe o Nome", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Focus();
            }
            else if (txtCPF.Text == "")
            {
                MessageBox.Show("Informe o CPF", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCPF.Focus();
            }
            else if (cbxSexo.Text == "")
            {
                MessageBox.Show("Informe o Sexo", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxSexo.Focus();
            }
            else if (txtLogradouro.Text == "")
            {
                MessageBox.Show("Informe o Logradouro", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtLogradouro.Focus();
            }
            else if (txtNumero.Text == "")
            {
                MessageBox.Show("Informe o Número", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNumero.Focus();
            }
            else if (cbxUF.Text == "")
            {
                MessageBox.Show("Informe a UF", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxUF.Focus();
            }
            else if (txtCidade.Text == "")
            {
                MessageBox.Show("Informe a Cidade", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCidade.Focus();
            }
            else if (txtDDD1.Text == "")
            {
                MessageBox.Show("Informe o DDD", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDDD1.Focus();
            }
            else if (txtTelefone.Text == "")
            {
                MessageBox.Show("Informe o Telefone", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefone.Focus();
            }
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtCPF.Clear();
            cbxSexo.ResetText();
            txtRG.Clear();
            txtCEP.Clear();
            txtLogradouro.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtComplemento.Clear();
            cbxUF.ResetText();
            txtTelefone.Clear();
            txtDDD1.Clear();
            txtTelefone2.Clear();
            txtDDD2.Clear();
            txtEmail.Clear();
            
            txtMatricula.Clear();
            txtCidade.Clear();
			
			txtNome.Focus();
			
        }

		private void btnVoltar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnLimpar_Click_1(object sender, EventArgs e)
		{
			txtNome.Clear();
			txtCPF.Clear();
			cbxSexo.ResetText();
			txtRG.Clear();
			txtCEP.Clear();
			txtLogradouro.Clear();
			txtNumero.Clear();
			txtBairro.Clear();
			txtComplemento.Clear();
			cbxUF.ResetText();
			txtTelefone.Clear();
			txtDDD1.Clear();
			txtTelefone2.Clear();
			txtDDD2.Clear();
			txtEmail.Clear();
			
			txtMatricula.Clear();
			txtCidade.Clear();
			clbModalidades.ClearSelected();
			txtNome.Focus();
		}
	}
	}

	
		

