//using System;
//using System.Collections.Generic;
//using System.Threading;
//using System.Threading.Tasks;

//namespace KriegDerKerne
//{

//	class KriegDerKerne
//	{
//		static async Task Main()
//		{
//			//initialisiere Variablen
//			KriegDerKerne p = new();
//			Console.CursorVisible = false;
//			int dice;
//			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

//			// erzeuge Listen
//			Random rnd = new();
//			List<Entity> entities = new();
//			List<Enemy> enemies = new();
//			List<Task> tasks = new();

//			// erzeuge Objekte und füge sie zu einer Liste
//			for (int i = 0; i < 5; i++)
//			{
//				enemies.Add(new Enemy());
//			}

//			// Erzeuge den Spieler
//			Player player = new("<-0->", maxX / 2, 29);

//			// erzeuge die Gegner
//			foreach (Enemy e in enemies)
//			{
//				e.Name = "\\_I_/";
//				e.PosX = rnd.Next(0, maxX);
//				e.PosY = rnd.Next(0, maxY);
//				e.DrawEntityAsync(e.PosX, e.PosY);
//			}

//			//Spieler zeichnen
//			player.DrawEntityAsync(player.PosX, player.PosY);

//			//Hauptschleife
//			do
//			{
//				// warte auf Eingabe?
//				tasks.Add(Task.Run(() => CheckInputAndShoot(entities, player)));
//				tasks.Add(Task.Run(() => player.MoveAsync()));
//				await Task.WhenAll(tasks);

//				foreach (Enemy e in enemies)
//				{
//					//Lösche Gegner auf pos xy
//					e.DeleteEntityAsync(e.PosX, e.PosY);
//					//berechne position neu
//					if (e.PosY > 0 && e.PosY < maxY)
//					{
//						dice = rnd.Next(1, 2 + 1);
//						if (dice > 1)
//						{
//							e.PosY -= 1;
//						}
//						else
//						{
//							e.PosY += 1;
//						}
//					}
//					else
//					{
//						if (e.PosY == 0)
//						{
//							e.PosY += 1;
//						}
//						if (e.PosY == maxY)
//						{
//							e.PosY -= 1;
//						}
//					}
//					if (e.PosX > 0 && e.PosX < maxX)
//					{
//						dice = rnd.Next(1, 2 + 1);
//						if (dice > 1)
//						{
//							e.PosX -= 1;
//						}
//						else
//						{
//							e.PosX += 1;
//						}
//					}
//					else
//					{
//						if (e.PosX == 0)
//						{
//							e.PosX += 1;
//						}
//						if (e.PosX == maxX)
//						{
//							e.PosX -= 1;
//						}
//					}
//					//zeichne Gegner auf neuer pos
//					e.DrawEntityAsync(e.PosX, e.PosY);
//				}

//				// Winning Conditions
//				foreach (Enemy e in enemies)
//				{
//					int count = enemies.Count;

//					foreach (Entity laser in entities)
//					{
//						//wenn ein Gegner getroffen wird, lösche den Laser und den Gegner.
//						if ((laser.PosX >= e.PosX-2 && laser.PosX <= e.PosX+2) && e.PosY == laser.PosY)
//						{
//							laser.DeleteEntityAsync(laser.PosX, laser.PosY);
//							entities.Remove(laser);
//							e.DeleteEntityAsync(e.PosX, e.PosY);
//							enemies.Remove(e);
//							break;
//						}
//					}
//					if (count > enemies.Count)
//					{
//						break;
//					}
//				}
//				Thread.Sleep(100);
//			} while (enemies.Count != 0);
//			Console.Clear();
//			Console.SetCursorPosition(maxX / 2, maxY / 2);
//			Console.WriteLine("GG!");
//		}
//		public static Task CheckInputAndShoot(List<Entity> entities, Player player)
//		{
//			if (Console.ReadKey().Key == ConsoleKey.Spacebar)
//			{
//				entities.Add(new Entity("|"));
//				foreach (Entity laser in entities)
//				{
//					player.ShootAsync(laser, player.PosX, player.PosY);
//				}
//				entities.Clear();
//			} 
//			return Task.CompletedTask;
//		}
//	}
//}
