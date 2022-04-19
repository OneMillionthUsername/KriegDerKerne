using System;
using System.Threading;

namespace KriegDerKerne
{
	class Player : Entity
	{
		//init fields
		private readonly string _name = "<-O->";

		//init props

		//Konstruktor
		public Player()
		{
			PosX = _maxX / 2;
			PosY = _maxY;
			Name = _name;
		}
		// Methoden

		public void Move()
		{
			do
			{
				if (Console.ReadKey(true).Key == ConsoleKey.A)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosX -= 1;
					DrawEntity();
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.D)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosX += 1;
					DrawEntity();
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.W)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosY -= 1;
					DrawEntity();
					continue;
				}
				if (Console.ReadKey(true).Key == ConsoleKey.S)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosY += 1;
					DrawEntity();
					continue;
				}
			} while (true);
		}
		public void Shoot()
		{
			//SPIELER POSITION WIRD NICHT AKTUALISIERT!
			do
			{
				// Konstruktor und bringe Cursor in richtiger Position
				Laser laser = new(PosX += 2, PosY -= 1);
				// shoot
				for (int i = 0; i < laser._maxY; i++)
				{
					if (laser.PosY == _maxY || laser.PosX >= _maxX)
					{
						laser.DeleteEntity();
						break;
					}
					Console.SetCursorPosition(laser.PosX, laser.PosY);
					laser.DeleteEntity();
					laser.PosY -= 1;
					laser.DrawEntity();
					if (laser.PosY == 0)
					{
						laser.DeleteEntity();
						break;
					}
					if (laser.PosY == laser._maxY)
					{
						laser.DeleteEntity();
						break;
					}
					Thread.Sleep(100);
				}
			} while (true);
		}
	}
}
