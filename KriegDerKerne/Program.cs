using System;
using System.Collections.Generic;
using System.Threading;

namespace KriegDerKerne
{

	class Program
	{
		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			Random rnd = new Random();
			int dice = 0;
			int maxX = Console.WindowWidth - 1, maxY = Console.WindowHeight - 1;

			List<Entity> entities = new();
			Entity e1 = new();
			Entity e2 = new();
			Entity e3 = new();
			Entity e4 = new();

			entities.Add(e1);
			entities.Add(e2);
			entities.Add(e3);
			entities.Add(e4);

			e1.Name = "\\_I_/";
			e2.Name = "\\_I_/";
			e3.Name = "\\_I_/";
			e4.Name = "\\_I_/";

			e1.PosX = rnd.Next(0, maxX);
			e1.PosY = rnd.Next(0, maxY);
			e2.PosX = rnd.Next(0, maxX);
			e2.PosY = rnd.Next(0, maxY);
			e3.PosX = rnd.Next(0, maxX);
			e3.PosY = rnd.Next(0, maxY);
			e4.PosX = rnd.Next(0, maxX);
			e4.PosY = rnd.Next(0, maxY);

			//initialisieren Cursor startposition
			e1.DrawEntity(e1.PosX, e1.PosY);
			e2.DrawEntity(e2.PosX, e2.PosY);
			e3.DrawEntity(e3.PosX, e3.PosY);
			e4.DrawEntity(e4.PosX, e4.PosY);

			Thread.Sleep(300);

			do
			{
				//Console.Clear();
				foreach (Entity entity in entities)
				{
					entity.DeleteEntitiy(entity.PosX, entity.PosY);
				}
				foreach (Entity entity in entities)
				{
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
					entity.DrawEntity(entity.PosX, entity.PosY);
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
				Thread.Sleep(10);
			} while (true);
			Console.Clear();
			Console.WriteLine("GG!");
		}
	}
}
