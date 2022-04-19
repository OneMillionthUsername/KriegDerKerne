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
			int anzahlEnemies = 2;
			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

			// erzeuge Listen
			Random rnd = new();
			List<Enemy> enemies = new();
			List<Thread> threads = new();
			//Laser laser = new();

			// erzeuge Objekte und füge sie zu einer Liste
			for (int i = 0; i < anzahlEnemies; i++)
			{
				enemies.Add(new Enemy(rnd.Next(0, maxX), rnd.Next(0, maxY)));
			}
			// erzeuge die Gegner
			foreach (Enemy e in enemies)
			{
				e.DrawEnemy();
			}
			//Erzeuge den Spieler
			Player player = new();
			//Spieler zeichnen
			player.DrawEntity();
			Thread playerMove = new Thread(new ThreadStart(() => player.Move()));
			foreach (Enemy enemy in enemies)
			{
				enemy.Move();
			}
			//Thread playerShoot = new Thread(new ThreadStart(() => laser.Shoot(player.PosX, player.PosY)));
			//Thread runtime = new Thread(() => threads.Add(playerMove));

			//starte die Threads
			playerMove.Start();
			//starte Bewegung der Gegner
			foreach (Thread thread in threads)
			{
				thread.Start();
			}
			
			//playerShoot.Start();
			//Hauptschleife
			do
			{
				// warte auf Eingabe?
				// Winning Conditions
				//Thread.Sleep(100);
			} while (enemies.Count != 0);
			Console.Clear();
			Console.SetCursorPosition(maxX / 2, maxY / 2);
			Console.WriteLine("GG!");
		}
		public static void CheckInputAndShoot(Player player)
		{
			do
			{
				if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
				{

				} 
			} while (true);
		}
	}
}
