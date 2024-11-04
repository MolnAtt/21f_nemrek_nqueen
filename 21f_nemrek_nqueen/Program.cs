using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _21f_nemrek_nqueen
{
	internal class Program
	{

		static int[] Nkiralyno(int N)
		{
			int[] result = new int[N];
			for (int ix = 0; ix < N; ix++)
			{
				result[ix] = -1;
			}
			int i = 0;

			while (-1 < i && i < N) // vízszintes mászkálás
			{
				(bool van, int j) = Oszlopban_keres(i, result);
				if (van)
				{
					result[i] = j;
					i++;
				}
				else
				{
					result[i] = -1;
					i--;
				}
				Console.WriteLine(string.Join(" ", result));

			}

			return result;
		}

		private static (bool van, int j) Oszlopban_keres(int i, int[] result) // ez a függőleges mászkálás
		{


			int j = result[i] + 1; // -1-es inicializálásból itt lesz 0-ás index!
			while (j < result.Length && Rossz(i, j, result)) // a rossz-ban lesz szó egyedül a sakkról!
			{
				j++;
			}
			return (j < result.Length, j);
		}

		private static bool Rossz(int i, int j, int[] result)
		{

			for (int i2 = 0; i2 < i; i2++)
			{
				if (j == result[i2])
					return true;
				if (Math.Abs(i-i2) == Math.Abs(j - result[i2]))
					return true;
			}
			return false;
		}

		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			int N = int.Parse(input);
			Console.WriteLine(string.Join(" ", Nkiralyno(N)));
			Console.ReadKey();
		}
	}
}
