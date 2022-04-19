using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KriegDerKerne
{
	class Player : Entity
	{
		//inti vars
		private new int PosX;
		private new int PosY;
		private new string Name = "<-O->";

		//leerer Konstruktor
		public Player()
		{
			PosX = _maxX/2;
			PosY = _maxY;
		}
		// Methoden
		public void DrawEntity()
		{
			Console.SetCursorPosition(PosX, PosY);
			Console.Write(Name);
		}
		public void DeleteEntity()
		{
			string temp = Name;
			Name = Name.Replace(Name, new String(' ', Name.Length));
			Console.SetCursorPosition(PosX, PosY);
			Console.Write(Name);
			Name = temp;
		}
		public void Move()
		{
			do
			{
				if (Console.ReadKey(true).Key == ConsoleKey.A)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosX -= 1;
					DrawEntity();
				}
				if (Console.ReadKey(true).Key == ConsoleKey.D)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosX += 1;
					DrawEntity();
				}
				if (Console.ReadKey(true).Key == ConsoleKey.W)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosY -= 1;
					DrawEntity();
				}
				if (Console.ReadKey(true).Key == ConsoleKey.S)
				{
					Console.SetCursorPosition(PosX, PosY);
					DeleteEntity();
					PosY += 1;
					DrawEntity();
				}
			} while (true);
		}
	}
}
