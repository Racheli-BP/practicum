using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

	public static class Validations
	{

		public static bool IsValidTZ(string numOfTeudatZehut)
		{
			int sumAll = 0;
			if (numOfTeudatZehut.Length > 9 || string.IsNullOrEmpty(numOfTeudatZehut))
				return false;
			else if (numOfTeudatZehut.Length < 9)
			{
				while (numOfTeudatZehut.Length < 9)
				{
					numOfTeudatZehut = "0" + numOfTeudatZehut;
				}
			}
			for (int i = 9; i > 0; i--)
			{
				int x = Convert.ToInt32(numOfTeudatZehut.Substring(i - 1, 1));
				if (i % 2 == 0)
				{
					x = x * 2;
					if (x > 9)
						x = (x % 10) + 1;
					sumAll += x;
				}
				else
				{
					x = x * 1;
					sumAll += x;
				}
			}
			sumAll = sumAll % 10;
			if (sumAll % 10 > 0)
				return false;
			else return true;
		}




	}

}
