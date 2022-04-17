using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KriegDerKerne
{
	class Player : Entity
	{
		//leerer Konstruktor
		public Player() { }

		//Konstruktor für Name
		public Player(string name, int posX, int posY)
		{
			Name = name;
			PosX = posX;
			PosY = posY;
		}
		// Methoden
		public void Move()
		{
			if (Console.ReadKey(true).Key == ConsoleKey.A)
			{
				Console.SetCursorPosition(PosX, PosY);
				DeleteEntity(PosX, PosY);
				PosX -= 1;
				DrawEntity(PosX, PosY);
			}
			if (Console.ReadKey(true).Key == ConsoleKey.D)
			{
				Console.SetCursorPosition(PosX, PosY);
				DeleteEntity(PosX, PosY);
				PosX += 1;
				DrawEntity(PosX, PosY);
			}
			if (Console.ReadKey(true).Key == ConsoleKey.W)
			{
				Console.SetCursorPosition(PosX, PosY);
				DeleteEntity(PosX, PosY);
				PosY -= 1;
				DrawEntity(PosX, PosY);
			}
			if (Console.ReadKey(true).Key == ConsoleKey.S)
			{
				Console.SetCursorPosition(PosX, PosY);
				DeleteEntity(PosX, PosY);
				PosY += 1;
				DrawEntity(PosX, PosY);
			}
		}
		public void Shoot(List<Entity> entities, List<Enemy> enemies, Entity entity, int PosX, int PosY)
		{
			// bringe Cursor in richtiger Position
			PosX += 2;
			PosY -= 1;
			// shoot
			for (	int i = 0; i < _maxY; i++)
			{
				Console.SetCursorPosition(PosX, PosY);
				entity.DeleteEntity(PosX, PosY);
				PosY -= 1;
				entity.DrawEntity(PosX, PosY);
				if (PosY == 0)
				{
					entity.DeleteEntity(PosX, PosY);
					break;
				}
				if (PosY == _maxY)
				{
					entity.DeleteEntity(PosX, PosY);
					break;
				}
				foreach (Enemy e in enemies)
				{
					foreach (Entity l in entities)
					{
						//wenn ein Gegner getroffen wird, lösche den Laser und den Gegner.
						if ((l.PosX >= e.PosX - 2 && l.PosX <= e.PosX + 2) && e.PosY == l.PosY)
						{
							l.DeleteEntity(l.PosX, l.PosY);
							entities.Remove(l);
							e.DeleteEntity(e.PosX, e.PosY);
							enemies.Remove(e);
							break;
						}
					}
				}
				Thread.Sleep(100);
			}
		}
	}
}
