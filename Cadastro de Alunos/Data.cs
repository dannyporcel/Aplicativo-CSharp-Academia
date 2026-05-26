using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Alunos
{
	class Data
	{
		public static bool ValidaData(String Idade)
		{

			try
			{
				
				int DiaAtual = DateTime.Now.Day;
				int MesAtual = DateTime.Now.Month;
				int AnoAtual = DateTime.Now.Year;

				int data = int.Parse(Idade.Substring(0, 2));
				int mes = int.Parse(Idade.Substring(2, 2));
				int ano = int.Parse(Idade.Substring(4));

				if (ano >= AnoAtual)
				{
					return false;
				}
				else if (ano == 0)
				{
					return false;
				}
				else if (mes < 1 || mes > 12)
				{
					return false;
				}
				else if (data < 1 || data > 32)
				{
					return false;
				}
				
				else
				{
					return true;
				}
				
			}
			catch
			{
				return false;
			}

		}
	}
}
