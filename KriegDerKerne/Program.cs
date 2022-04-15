using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KriegDerKerne
{

	class Program
	{
		static async Task Main()
		{
			//initialisiere Variablen
			Program p = new();
			Console.CursorVisible = false;
			int dice;
			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

			// erzeuge Listen
			Random rnd = new();
			List<Entity> entities = new();
			List<Enemy> enemies = new();
			List<Task> tasks = new();

			// erzeuge Objekte und füge sie zu einer Liste
			for (int i = 0; i < 5; i++)
			{
				enemies.Add(new Enemy("\\_I_/"));
			}

			// Erzeuge den Spieler
			Player player = new("<-0->", maxX / 2, 29);
			
			// erzeuge die Gegner
			foreach (Enemy e in enemies)
			{
				e.Name = "\\_I_/";
				e.PosX = rnd.Next(0, maxX);
				e.PosY = rnd.Next(0, maxY);
				e.DrawEntityAsync(e.PosX, e.PosY);
			}

			//Spieler zeichnen
			player.DrawEntityAsync(player.PosX, player.PosY);
			do
			{
				p.CheckInput(entities, player);
				//p.CheckInput(entities, player);
				player.MoveAsync();

				foreach (Enemy e in enemies)
				{
					e.DeleteEntityAsync(e.PosX, e.PosY);
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
					e.DrawEntityAsync(e.PosX, e.PosY);
				}

				// Winning Conditions
				foreach (Enemy e in enemies)
				{
					int count = enemies.Count;
					foreach (Entity laser in entities)
					{
						if ((laser.PosX >= e.PosX-2 && laser.PosX <= e.PosX+2) && e.PosY == laser.PosY)
						{
							laser.DeleteEntityAsync(laser.PosX, laser.PosY);
							entities.Remove(laser);
							e.DeleteEntityAsync(e.PosX, e.PosY);
							enemies.Remove(e);
							break;
						}
					}
					if (count > enemies.Count)
					{
						break;
					}
				}
				if (enemies.Count == 0)
				{
					break;
				}
				Thread.Sleep(100);
			} while (true);

			Console.Clear();
			Console.SetCursorPosition(maxX / 2, maxY / 2);
			Console.WriteLine("GG!");
		}
		public async Task CheckInput(List<Entity> entities, Player player)
		{
			if (Console.ReadKey().Key == ConsoleKey.Spacebar)
			{
				entities.Add(new Entity("|"));
				foreach (Entity laser in entities)
				{
					Task.Run(() => player.ShootAsync(laser, player.PosX, player.PosY));
				}
			}
		}
	}
}
