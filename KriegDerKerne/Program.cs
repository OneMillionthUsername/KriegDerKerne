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
			Console.CursorVisible = false;
			int dice;
			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

			//erzeuge Objekte
			Random rnd = new();
			List<Entity> entities = new();
			List<Task> tasks = new();
			Entity e1 = new();
			Entity e2 = new();
			Entity e3 = new();
			Entity e4 = new();
			Player player = new();
			

			//Speicher sie in einer Liste
			entities.Add(e1);
			entities.Add(e2);
			entities.Add(e3);
			entities.Add(e4);

			//erzeuge die Graphik
			player.Name = "<-O->";
			e1.Name = "\\_I_/";
			e2.Name = "\\_I_/";
			e3.Name = "\\_I_/";
			e4.Name = "\\_I_/";

			//init die Positionen
			player.PosX = maxX / 2;
			player.PosY = 29;

			e1.PosX = rnd.Next(0, maxX);
			e1.PosY = rnd.Next(0, maxY);
			e2.PosX = rnd.Next(0, maxX);
			e2.PosY = rnd.Next(0, maxY);
			e3.PosX = rnd.Next(0, maxX);
			e3.PosY = rnd.Next(0, maxY);
			e4.PosX = rnd.Next(0, maxX);
			e4.PosY = rnd.Next(0, maxY);

			//Gegenstände zeichnen
			foreach (Entity e in entities)
			{
				e.PosX = rnd.Next(0, maxX);
				e.PosY = rnd.Next(0, maxY);
				tasks.Add(Task.Run(() => e.DrawEntityAsync(e.PosX, e.PosY)));
			}
			await Task.WhenAll(tasks);
			//await e1.DrawEntityAsync(e1.PosX, e1.PosY);
			//await e2.DrawEntityAsync(e2.PosX, e2.PosY);
			//await e3.DrawEntityAsync(e3.PosX, e3.PosY);
			//await e4.DrawEntityAsync(e4.PosX, e4.PosY);

			//Spieler zeichnen
			await player.DrawEntityAsync(player.PosX, player.PosY);

			do
			{
				//player.Move(player.PosX, player.PosY);

				//if (Console.ReadKey().Key == ConsoleKey.A)
				//{
				//	Console.SetCursorPosition(player.PosX, player.PosY);
				//	player.DeleteEntitiy(player.PosX, player.PosY);
				//	player.PosX -= 1;
				//	player.DrawEntity(player.PosX, player.PosY);
				//}
				//if (Console.ReadKey().Key == ConsoleKey.D)
				//{
				//	Console.SetCursorPosition(player.PosX, player.PosY);
				//	player.DeleteEntitiy(player.PosX, player.PosY);
				//	player.PosX += 1;
				//	player.DrawEntity(player.PosX, player.PosY);
				//}
				//if (Console.ReadKey().Key == ConsoleKey.W)
				//{
				//	Console.SetCursorPosition(player.PosX, player.PosY);
				//	player.DeleteEntitiy(player.PosX, player.PosY);
				//	player.PosY -= 1;
				//	player.DrawEntity(player.PosX, player.PosY);
				//}
				//if (Console.ReadKey().Key == ConsoleKey.S)
				//{
				//	Console.SetCursorPosition(player.PosX, player.PosY);
				//	player.DeleteEntitiy(player.PosX, player.PosY);
				//	player.PosY += 1;
				//	player.DrawEntity(player.PosX, player.PosY);
				//}

				if (Console.ReadKey().Key == ConsoleKey.Spacebar)
				{
					tasks.Add(Task.Run(() => player.ShootAsync(player.PosX, player.PosY)));
				}

				foreach (Entity entity in entities)
				{
					entity.DeleteEntitiyAsync(entity.PosX, entity.PosY);
					if (entity.PosY > 0 && entity.PosY < maxY)
					{
						dice = rnd.Next(1, 2 + 1);
						if (dice > 1)
						{
							entity.PosY -= 1;
						}
						else
						{
							entity.PosY += 1;
						}
					}
					else
					{
						if (entity.PosY == 0)
						{
							entity.PosY += 1;
						}
						if (entity.PosY == maxY)
						{
							entity.PosY -= 1;
						}
					}
					if (entity.PosX > 0 && entity.PosX < maxX)
					{
						dice = rnd.Next(1, 2 + 1);
						if (dice > 1)
						{
							entity.PosX -= 1;
						}
						else
						{
							entity.PosX += 1;
						}
					}
					else
					{
						if (entity.PosX == 0)
						{
							entity.PosX += 1;
						}
						if (entity.PosX == maxX)
						{
							entity.PosX -= 1;
						}
					}
					entity.DrawEntityAsync(entity.PosX, entity.PosY);
				}

					if ((e1.PosX == e2.PosX || e1.PosX == e3.PosX || e1.PosX == e4.PosX) &&
						(e1.PosY == e2.PosY || e1.PosY == e3.PosY || e1.PosX == e4.PosY))
					{
						if ((e2.PosX == e3.PosX || e2.PosX == e4.PosX) &&
							(e2.PosY == e3.PosY || e2.PosY == e4.PosY))
						{
							if ((e3.PosX == e4.PosX) &&
								(e3.PosY == e4.PosY))
							{
								break;
							}
							break;
						}
						break;
					}
				Thread.Sleep(100);

			} while (true);

			Console.Clear();
			Console.WriteLine("GG!");
		}
	}
}
