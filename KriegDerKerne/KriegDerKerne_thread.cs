using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KriegDerKerne
{

	class KriegDerKerne
	{
		static void Main()
		{
			//initialisiere Variablen
			Console.CursorVisible = false;
			int dice;
			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

			// erzeuge Listen
			Random rnd = new();
			List<Entity> entities = new();
			List<Enemy> enemies = new();

			// erzeuge Objekte und füge sie zu einer Liste
			for (int i = 0; i < 5; i++)
			{
				enemies.Add(new Enemy());
			}
			// erzeuge die Gegner
			foreach (Enemy e in enemies)
			{
				e.Name = "\\_I_/";
				e.PosX = rnd.Next(0, maxX);
				e.PosY = rnd.Next(0, maxY);
				e.DrawEntity(e.PosX, e.PosY);
			}
			// Erzeuge den Spieler
			Player player = new("<-0->", maxX / 2, 29);
			//Spieler zeichnen
			player.DrawEntity(player.PosX, player.PosY);

			//erzeug die Threads
			

			//Hauptschleife
			do
			{
				Thread checkShoot = new(() => CheckInputAndShoot(entities, enemies, player));
				Thread playerMove = new(() => player.Move());
				checkShoot.Start();
				playerMove.Start();
				//checkShoot.Join();
				//playerMove.Join();
				// warte auf Eingabe?
				foreach (Enemy e in enemies)
				{
					//Lösche Gegner auf pos xy
					e.DeleteEntity(e.PosX, e.PosY);
					//berechne position neu
					if (e.PosY > 0 && e.PosY < maxY)
					{
						dice = rnd.Next(1, 2 + 1);
						if (dice > 1)
						{
							e.PosY -= 1;
						}
						else
						{
							e.PosY += 1;
						}
					}
					else
					{
						if (e.PosY == 0)
						{
							e.PosY += 1;
						}
						if (e.PosY == maxY)
						{
							e.PosY -= 1;
						}
					}
					if (e.PosX > 0 && e.PosX < maxX)
					{
						dice = rnd.Next(1, 2 + 1);
						if (dice > 1)
						{
							e.PosX -= 1;
						}
						else
						{
							e.PosX += 1;
						}
					}
					else
					{
						if (e.PosX == 0)
						{
							e.PosX += 1;
						}
						if (e.PosX == maxX)
						{
							e.PosX -= 1;
						}
					}
					//zeichne Gegner auf neuer pos
					e.DrawEntity(e.PosX, e.PosY);
				}

				// Winning Conditions
				int count = enemies.Count;
				foreach (Enemy e in enemies)
				{ 
					foreach (Entity laser in entities)
					{
						//wenn ein Gegner getroffen wird, lösche den Laser und den Gegner.
						if ((laser.PosX >= e.PosX - 2 && laser.PosX <= e.PosX + 2) && e.PosY == laser.PosY)
						{
							laser.DeleteEntity(laser.PosX, laser.PosY);
							entities.Remove(laser);
							e.DeleteEntity(e.PosX, e.PosY);
							enemies.Remove(e);
							break;
						}
					}
					if (count > enemies.Count)
					{
						break;
					}
				}
				Thread.Sleep(100);
			} while (enemies.Count != 0);
			Console.Clear();
			Console.SetCursorPosition(maxX / 2, maxY / 2);
			Console.WriteLine("GG!");
		}
		public static void CheckInputAndShoot(List<Entity> entities, List<Enemy> enemies, Player player)
		{
			if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
			{
				entities.Add(new Entity("|"));
				foreach (Entity laser in entities)
				{
					Thread laserFly = new(() => player.Shoot(entities, enemies, laser, player.PosX, player.PosY));
					laserFly.Start();
				}
				entities.Clear();
			}
		}
	}
}
