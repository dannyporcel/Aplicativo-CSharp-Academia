using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_Alunos
{
	class telefone
	{
		public static bool ValidaTelefone(String telefone)
		{
			try
			{
				int n1 = int.Parse(telefone.Substring(0, 1));
				int n2 = int.Parse(telefone.Substring(1, 1));
				int n3 = int.Parse(telefone.Substring(2, 1));
				int n4 = int.Parse(telefone.Substring(3, 1));
				int n5 = int.Parse(telefone.Substring(4, 1));
				int n6 = int.Parse(telefone.Substring(5, 1));
				int n7 = int.Parse(telefone.Substring(6, 1));
				int n8 = int.Parse(telefone.Substring(7, 1));
				int n9 = int.Parse(telefone.Substring(8, 1));
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
