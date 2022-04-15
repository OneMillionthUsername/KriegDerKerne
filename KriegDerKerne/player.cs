using System;
using System.Threading;
using System.Threading.Tasks;

namespace KriegDerKerne
{
	class Player : Entity
	{
		public async Task MoveAsync(int PosX, int PosY)
		{
			if (Console.ReadKey().Key == ConsoleKey.A)
			{
				PosX -= 1;
			}
			if (Console.ReadKey().Key == ConsoleKey.D)
			{
				PosX += 1;
			}
			if (Console.ReadKey().Key == ConsoleKey.W)
			{
				PosY -= 1;
			}
			if (Console.ReadKey().Key == ConsoleKey.S)
			{
				PosY += 1;
			}
			await Task.CompletedTask;
			//if((PosX < maxX || PosY < maxY) && (PosY > 0 || PosX > 0)) 
		}
		public async Task ShootAsync(int PosX, int PosY)
		{
			PosX += 2;
			int temp = PosY;
			string tName = Name;
			Name = "|";
			PosY -= 1;
			for (int i = 0; i < _maxY; i++)
			{
				Console.SetCursorPosition(PosX, PosY);
				await DeleteEntitiyAsync(PosX, PosY);
				PosY -= 1;
				await DrawEntityAsync(PosX, PosY);
				if (PosY == 0)
				{
					await DeleteEntitiyAsync(PosX, PosY);
					break;
				}
				if (PosY == _maxY)
				{
					await DeleteEntitiyAsync(PosX, PosY);
					break;
				}
				Thread.Sleep(100);
			}
			PosY = temp;
			Name = tName;
			await Task.CompletedTask;
		}
	}
}
