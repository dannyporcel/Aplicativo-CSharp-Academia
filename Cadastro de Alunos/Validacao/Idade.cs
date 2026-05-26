using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cadastro_de_Alunos
{
	class Idade
    {
        
        public static bool CalculoIdade(string nascimento)
		{
            try
            {
                int CalculaIdade=0;               
                int DiaAtual = DateTime.Now.Day;
                int MesAtual = DateTime.Now.Month;
                int AnoAtual = DateTime.Now.Year;

                int data = int.Parse(nascimento.Substring(0, 2));
                int mes = int.Parse(nascimento.Substring(2, 2));
                int ano = int.Parse(nascimento.Substring(4));


                if (mes < MesAtual)
                {
                    CalculaIdade = AnoAtual - ano;
                }
                else if (mes > MesAtual)
                {
                    CalculaIdade = AnoAtual - ano - 1;      
                }
                else if (mes == MesAtual)
                {
                    if (data <= DiaAtual)
                    {
                        CalculaIdade = AnoAtual - ano;                      
                    }
                    else if (data > DiaAtual)
                    {
                        CalculaIdade = AnoAtual - ano - 1;                     
                    }

                }

                if (CalculaIdade < 14)
                {

                    MessageBox.Show("A idade  mínima para frequentar a academia é de 14 anos", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;

                }
                else if (CalculaIdade == 14)
                {


                    MessageBox.Show("Consentimento dos pais ou responsáveis é necessário", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult confirm = MessageBox.Show("Há Consentimento dos pais ou responsáveis?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm.ToString().ToUpper() == "NO")
                    {
                        return false;
                    }
					else
					{
						return true;
					}


                }
                else if (CalculaIdade > 69)
                {

                    MessageBox.Show("Atestado médico é necessário", "Ops", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult confirma = MessageBox.Show("Há atestado médico?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirma.ToString().ToUpper() == "NO")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    
                }
                return true;
            }
            
            catch
            {
                return false;
            }
		}
	}
}
