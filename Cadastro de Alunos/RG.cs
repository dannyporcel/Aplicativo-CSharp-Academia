using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Alunos
{
	class RG
	{
		public static bool ValidarRG(string RG)
		{
			try
			{
				
				int n1 = int.Parse(RG.Substring(0, 1));
				int n2 = int.Parse(RG.Substring(1, 1));
				int n3 = int.Parse(RG.Substring(2, 1));
				int n4 = int.Parse(RG.Substring(3, 1));
				int n5 = int.Parse(RG.Substring(4, 1));
				int n6 = int.Parse(RG.Substring(5, 1));
				int n7 = int.Parse(RG.Substring(6, 1));
				int n8 = int.Parse(RG.Substring(7, 1));

				string DV = RG.Substring(8, 1);

				int Soma = n1 * 2 + n2 * 3 + n3 * 4 + n4 * 5 + n5 * 6 + n6 * 7 + n7 * 8 + n8 * 9;
				string digitoVerificador = Convert.ToString(Soma % 11);

				if (digitoVerificador == "1")
				{
					digitoVerificador = "x";
				}
				else if (digitoVerificador == "0")
				{
					digitoVerificador = "0";
				}
				else
				{
					digitoVerificador = (11 - int.Parse(digitoVerificador)).ToString();
				}

				if (digitoVerificador == DV)
				{
					return true;
				}
				else
				{
					return false;
				}
			}

			catch
			{
				return false;
			}
		}
	
	}
}
