using System;

namespace amoba_game
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Amöba játék");
			int width = 0; 
			int height = 0;
			while (width == 0 || height == 0)
			{
				Console.WriteLine("Add meg hogy mekkora legyen a pálya: (pl: 3x3)");
				string pályaméret = Console.ReadLine();
				if (pályaméret.Contains("x"))
				{
					string[] pályaméretdarab = pályaméret.Split('x');
					width = int.Parse(pályaméretdarab[0]);
					height = int.Parse(pályaméretdarab[1]);


					for (int y = 0; y < height; y++)
					{
						string sor = "|";

						for (int x = 0; x < width; x++)
						{
							sor += " |";
						}
						Console.WriteLine(sor);

						string sorelvalaszto = "-";
						for (int x = 0; x < width; x++)
						{
							sorelvalaszto += "--";
						}
						Console.WriteLine(sorelvalaszto);



					}
				}
				else
				{
					Console.WriteLine("helytelen adat");
				}
			}
		}
	}
}
