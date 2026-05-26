using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;



namespace Cadastro_de_Alunos
{
	public partial class Cadastro_Planos : Form
	{
		SqlConnection conn = new SqlConnection("Data Source=LAB02T-19;Initial Catalog=BeMighty;Integrated Security=True");/*copiando do appconfig*//*DESKTOP-1VUTL33*/
		SqlCommand comando = new SqlCommand();/*instanciando*/
		void carregaLista()
		{
			conn.Open();
			comando.CommandText = "select * from tbl_Plano";
			conn.Close();
		}
		public Cadastro_Planos()
		{
			InitializeComponent();
		}

		private void btnVoltar_Click(object sender, EventArgs e)
		{
			Form Inicial = new frmTelaInicial();
			Inicial.Show();
			this.Hide();
		}

		private void Cadastro_Planos_Load(object sender, EventArgs e)
		{
			//txtValor.Text = 0.ToString("C");
			preencherCBDescricao();
			comando.Connection = conn;
			carregaLista();

		}

		private void preencherCBDescricao()
		{

			try
			{
				conn.Open();
			}
			catch (SqlException sqle)
			{
				MessageBox.Show("Falha ao efetuar a conexão. Erro: " + sqle);
			}
			String scom = "select * from tbl_Modalidade";
			SqlDataAdapter da = new SqlDataAdapter(scom, conn);
			DataTable dtResultado = new DataTable();
			dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
			lbModalidades.DataSource = null;
			da.Fill(dtResultado);
			lbModalidades.DataSource = dtResultado;
			lbModalidades.ValueMember = "nomeModal";
			//comboBox1.DisplayMember = "descricao";
			lbModalidades.SelectedItem = "";
			lbModalidades.Refresh();
            conn.Close();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			lbDescricao.Items.Add(lbModalidades.SelectedValue);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			lbDescricao.Items.Remove(lbDescricao.SelectedItem);
		}

		private void btnLimpar_Click(object sender, EventArgs e)
		{
			txtNome.Clear();
			txtPMI.Clear();
			lbDescricao.Items.Clear();
			txtValor.Clear();
		}

		private void btnCadastrar_Click(object sender, EventArgs e)
		{
			try
			 {
				conn.Open();/*abrindo base de dados*/
                string str = "";
                if (lbDescricao.Items.Count > 0)
                {
                    for (int i = 0; i < lbDescricao.Items.Count; i++)
                    {
                        {
                            if (str == "")
                            {
                                str = lbDescricao.Items[i].ToString();
                            }
                            else
                            {
                                str += "," + lbDescricao.Items[i].ToString();
                            }
                        }
                    }
                }
                comando.CommandText = "insert into tbl_Plano(nomePlano,Observacao,PlanoValor,PeriodoInadimplencia) values " +
					"('" + txtNome.Text + "','" + str + "','" + txtValor.Text + "','" +txtPMI.Text + "')"; /*datanasc.ToString("yyyy-MM-dd")*/
				comando.ExecuteNonQuery();/*executando bd*/
				conn.Close();
				carregaLista();

				txtNome.Clear();
				txtPMI.Clear();
				lbDescricao.Items.Clear();
				txtValor.Clear();

				MessageBox.Show("Modalidade Cadastrada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
