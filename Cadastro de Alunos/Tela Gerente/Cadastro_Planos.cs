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
        string data = DateTime.Now.ToShortDateString();
     
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");/*copiando do appconfig*//*DESKTOP-1VUTL33*/
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
            Close();
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
            string scom = "select ID_Modalidade, nomeModal from tbl_Modalidade";
            SqlDataAdapter da = new SqlDataAdapter(scom, conn);
            DataTable dtResultado = new DataTable();
            dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
            lbModalidades.DataSource = null;
            da.Fill(dtResultado);
            lbModalidades.DataSource = dtResultado;
            lbModalidades.ValueMember = "nomeModal";                                  
            lbModalidades.SelectedItem = "";
            lbModalidades.Refresh();
            conn.Close();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {


            lbDescricao.Items.Clear();
            txtValorTotal.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome_Plano.Text == "")
            {
                MessageBox.Show("Favor insira o nome do plano");
                txtNome_Plano.Focus();
            }
            else if(txtObservacao.Text == "")
            {
                MessageBox.Show("Favor insira a descrição do plano");
                txtObservacao.Focus();
            }
            else if (txtValorTotal.Text == "")
            {
                MessageBox.Show("Favor insira o valor do plano");
                txtValorTotal.Focus();
            }
            else
            {
                try
                {
                   

                    conn.Open();//abrindo base de dados
                    comando.CommandText = "insert into tbl_Plano(nomePlano, PlanoValor, dataCadastro, Observacao, plSituacao) values('" + txtNome_Plano.Text + "'," + float.Parse(txtValorTotal.Text) + ",'" + data + "','" + txtObservacao.Text + "','Ativo')";

                    comando.ExecuteNonQuery();

                    string scom = "select @@IDENTITY";
                    SqlDataAdapter da = new SqlDataAdapter(scom, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    int idPlano = Convert.ToInt32(ds.Tables[0].DefaultView[0].Row[0]);

                    foreach (object item in lbDescricao.Items)
                    {
                        comando.CommandText = "insert into tbl_PlanoModal(ID_Plano,ID_Modalidade)values(" + idPlano + "," +  "(SELECT ID_Modalidade FROM tbl_Modalidade WHERE nomeModal ='"+item+"'))";
                        comando.ExecuteNonQuery();
                    }

                    conn.Close();

                    lbDescricao.Items.Clear();
                    txtValorTotal.Clear();
                    txtNome_Plano.Clear();
                    txtObservacao.Clear();

                    MessageBox.Show("Plano Cadastrado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void lbModalidades_Click(object sender, EventArgs e)
        {
           
        }

        private void lbModalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

           /* SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");

            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT * From tbl_Plano WHERE nomePlano = '" + lbPlanos.Text + "'";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtValor.Text = (dr["PlanoValor"].ToString());
                txtPlanoEscolhido.Text = (dr["nomePlano"].ToString());
                txtDescricao.Text = (dr["Observacao"].ToString());
                txtID_Plano.Text = (dr["ID_Plano"].ToString());
                txtSituacao.Text = (dr["plSituacao"].ToString());
            }
            conn.Close();*/
        }

        private void lbDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");

            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT modalValor From tbl_Modalidade WHERE nomeModal = '" + lbDescricao.Text + "'";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtValorTotal.Text = (dr["modalValor"].ToString());
            }
            conn.Close();*/
        }

        private void lbDescricao_ControlAdded(object sender, ControlEventArgs e)
        {
          /*  SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");

            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT modalValor From tbl_Modalidade WHERE nomeModal = '" + lbDescricao.Text + "'";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtValorTotal.Text = (dr["modalValor"].ToString());
            }
            conn.Close();*/
        }

        private void lbDescricao_Layout(object sender, LayoutEventArgs e)
        {
           /* SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=BeMighty;User ID=sa;Password=etesp");

            conn.Open();
            SqlCommand comando = conn.CreateCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "SELECT modalValor From tbl_Modalidade WHERE nomeModal = '" + lbDescricao.Text + "'";
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtValorTotal.Text = (dr["modalValor"].ToString());
            }
            conn.Close();*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lbDescricao.Items.Add(lbModalidades.SelectedValue);
          //  lbIDEscolhido.Items.Add(lbID.SelectedValue);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            lbDescricao.Items.Remove(lbDescricao.SelectedItem);
            
        }

        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar) ||  char.IsSymbol(e.KeyChar)) e.Handled = true;
        }
    }
}
