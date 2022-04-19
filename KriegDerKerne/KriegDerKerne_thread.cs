using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace KriegDerKerne
{
	class KriegDerKerne
	{
		static void Main()
		{
			//initialisiere Variablen und Objekte
			Random rnd = new();
			Console.CursorVisible = false;
			int anzahlEnemies = 5, dice = 0;
			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

			// erzeuge Listen
			List<Enemy> enemies = new();
			List<Thread> threads = new();

			// erzeuge Objekte und füge sie zu einer Liste
			// erzeuge die Gegner
			for (int i = 0; i < anzahlEnemies; i++)
			{
				enemies.Add(new Enemy(rnd.Next(0, maxX), rnd.Next(0, maxY)));
			}
			foreach (Enemy e in enemies)
			{
				e.DrawEntity();
			}

			//Erzeuge den Spieler
			Player player = new();
			player.DrawEntity();
			Thread playerMove = new(new ThreadStart(() => player.Move()));
			Thread playerShoot = new(new ThreadStart(() => player.Shoot()));
			//Thread checkInput = new(new ThreadStart(() => CheckInput(player)));

			//starte die Threads
			Threads(playerMove, playerShoot);

			//Hauptschleife
			do
			{
				// warte auf Eingabe?
				//starte Bewegung der Gegner
				foreach (Enemy e in enemies)
				{
					//Lösche Gegner auf pos xy
					e.DeleteEntity();
					//berechne position neu
					#region POSITION BERECHNEN

					if (e.PosY > 0 && e.PosY < e._maxY)
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
						if (e.PosY == e._maxY)
						{
							e.PosY -= 1;
						}
					}
					if (e.PosX > 0 && e.PosX < e._maxX)
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
						if (e.PosX == e._maxX)
						{
							e.PosX -= 1;
						}
					}
					#endregion
					//zeichne Gegner auf neuer pos
					e.DrawEntity();
					Thread.Sleep(10);
				}
			} while (enemies.Count != 0);

			Console.Clear();
			Console.SetCursorPosition(maxX / 2, maxY / 2);
			Console.WriteLine("GG!");
		}
		public static void CheckInput(Player p)
		{
			//if(Console.ReadKey(true).Key == ConsoleKey.Spacebar)
			//{
			//	p.Shoot();
			//}
		}
		public static void Threads(params Thread[] threads)
		{
			ConcurrentQueue<Thread> q = new();

			foreach (Thread thread in threads)
			{
				thread.Start();
				q.Enqueue(Thread.CurrentThread);
			}
		}
	}
}
