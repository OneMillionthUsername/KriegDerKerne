using System;
using System.Threading;
using System.Threading.Tasks;

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
		public async Task MoveAsync()
		{
			if (Console.ReadKey().Key == ConsoleKey.A)
			{
				Console.SetCursorPosition(PosX, PosY);
				DeleteEntityAsync(PosX, PosY);
				PosX -= 1;
				DrawEntityAsync(PosX, PosY);
			}
			if (Console.ReadKey().Key == ConsoleKey.D)
			{
				Console.SetCursorPosition(PosX, PosY);
				DeleteEntityAsync(PosX, PosY);
				PosX += 1;
				DrawEntityAsync(PosX, PosY);
			}
			if (Console.ReadKey().Key == ConsoleKey.W)
			{
				Console.SetCursorPosition(PosX, PosY);
				DeleteEntityAsync(PosX, PosY);
				PosY -= 1;
				DrawEntityAsync(PosX, PosY);
			}
			if (Console.ReadKey().Key == ConsoleKey.S)
			{
				Console.SetCursorPosition(PosX, PosY);
				DeleteEntityAsync(PosX, PosY);
				PosY += 1;
				DrawEntityAsync(PosX, PosY);
			}
			await Task.CompletedTask;
		}
		public async Task ShootAsync(Entity entity, int PosX, int PosY)
		{
			// bringe Cursor in richtiger Position
			PosX += 2;
			int temp = PosY;
			PosY -= 1;
			// shoot
			for (	int i = 0; i < _maxY; i++)
			{
				Console.SetCursorPosition(PosX, PosY);
				entity.DeleteEntityAsync(PosX, PosY);
				PosY -= 1;
				entity.DrawEntityAsync(PosX, PosY);
				if (PosY == 0)
				{
					entity.DeleteEntityAsync(PosX, PosY);
					break;
				}
				if (PosY == _maxY)
				{
					entity.DeleteEntityAsync(PosX, PosY);
					break;
				}
				Thread.Sleep(100);
			}
			PosY = temp;
			await Task.CompletedTask;
		}
	}
}
