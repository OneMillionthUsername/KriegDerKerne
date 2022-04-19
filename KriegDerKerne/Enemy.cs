using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KriegDerKerne
{
	class Enemy : Entity
	{
		//inti vars
		private new int PosX;
		private new int PosY;
		private new string Name = "\\_I_/";

		//Konstruktor
		public Enemy(int x, int y)
		{
			PosX = x;
			PosY = y;
		}

		public void DrawEnemy()
		{
			Console.SetCursorPosition(PosX, PosY);
			Console.Write(Name);
		}
		public void DeleteEnemy()
		{
			string temp = Name;
			Name = Name.Replace(Name, new String(' ', Name.Length));
			Console.SetCursorPosition(PosX, PosY);
			Console.Write(Name);
			Name = temp;
		}

		public void Move()
		{
			Random rnd = new();
			int dice;

			do
			{
				//Lösche Gegner auf pos xy
				DeleteEnemy();
				//berechne position neu
				if (PosY > 0 && PosY < _maxY)
				{
					dice = rnd.Next(1, 2 + 1);
					if (dice > 1)
					{
						PosY -= 1;
					}
					else
					{
						PosY += 1;
					}
				}
				else
				{
					if (PosY == 0)
					{
						PosY += 1;
					}
					if (PosY == _maxY)
					{
						PosY -= 1;
					}
				}
				if (PosX > 0 && PosX < _maxX)
				{
					dice = rnd.Next(1, 2 + 1);
					if (dice > 1)
					{
						PosX -= 1;
					}
					else
					{
						PosX += 1;
					}
				}
				else
				{
					if (PosX == 0)
					{
						PosX += 1;
					}
					if (PosX == _maxX)
					{
						PosX -= 1;
					}
				}
				//zeichne Gegner auf neuer pos
				DrawEnemy();
				Thread.Sleep(100);
			} while (true);
		}
	}
}
