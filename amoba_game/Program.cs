using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
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

			string Kezdojatekos = Kezdojatekosmegadasa(Jatekos1, Jatekos2);

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
				}
				else
				{
					Console.WriteLine("helytelen adat");
				}

			}
			int[,] pálya = new int[width,height];
			pálya[0, 0] = 0;
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					pálya[y, x] = 0;
				}
			}
				OsszegzesKiirasa(Jatekos1, Jatekos2, Kezdojatekos, Korokszama, width, height);
			int aktualisJatekos = Kezdojatekos == Jatekos1 ? 1:2 ;
			while (true) 
			{
				pályaKirajzolas(pálya);
				LépésAdat adat = Lépés(aktualisJatekos);
				aktualisJatekos = aktualisJatekos == 1 ? 2 : 1;
				pálya[adat.x, adat.y] = adat.jatekos;

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
		static string Kezdojatekosmegadasa(string Jatekos1, string Jatekos2)
		{
			Console.WriteLine("Add meg melyik játékos kezdjen");
			Console.WriteLine("0) random ");
			Console.WriteLine($"1 {Jatekos1}");
			Console.WriteLine($"2 {Jatekos2}");
			string KezdoJatekos = Console.ReadLine();

			if (!(KezdoJatekos == "0" || KezdoJatekos == "1" || KezdoJatekos == "2"))
			{
				Console.WriteLine("Helytelen értéket adott meg");
				return Kezdojatekosmegadasa(Jatekos1, Jatekos2);
			}
			return KezdoJatekos;

		}
		static void OsszegzesKiirasa(string Jatekos1, string Jatekos2, string Kezdojatekos, int Korokszama, int width, int height)
		{
			Console.Clear();
			Console.WriteLine("------------------------------------------------------------------------");
			Console.WriteLine($"1-es játékos neve: {Jatekos1}");
			Console.WriteLine($"2-es játékos neve: {Jatekos2}");
			Console.WriteLine($"Kezdő játékos neve: {Kezdojatekos}");
			Console.WriteLine($"Körök száma: {Korokszama}");
			Console.WriteLine($"pálya mérete {width} x {height}");
			Console.WriteLine("------------------------------------------------------------------------");
			Console.WriteLine("");

		}

		static LépésAdat Lépés(int jatekos)
		{
			Console.WriteLine("Hova szeretnél lépni(x,y)");
			string LépésInput = Console.ReadLine();
			string[] kordináták = LépésInput.Split(',');
			return new LépésAdat(int.Parse(kordináták[0])-1, int.Parse(kordináták[1])-1, jatekos) ;

		}
		class LépésAdat
		{

			public LépésAdat(int x, int y, int jatekos)
			{
				this.x = x;
				this.y = y;
				this.jatekos = jatekos;
			}

			public int x { get; set; }
			public int y { get; set; }
			public int jatekos { get; set; }

		}

		static void pályaKirajzolas(int[,]pálya)
		{
			int width = pálya.GetLength(1);
			int height = pálya.GetLength(0);
			for (int y = 0; y < height; y++)
			{
				string sor = "|";

				for (int x = 0; x < width; x++)
				{
					switch(pálya[x,y])
					{
						case 0:
							sor += " |";
							break;

						case 1:
							sor += "O|";
							break;

						case 2:
							sor += "X|";
							break;
					}
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
	}
}
