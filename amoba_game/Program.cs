using System;
using System.Net.WebSockets;
using System.Xml.Linq;

namespace amoba_game
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Add meg az első játékos nevét");
			string Jatekos1 = Console.ReadLine();

			Console.WriteLine("Add meg az második játékos nevét");
			string Jatekos2 = Console.ReadLine();

			Console.WriteLine("Add meg melyik játékos kezdjen");
			Console.WriteLine("0) random ");
			Console.WriteLine($"1 {Jatekos1}");
			Console.WriteLine($"2 {Jatekos2}");
			string KezdoJatekos = Console.ReadLine();
			
			if (! (KezdoJatekos == "0" || KezdoJatekos == "1" || KezdoJatekos == "2" ))
			{
				Console.WriteLine("Helytelen értéket adott meg");
			}

			int Korokszama = KorokszamanakBekerese();


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
		static int KorokszamanakBekerese()
		{

			Console.WriteLine("Add meg a körök számát:  0) = Bármennyi kör ");
			int KorokSzama = int.Parse(Console.ReadLine());

			if ((KorokSzama > 10))
			{
				Console.WriteLine("A körök száma nem lehet 10-nél nagyobb");
				return KorokszamanakBekerese();
			}
			if (KorokSzama < 0)
			{
				Console.WriteLine("Helytelen értéket adott meg");
				return KorokszamanakBekerese();
			}
			return KorokSzama;
		}
	}
}
